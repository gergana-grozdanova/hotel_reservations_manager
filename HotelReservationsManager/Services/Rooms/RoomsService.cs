using HotelReservationsManager.Data;
using HotelReservationsManager.Dtos;
using HotelReservationsManager.Repositories;
using HotelReservationsManager.Repositories.Rooms;

namespace HotelReservationsManager.Services.Rooms
{
    public class RoomsService : BaseService<RoomDto,InputRoomDto>, IRoomsService
    {
        private readonly IRoomsRepository _roomsRepository;
        public RoomsService(IRoomsRepository roomsRepository) : base(roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        public int GetFreeRoomsCount()
        {
           return _roomsRepository.GetFreeRoomsCount();
        }

    }
}
