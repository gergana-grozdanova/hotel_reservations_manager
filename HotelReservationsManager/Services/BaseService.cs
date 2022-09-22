using AutoMapper;
using HotelReservationsManager.Data;
using HotelReservationsManager.Dtos;
using HotelReservationsManager.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationsManager.Services
{
    public abstract class BaseService<TDto, TInputDto> : IBaseService<TDto, TInputDto>
        where TDto : BaseDto
        where TInputDto : InputDto
    {
        protected readonly IBaseRepository<TDto, TInputDto> _baseRepository;
        public BaseService(IBaseRepository<TDto, TInputDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual async Task<List<TDto>> GetAllPaginatedAsync(int page, int itemsPerPage)
        {
            return await _baseRepository.GetAllPaginatedAsync( page, itemsPerPage);
        }

        public virtual async Task<TDto> GetByIdAsync(string id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public virtual async Task<TDto> CreateAsync(TInputDto dto)
        {
            return await _baseRepository.CreateAsync(dto);
        }
        public virtual async Task DeleteAsync(string id)
        {
            await _baseRepository.DeleteAsync(id);
        }
        public virtual async Task UpdateAsync(TDto dto)
        {
            await _baseRepository.UpdateAsync(dto);
        }

        public virtual async Task<int> GetCount()
        {
           return await _baseRepository.GetCount();
        }

        public virtual async Task<List<TDto>> GetAllAsync()
        {
         return  await _baseRepository.GetAllAsync();
        }

        public virtual async Task<List<TInputDto>> AddRange(List<TInputDto> dtos)
        {
            return await _baseRepository.AddRange(dtos);
        }
    }
    }
