using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class PaisService : IPaisService
    {
        private IPaisRepository _paisRepository;
        private readonly IMapper _mapper;

        public PaisService(IPaisRepository paisRepository, IMapper mapper)
        {
            _paisRepository = paisRepository ?? throw new ArgumentNullException(nameof(paisRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaisDTO>> GetPaisesAsync()
        {
            var categoriesEntity = await _paisRepository.GetPaisesAsync();
            return _mapper.Map<IEnumerable<PaisDTO>>(categoriesEntity);
        }

        public async Task<PaisDTO> GetByIdAsync(int? id)
        {
            var paisEntity = await _paisRepository.GetByIdAsync(id);
            return _mapper.Map<PaisDTO>(paisEntity);
        }

        public async Task AddAsync(PaisDTO paisDTO)
        {
            var paisEntity = _mapper.Map<Pais>(paisDTO);
            await _paisRepository.CreateAsync(paisEntity);
        }

        public async Task UpdateAsync(PaisDTO paisDTO)
        {
            var paisEntity = _mapper.Map<Pais>(paisDTO);
            await _paisRepository.UpdateAsync(paisEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var paisEntity = await _paisRepository.GetByIdAsync(id); //.Result ???
            await _paisRepository.RemoveAsync(paisEntity);
        }
    }
}
