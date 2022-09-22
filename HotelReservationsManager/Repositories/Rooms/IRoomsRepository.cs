using HotelReservationsManager.Dtos;
using HotelReservationsManager.Dtos.Rooms;

namespace HotelReservationsManager.Repositories.Rooms
{
    public interface IRoomsRepository:IBaseRepository<RoomDto,InputRoomDto>
    {
        int GetFreeRoomsCount();
        Task<List<RoomDto>> GetFreeRoomsAsync(int page, int itemsPerPage);
    }
}
