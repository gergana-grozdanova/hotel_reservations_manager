using HotelReservationsManager.Dtos;
using HotelReservationsManager.Dtos.Rooms;

namespace HotelReservationsManager.Services.Rooms
{
    public interface IRoomsService:IBaseService<RoomDto,InputRoomDto>
    {
        int GetFreeRoomsCount();
        Task<List<RoomDto>> GetFreeRoomsAsync(int page, int itemsPerPage);
    }
}
