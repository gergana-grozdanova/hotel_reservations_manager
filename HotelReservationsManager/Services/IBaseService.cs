using HotelReservationsManager.Dtos;

namespace HotelReservationsManager.Services
{
    public interface IBaseService<TDto, TInputDto> 
        where TDto:BaseDto
        where TInputDto:InputDto
    {
        public Task<TDto> GetByIdAsync(string id);
        public Task<int> GetCount();

        public Task<List<TDto>> GetAllAsync();
        public Task<List<TDto>> GetAllPaginatedAsync(int page,int itemsPerPage);

        public Task<TDto> CreateAsync(TInputDto dto);
        public Task<List<TInputDto>> AddRange(List<TInputDto> dtos);

        public Task DeleteAsync(string id);

        public Task UpdateAsync(TDto dto);
    }
}
