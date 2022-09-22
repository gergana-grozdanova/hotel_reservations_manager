using HotelReservationsManager.Dtos;
using HotelReservationsManager.Dtos.Rooms;

namespace HotelReservationsManager.Models
{
    public class AllRoomsViewModel:PaggingViewModel
    {       
        public List<RoomDto> Rooms { get; set; }
        
    }
}
