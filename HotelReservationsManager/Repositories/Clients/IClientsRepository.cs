using HotelReservationsManager.Dtos.Clients;

namespace HotelReservationsManager.Repositories.Clients
{
    public interface IClientsRepository:IBaseRepository<ClientDto,InputClientDto>
    {
        public ClientDto GetByEmailAndPhone(string email, string phone);
    }
}
