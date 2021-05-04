using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalMenu.Core.Model;
using DigitalMenu.Core.Model.Subscription;
using DigitalMenu.Core.Security.Contracts;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;
using Iyzipay.Request;
using Microsoft.Extensions.Options;

namespace DigitalMenu.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncryption _encryption;
        private readonly IOptions<IyzicoConfig> _iyzicoConfig;

        public PaymentService(IUnitOfWork unitOfWork, IEncryption encryption, IOptions<IyzicoConfig> iyzicoConfig)
        {
            _unitOfWork = unitOfWork;
            _encryption = encryption;
            _iyzicoConfig = iyzicoConfig;
        }

        public async Task<ServiceResponse<double>> PayAsync(Guid userId, RenewSubscriptionModel model, string ipAddress)
        {
            var user = await _unitOfWork.UserRepository.FindByIdAsync(userId);
            var subscriptionType = await _unitOfWork.SubscriptionTypeRepository.FindByIdAsync(model.SubscriptionTypeId);

            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Iyzipay.Model.Locale.TR.ToString(),
                ConversationId = user.Id.ToString(),
                Price = subscriptionType.Price.ToString(),
                PaidPrice = subscriptionType.Price.ToString(),
                Currency = Iyzipay.Model.Currency.TRY.ToString(),
                Installment = 1,
                BasketId = user.Id.ToString(),
                PaymentChannel = Iyzipay.Model.PaymentChannel.WEB.ToString(),
                PaymentGroup = Iyzipay.Model.PaymentGroup.SUBSCRIPTION.ToString(),
                PaymentCard = new Iyzipay.Model.PaymentCard
                {
                    CardHolderName = model.CardHolder,
                    CardNumber = model.CardNumber,
                    ExpireMonth = model.CardMonth, // 12
                    ExpireYear = model.CardYear, // 2030 
                    Cvc = model.CardCvv, // 123
                    RegisterCard = 0,
                },
                Buyer = new Iyzipay.Model.Buyer
                {
                    Id = user.Id.ToString(),
                    Name = user.FirstName,
                    Surname = user.LastName,
                    GsmNumber = _encryption.DecryptText(user.PhoneNumber),
                    Email = _encryption.DecryptText(user.EmailAddress),
                    IdentityNumber = "11111111111",
                    RegistrationAddress = "Esenyurt",
                    Ip = ipAddress,
                    City = "Istanbul",
                    Country = "Turkey",
                    ZipCode = "34732",
                },
                ShippingAddress = new Iyzipay.Model.Address
                {
                    ContactName = user.FullName,
                    City = "Istanbul",
                    Country = "Turkey",
                    Description = "Esenyurt",
                    ZipCode = "34742",
                },
                BillingAddress = new Iyzipay.Model.Address
                {
                    ContactName = user.FullName,
                    City = "Istanbul",
                    Country = "Turkey",
                    Description = "Esenyurt",
                    ZipCode = "34742",
                },
                BasketItems = new List<Iyzipay.Model.BasketItem>
                {
                    new Iyzipay.Model.BasketItem
                    {
                        Id = subscriptionType.Id.ToString(),
                        Name = subscriptionType.Id.ToString(),
                        ItemType = Iyzipay.Model.BasketItemType.VIRTUAL.ToString(),
                        Category1 = "Subscription Type",
                        Price = subscriptionType.Price.ToString(),
                    }
                }
            };

            var options = new Iyzipay.Options
            {
                ApiKey = _iyzicoConfig.Value.ApiKey,
                SecretKey = _iyzicoConfig.Value.SecretKey,
                BaseUrl = _iyzicoConfig.Value.BaseUrl
            };

            Iyzipay.Model.Payment payment = Iyzipay.Model.Payment.Create(request, options);
            if (payment.Status == "success")
                return new ServiceResponse<double>(true) { Data = subscriptionType.Price };

            return new ServiceResponse<double>(false, payment.ErrorCode) { Data = subscriptionType.Price };
        }

        public async Task<ServiceResponse<object>> InsertPaymentAsync(Guid userId, Guid subscriptionId, double amount)
        {
            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                Amount = amount,
                UserId = userId,
                SubscriptionId = subscriptionId
            };

            _unitOfWork.PaymentRepository.Add(payment);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<object>(true);
        }
    }
}