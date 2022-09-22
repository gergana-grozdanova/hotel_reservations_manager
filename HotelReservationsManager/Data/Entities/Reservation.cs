

using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationsManager.Data.Entities
{
    public class Reservation:BaseEntity
    {
        [ForeignKey("Room")]
        public string RoomId { get; set; }
        public Room Room { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime AccommodationDate { get; set; }
        public DateTime LeavingDate { get; set; }
        public bool IsBreakfastIncluded { get; set; }
        public bool IsAllInclusive { get; set; }
        public decimal Bill { get; set; }
       // public virtual ICollection<ClientReservation> ClientsReservation { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();
            //this.ClientsReservation=new HashSet<ClientReservation>();
            this.Clients = new HashSet<Client>();
        }
    }
}
