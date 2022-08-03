using HotelReservationsManager.Dtos;

namespace HotelReservationsManager.Repositories.Rooms
{
    public interface IRoomsRepository:IBaseRepository<RoomDto,InputRoomDto>
    {
        int GetFreeRoomsCount();
    }
}
