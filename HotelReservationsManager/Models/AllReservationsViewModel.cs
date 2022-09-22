using HotelReservationsManager.Dtos.Reservations;

namespace HotelReservationsManager.Models
{
    public class AllReservationsViewModel:PaggingViewModel
    {
        public List<ReservationDto> Reservations { get; set; }
    }
}
