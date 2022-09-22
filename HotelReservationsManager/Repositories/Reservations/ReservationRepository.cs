using AutoMapper;
using HotelReservationsManager.Data;
using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos;
using HotelReservationsManager.Dtos.Reservations;
using HotelReservationsManager.Dtos.Rooms;
using HotelReservationsManager.Repositories.Clients;
using HotelReservationsManager.Repositories.Rooms;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationsManager.Repositories.Reservations
{
    public class ReservationRepository : BaseRepository<ReservationDto, Reservation, InputReservationDto>, IReservationRepository
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IRoomsRepository _roomsRepository;
        public  ReservationRepository(ApplicationDbContext dbContext, IMapper mapper, IClientsRepository clientsRepository, IRoomsRepository roomsRepository) : base(dbContext, mapper)
        {
            _clientsRepository = clientsRepository;
            _roomsRepository = roomsRepository;
        }
        //public async Task<List<ReservationDto>> GetAllPaginatedAsync(int page, int itemsPerPage)
        //{
        //    var all = await _dbContext.Reservations.Include(e => e.Clients).Include(e => e.Room).Include(e => e.User).OrderBy(i => i.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToListAsync();
        //    return all.Select(r=>_mapper.Map<ReservationDto>(r)).ToList();
        //}
        public async Task<ReservationDto> GetByIdAsync(string id)
        {
            var entity =await _dbContext.Reservations.Where(e => e.Id == id).Include(e => e.Clients).Include(e => e.Room).Include(e => e.User).FirstAsync();
           return  _mapper.Map<ReservationDto>(entity);
        }
        public async Task<ReservationDto> CreateAsync(InputReservationDto inputReservationDto,RoomDto room,ApplicationUser applicationUser)
        {
            room.IsAvaible = false;
            await _roomsRepository.UpdateAsync(room);
            int adults = inputReservationDto.Clients.Where(c => c.IsAdult).Count();
            int childs = inputReservationDto.Clients.Count() - adults;
            int nights = (int)(inputReservationDto.LeavingDate - inputReservationDto.AccommodationDate).TotalDays;
            inputReservationDto.Bill = (decimal)(room.AdultPrice * adults + room.ChildPrice * childs) * nights;
            inputReservationDto.RoomId = room.Id;
            inputReservationDto.UserId = applicationUser.Id;
            
            var reservation = this.CreateAsync(inputReservationDto).GetAwaiter().GetResult();

            //foreach (var cl in inputReservationDto.Clients)
            //{
            //    var currClient = _clientsRepository.GetByEmailAndPhone(cl.Email, cl.PhoneNumber);
            //    if (currClient == null)
            //    {
            //        currClient = _clientsRepository.CreateAsync(cl).GetAwaiter().GetResult();
            //    }
            //    currClient.Reservations.Add(_mapper.Map<Reservation>( reservation));
            //    reservation.Clients.Add(currClient);
            //    //var clientReservation = new ClientReservation()
            //    //{
            //    //    ClientId = currClient.Id,
            //    //    ReservationId = reservation.Id

            //    //};
            //    //await _dbContext.ClientsReservations.AddAsync(clientReservation);

               

            //    await _dbContext.SaveChangesAsync();

            //}
            return reservation;
        }
    }
}
