using HotelReservationsManager.Dtos.Clients;

namespace HotelReservationsManager.Models
{
    public class AllClientsViewModel:PaggingViewModel
    {
        public List<ClientDto> Clients { get; set; }
    }
}
