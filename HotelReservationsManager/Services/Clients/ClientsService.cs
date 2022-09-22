using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos.Clients;
using HotelReservationsManager.Repositories;
using HotelReservationsManager.Repositories.Clients;

namespace HotelReservationsManager.Services.Clients
{
    public class ClientsService : BaseService<ClientDto, InputClientDto>, IClientsService
    {
        private readonly IClientsRepository _clientsRepository;
        public ClientsService(IClientsRepository clientsRepository) : base(clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public ClientDto GetByEmailAndPhone(string email, string phone)
        {
          return  _clientsRepository.GetByEmailAndPhone(email, phone);
        }
    }
}
