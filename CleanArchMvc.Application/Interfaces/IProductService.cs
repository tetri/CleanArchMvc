using System.Collections.Generic;
using System.Threading.Tasks;

using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int? id);
        //Task<ProductDTO> GetProductCategoryAsync(int? id);
        Task AddAsync(ProductDTO ProductDTO);
        Task UpdateAsync(ProductDTO ProductDTO);
        Task RemoveAsync(int? id);
    }
}
