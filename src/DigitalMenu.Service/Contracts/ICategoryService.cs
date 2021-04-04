using System;
using System.Threading.Tasks;
using DigitalMenu.Core.Model.Category;

namespace DigitalMenu.Service.Contracts
{
    public interface ICategoryService
    {
        Task<ServiceResponse<object>> InsertCategoryAsync(NewCategoryModel model, Guid userId);
    }
}