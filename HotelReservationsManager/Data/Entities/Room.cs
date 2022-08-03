

namespace HotelReservationsManager.Data.Entities
{
    public partial class Room:BaseEntity
    {
        public int? Capacity { get; set; }
        public string? Type { get; set; }
        public bool? IsAvaible { get; set; }
        public decimal? AdultPrice { get; set; }
        public decimal? ChildPrice { get; set; }
        public int? Number { get; set; }
        
        public Room()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
