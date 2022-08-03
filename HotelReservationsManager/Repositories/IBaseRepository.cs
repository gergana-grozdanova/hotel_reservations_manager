using HotelReservationsManager.Dtos;
using System.Linq.Expressions;

namespace HotelReservationsManager.Repositories
{
    public interface IBaseRepository<TDto,TInputDto> 
        where TDto:BaseDto 
        where TInputDto : InputDto
    {
        public Task<TDto> GetByIdAsync(string  id);
        public Task<int> GetCount();

        public Task<List<TDto>> GetAllAsync(int page,int itemsPerPage);

        public Task<TInputDto> CreateAsync(TInputDto dto);

        public Task DeleteAsync(string id);

        public Task UpdateAsync(TDto dto);

        Task<bool> AnyAsync(Expression<Func<TDto, bool>> predicate);
    }
}
