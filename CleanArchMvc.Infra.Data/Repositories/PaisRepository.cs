using System.Collections.Generic;
using System.Threading.Tasks;

using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private ApplicationDbContext _paisContext;

        public PaisRepository(ApplicationDbContext context)
        {
            _paisContext = context;
        }

        public async Task<Pais> CreateAsync(Pais pais)
        {
            _paisContext.Add(pais);
            await _paisContext.SaveChangesAsync();
            return pais;
        }

        public async Task<Pais> GetByIdAsync(int? id)
        {
            return await _paisContext.Paises.FindAsync(id);
        }

        public async Task<IEnumerable<Pais>> GetPaisesAsync()
        {
            return await _paisContext.Paises.ToListAsync();
        }

        public async Task<Pais> RemoveAsync(Pais pais)
        {
            _paisContext.Remove(pais);
            await _paisContext.SaveChangesAsync();
            return pais;
        }

        public async Task<Pais> UpdateAsync(Pais pais)
        {
            _paisContext.Update(pais);
            await _paisContext.SaveChangesAsync();
            return pais;
        }
    }
}
