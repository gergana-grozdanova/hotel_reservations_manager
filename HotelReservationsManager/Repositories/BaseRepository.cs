using AutoMapper;
using HotelReservationsManager.Data;
using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelReservationsManager.Repositories
{
    public class BaseRepository<TDto, TEntity, TInputDto> : IBaseRepository<TDto, TInputDto>
        where TDto : BaseDto
        where TEntity : BaseEntity
        where TInputDto : InputDto
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> entities;

        protected BaseRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            entities = dbContext.Set<TEntity>();
        }

        public async Task<TDto> CreateAsync(TInputDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);

            await entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }

        public async Task<List<TInputDto>> AddRange(List<TInputDto> dtos)
        {
            List<TEntity> range =dtos.Select(dto=> _mapper.Map<TEntity>(dto)).ToList();

            await entities.AddRangeAsync(range);
            await _dbContext.SaveChangesAsync();

            return range.Select(entity => _mapper.Map<TInputDto>(entity)).ToList();

        }
           


        public async Task<TDto> GetByIdAsync(string id)
        {
            TEntity entity = await entities
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            var dto = _mapper.Map<TDto>(entity);

            return dto;
        }

        public async Task<List<TDto>> GetAllPaginatedAsync(int page,int itemsPerPage)
        {
            //var query = entities.AsQueryable();

            //if (filter != null)
            //{
            //    var filterDb = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);
            //    query = query.Where(filterDb);
            //}

            //var count = await query.CountAsync();
            //query = query.OrderBy(entity => entity.Id)
            //             .Skip(offset)
            //             .Take(limit);

          
           return await _mapper.ProjectTo<TDto>(entities).OrderBy(i=>i.Id).Skip((page-1)*itemsPerPage).Take(itemsPerPage).ToListAsync();
            //return new PaginationResultDto<TDto>
            //{
            //    Result = result,
            //    TotalCount = count
            //};
        }

        public async Task UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            TEntity entity = await entities
               .FirstOrDefaultAsync(e => e.Id == id);

            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<TDto, bool>> predicate)
        {
            return await entities.AnyAsync(_mapper.Map<Expression<Func<TEntity, bool>>>(predicate));
        }

        public async Task<int> GetCount()
        {
            return await entities.CountAsync();
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            return await _mapper.ProjectTo<TDto>(entities).ToListAsync();
        }
    }
}
