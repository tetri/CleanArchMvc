using System.Collections.Generic;
using System.Threading.Tasks;

using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IPaisRepository
    {
        Task<IEnumerable<Pais>> GetPaisesAsync();
        Task<Pais> GetByIdAsync(int? id);

        Task<Pais> CreateAsync(Pais pais);
        Task<Pais> UpdateAsync(Pais pais);
        Task<Pais> RemoveAsync(Pais pais);
    }
}
