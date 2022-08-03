using HotelReservationsManager.Dtos;

namespace HotelReservationsManager.Services.Rooms
{
    public interface IRoomsService:IBaseService<RoomDto,InputRoomDto>
    {
        int GetFreeRoomsCount();
    }
}
