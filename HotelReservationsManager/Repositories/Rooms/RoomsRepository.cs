using AutoMapper;
using HotelReservationsManager.Data;
using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos;
using HotelReservationsManager.Dtos.Rooms;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelReservationsManager.Repositories.Rooms
{
    public class RoomsRepository : BaseRepository<RoomDto, Room,InputRoomDto>, IRoomsRepository
    {
        private readonly IMapper _mapper;
        public RoomsRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _mapper = mapper;
        }

        public  async Task<List<RoomDto>> GetFreeRoomsAsync(int page,int itemsPerPage)
        {
            var rooms= await _dbContext.Rooms.Where(r => r.IsAvaible == true).OrderBy(r=>r.Number).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToListAsync();
            return  rooms.Select(r=>_mapper.Map<RoomDto>(r)).ToList();
        }

        public int GetFreeRoomsCount()
        {
          return  _dbContext.Rooms.Where(r=>r.IsAvaible==true).Count();
        }
    }
}
