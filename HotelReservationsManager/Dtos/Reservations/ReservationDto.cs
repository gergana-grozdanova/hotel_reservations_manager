using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos.Clients;
using HotelReservationsManager.Dtos.Rooms;

namespace HotelReservationsManager.Dtos.Reservations
{
    public class ReservationDto:BaseDto
    {
        public RoomDto Room { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime AccommodationDate { get; set; }
        public DateTime LeavingDate { get; set; }
        public bool IsBreakfastIncluded { get; set; }
        public bool IsAllInclusive { get; set; }
        public decimal Bill { get; set; }
        public virtual List<ClientDto> Clients { get; set; }

       
    }
}
