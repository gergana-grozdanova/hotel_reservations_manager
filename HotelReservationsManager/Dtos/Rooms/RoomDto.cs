namespace HotelReservationsManager.Dtos.Rooms
{
    public class RoomDto:BaseDto
    {
        public int Capacity { get; set; }
        public string Type { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal ChildPrice { get; set; }
        public int Number { get; set; }
        public bool IsAvaible { get; set; }
    }
}
