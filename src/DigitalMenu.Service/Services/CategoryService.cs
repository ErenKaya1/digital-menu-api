using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;

namespace DigitalMenu.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}