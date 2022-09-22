using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos;
using HotelReservationsManager.Dtos.Reservations;
using HotelReservationsManager.Dtos.Rooms;

namespace HotelReservationsManager.Services.Reservations
{
    public interface IReservationService:IBaseService<ReservationDto,InputReservationDto>
    {
        public Task<ReservationDto> CreateAsync(InputReservationDto inputReservationDto, RoomDto room, ApplicationUser applicationUser);
    }
}
