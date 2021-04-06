using System;
using System.Threading.Tasks;
using DigitalMenu.Core.Model.Product;

namespace DigitalMenu.Service.Contracts
{
    public interface IProductService
    {
        Task<ServiceResponse<object>> InsertProductAsync(Guid userId, NewProductModel model);
    }
}