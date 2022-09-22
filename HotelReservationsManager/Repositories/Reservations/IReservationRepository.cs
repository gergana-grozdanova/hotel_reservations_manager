using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos;
using HotelReservationsManager.Dtos.Reservations;
using HotelReservationsManager.Dtos.Rooms;

namespace HotelReservationsManager.Repositories.Reservations
{
    public interface IReservationRepository:IBaseRepository<ReservationDto,InputReservationDto>
    {
        public Task<ReservationDto> CreateAsync(InputReservationDto inputReservationDto, RoomDto room, ApplicationUser applicationUser);
    }
}
