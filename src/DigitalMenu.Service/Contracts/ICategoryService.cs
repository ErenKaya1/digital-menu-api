using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalMenu.Core.Model.Category;
using DigitalMenu.Entity.DTOs;

namespace DigitalMenu.Service.Contracts
{
    public interface ICategoryService
    {
        Task<ServiceResponse<object>> InsertCategoryAsync(NewCategoryModel model, Guid userId);
        Task<ServiceResponse<List<CategoryDTO>>> GetCategories(Guid userId);
    }
}