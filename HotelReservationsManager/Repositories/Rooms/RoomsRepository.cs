using AutoMapper;
using HotelReservationsManager.Data;
using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos;
using System.Linq.Expressions;

namespace HotelReservationsManager.Repositories.Rooms
{
    public class RoomsRepository : BaseRepository<RoomDto, Room,InputRoomDto>, IRoomsRepository
    {
        public RoomsRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public int GetFreeRoomsCount()
        {
          return  _dbContext.Rooms.Where(r=>r.IsAvaible==true).Count();
        }
    }
}
