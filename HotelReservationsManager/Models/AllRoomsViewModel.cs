using HotelReservationsManager.Dtos;

namespace HotelReservationsManager.Models
{
    public class AllRoomsViewModel
    {
        public List<RoomDto> Rooms { get; set; }
        public int Count { get; set; }
    }
}
