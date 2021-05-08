using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalMenu.Core.Model.Product;
using DigitalMenu.Entity.DTOs;

namespace DigitalMenu.Service.Contracts
{
    public interface IProductService
    {
        Task<ServiceResponse<object>> InsertProductAsync(Guid userId, NewProductModel model);
        Task<ServiceResponse<List<ProductDTO>>> GetProductsAsync(Guid userId);
        Task<ServiceResponse<object>> UpdateProductAsync(Guid userId, UpdateProductModel model);
        Task<ServiceResponse<object>> DeleteProductAsync(Guid userId, Guid productId);
        Task<ServiceResponse<ProductDTO>> GetByIdAsync(Guid userId, Guid productId);
    }
}