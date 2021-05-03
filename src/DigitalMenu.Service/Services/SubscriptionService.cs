using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalMenu.Common.Enum;
using DigitalMenu.Core.Security.Contracts;
using DigitalMenu.Entity.DTOs;
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
                .Find(x => !x.IsSuspended)
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
    }
}