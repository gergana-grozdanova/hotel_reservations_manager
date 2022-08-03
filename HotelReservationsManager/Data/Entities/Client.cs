

namespace HotelReservationsManager.Data.Entities
{
    public partial class Client:BaseEntity
    {
      //  public string  Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public bool? IsAdult { get; set; }
        public string ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public Client()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
