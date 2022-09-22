using AutoMapper;
using HotelReservationsManager.Data;
using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos.Clients;

namespace HotelReservationsManager.Repositories.Clients
{
    public class ClientsRepository : BaseRepository<ClientDto, Client, InputClientDto>, IClientsRepository
    {
        public  ClientsRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public ClientDto GetByEmailAndPhone(string email,string phone)
        {
            var client = _dbContext.Clients.Where(x => x.Email == email && x.PhoneNumber == phone).FirstOrDefault();
            return _mapper.Map<ClientDto>(client) ;
        }
    }
}
