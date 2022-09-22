namespace HotelReservationsManager.Dtos.Clients
{
    public class InputClientDto:InputDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsAdult { get; set; }
    }
}
