using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos;
using HotelReservationsManager.Dtos.Reservations;
using HotelReservationsManager.Dtos.Rooms;
using HotelReservationsManager.Repositories;
using HotelReservationsManager.Repositories.Clients;
using HotelReservationsManager.Repositories.Reservations;

namespace HotelReservationsManager.Services.Reservations
{
    public class ReservationService : BaseService<ReservationDto, InputReservationDto>, IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository reservationRepository) : base(reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Task<ReservationDto> CreateAsync(InputReservationDto inputReservationDto, RoomDto room, ApplicationUser applicationUser)
        {
          return  _reservationRepository.CreateAsync(inputReservationDto, room, applicationUser);
        }

       
    }
}
