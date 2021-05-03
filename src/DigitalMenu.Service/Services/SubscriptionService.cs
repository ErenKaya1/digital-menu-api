using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalMenu.Common.Enum;
using DigitalMenu.Core.Model.Subscription;
using DigitalMenu.Core.Security.Contracts;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DigitalMenu.Service.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEncryption _encryption;

        public SubscriptionService(IUnitOfWork unitOfWork, IMapper mapper, IEncryption encryption)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _encryption = encryption;
        }

        public async Task<ServiceResponse<List<SubscriptionDTO>>> GetAllAsync()
        {
            var entities = await _unitOfWork.SubscriptionRepository
                .Find(x => !x.IsSuspended && x.IsCurrent)
                .Include(x => x.User)
                .Select(x => new SubscriptionDTO
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    IsTrialMode = x.IsTrialMode,
                    IsSubscriptionReminderMailSent = x.IsSubscriptionReminderMailSent,
                    SubscriptionTypeId = x.SubscriptionTypeId,
                    IsExpired = x.IsExpired,
                    UserId = x.UserId,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    EmailAddress = _encryption.DecryptText(x.User.EmailAddress)

                }).ToListAsync();

            return new ServiceResponse<List<SubscriptionDTO>>(true) { Data = entities };
        }

        public async Task UpdateReminderMailSentStatusByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.SubscriptionRepository.FindByIdAsync(id);
            if (entity == null) return;
            entity.IsSubscriptionReminderMailSent = true;
            _unitOfWork.SubscriptionRepository.Update(entity);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ServiceResponse<SubscriptionStatus>> CheckSubscriptionAsync(Guid userId)
        {
            var subscription = await _unitOfWork.SubscriptionRepository.FindOneAsync(x => x.UserId == userId);

            if (subscription.IsExpired)
                return new ServiceResponse<SubscriptionStatus>(true, "Expired");

            if (subscription.IsSuspended)
                return new ServiceResponse<SubscriptionStatus>(true, "Suspended");

            return new ServiceResponse<SubscriptionStatus>(true, "Success");
        }

        public async Task<ServiceResponse<object>> RenewSubscription(Guid userId, RenewSubscriptionModel model)
        {
            

            var oldSubscription = await _unitOfWork.SubscriptionRepository.Find(x => x.UserId == userId && x.IsCurrent).FirstOrDefaultAsync();
            oldSubscription.IsCurrent = false;

            var newSubscription = new Subscription
            {
                Id = Guid.NewGuid(),
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.Date.AddDays(14),
                IsCurrent = true,
                IsSubscriptionReminderMailSent = false,
                IsSuspended = false,
                IsTrialMode = false,
                SubscriptionTypeId = model.SubscriptionTypeId,
                UserId = oldSubscription.UserId
            };

            _unitOfWork.SubscriptionRepository.Update(oldSubscription);
            _unitOfWork.SubscriptionRepository.Add(newSubscription);

            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<object>(true);
        }
    }
}