using HotelReservationsManager.Dtos.Clients;

namespace HotelReservationsManager.Services.Clients
{
    public interface IClientsService : IBaseService<ClientDto,InputClientDto>
    {
        public ClientDto GetByEmailAndPhone(string email, string phone);
    }
}
