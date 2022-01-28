
using System.Collections.Generic;
using System.Threading.Tasks;

using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IPaisService
    {
        Task<IEnumerable<PaisDTO>> GetPaisesAsync();
        Task<PaisDTO> GetByIdAsync(int? id);
        Task AddAsync(PaisDTO categoryDTO);
        Task UpdateAsync(PaisDTO categoryDTO);
        Task RemoveAsync(int? id);
    }
}
