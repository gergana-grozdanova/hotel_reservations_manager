using HotelReservationsManager.Dtos;

namespace HotelReservationsManager.Services
{
    public interface IBaseService<TDto, TInputDto> 
        where TDto:BaseDto
        where TInputDto:InputDto
    {
        public Task<TDto> GetByIdAsync(string id);
        public Task<int> GetCount();

        public Task<List<TDto>> GetAllAsync(int page,int itemsPerPage);

        public Task<TInputDto> CreateAsync(TInputDto dto);

        public Task DeleteAsync(string id);

        public Task UpdateAsync(TDto dto);
    }
}
