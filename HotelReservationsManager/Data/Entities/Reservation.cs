

namespace HotelReservationsManager.Data.Entities
{
    public class Reservation:BaseEntity
    {
      //  public string Id { get; set; }
        public Room Room { get; set; }  
        public ApplicationUser User { get; set; }
        public DateTime AccommodationDate { get; set; }
        public DateTime LeavingDate { get; set; }
        public bool IsBreakfastIncluded { get; set; }
        public bool IsAllInclusive { get; set; }
        public decimal Bill { get; set; }
        public ICollection<Client> Clients { get; set; }

        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Clients=new HashSet<Client>();
        }
    }
}
