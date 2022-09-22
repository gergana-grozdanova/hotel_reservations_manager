using HotelReservationsManager.Data.Entities;

namespace HotelReservationsManager.Dtos.Clients
{
    public class ClientDto:BaseDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsAdult { get; set; }
        //public ICollection<Reservation> Reservations { get; set; }

        //public ClientDto()
        //{
        //    Reservations=new HashSet<Reservation>();
        //}
    }
}
