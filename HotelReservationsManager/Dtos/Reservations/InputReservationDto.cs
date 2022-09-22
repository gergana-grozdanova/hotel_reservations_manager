using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos.Clients;

namespace HotelReservationsManager.Dtos.Reservations
{
    public class InputReservationDto:InputDto
    {
        public string? RoomId { get; set; }
        public string? UserId { get; set; }
        public DateTime AccommodationDate { get; set; }
        public DateTime LeavingDate { get; set; }
        public bool IsBreakfastIncluded { get; set; }
        public bool IsAllInclusive { get; set; }
        public decimal Bill { get; set; }
        public InputClientDto[] Clients { get; set; }

    }
}
