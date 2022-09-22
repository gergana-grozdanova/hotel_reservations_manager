

using System.Collections.Generic;

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
       // public virtual ICollection<ClientReservation> ClientReservations { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

        public Client()
        {
            this.Id = Guid.NewGuid().ToString();
          // this.ClientReservations = new HashSet<ClientReservation>();
          this.Reservations=new HashSet<Reservation>();
        }
    }
}
