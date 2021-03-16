using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace src.DigitalMenu.Api.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // var list = new List<DMUser>()
            // {
            //     new DMUser
            //     {
            //         Id = Guid.NewGuid(),
            //         FirstName = "Eren",
            //         LastName = "Kaya",
            //         UserName = "ErenKaya",
            //         EmailAddress = "erenkaya@gmail.com",
            //         PhoneNumber = "12345",
            //         EmailConfirmed = false,
            //         PasswordHash = "asdasd",
            //         CreatedAt = DateTime.Now
            //     },
            //     new DMUser
            //     {
            //         Id = Guid.NewGuid(),
            //         FirstName = "Emir",
            //         LastName = "Kaya",
            //         UserName = "EmirKaya",
            //         EmailAddress = "emirkaya@gmail.com",
            //         PhoneNumber = "67890",
            //         EmailConfirmed = false,
            //         PasswordHash = "asdasd",
            //         CreatedAt = DateTime.Now
            //     },
            //     new DMUser
            //     {
            //         Id = Guid.NewGuid(),
            //         FirstName = "Alara",
            //         LastName = "Kaya",
            //         UserName = "AlaraKaya",
            //         EmailAddress = "alarakaya@gmail.com",
            //         PhoneNumber = "54321",
            //         EmailConfirmed = false,
            //         PasswordHash = "asdasd",
            //         CreatedAt = DateTime.Now
            //     },
            // };

            // _unitOfWork.UserRepository.AddRange(list, true);
            // await _unitOfWork.SaveChangesAsync();

            // var entities = _unitOfWork.UserRepository.FindAll(true).ToList();

            // foreach (var entity in entities)
            // {
            //     System.Console.WriteLine(entity.UserName);
            //     System.Console.WriteLine(entity.FirstName);
            //     System.Console.WriteLine(entity.LastName);
            //     System.Console.WriteLine(entity.EmailAddress);
            //     System.Console.WriteLine(entity.PhoneNumber);
            //     System.Console.WriteLine("-------------------------------");
            // }

            // var entity = await _unitOfWork.UserRepository.FindOneAsync(x => x.Id == Guid.Parse("0acfe218-5b34-402b-939a-2ba294676bca"), true);

            // if (entity != null)
            // {
            //     entity.UserName = "eeerenKaya";
            //     entity.FirstName = "eeeren";
            //     entity.LastName = "Kayaaa";
            //     entity.EmailAddress = "eeeren123@gmail.com";
            //     entity.PhoneNumber = "111111";

            //     _unitOfWork.UserRepository.Update(entity, true);
            //     await _unitOfWork.SaveChangesAsync();
            // }

            // var entity2 = await _unitOfWork.UserRepository.FindOneAsync(x => x.Id == Guid.Parse("0acfe218-5b34-402b-939a-2ba294676bca"), true);

            // if (entity2 != null)
            // {
            //     System.Console.WriteLine(entity2.UserName);
            //     System.Console.WriteLine(entity2.FirstName);
            //     System.Console.WriteLine(entity2.LastName);
            //     System.Console.WriteLine(entity2.EmailAddress);
            //     System.Console.WriteLine(entity2.PhoneNumber);
            // }

            return Ok();
        }
    }
}