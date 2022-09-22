using AutoMapper;
using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos;
using HotelReservationsManager.Dtos.Clients;
using HotelReservationsManager.Dtos.Reservations;
using HotelReservationsManager.Dtos.Rooms;

namespace HotelReservationsManager
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomDto, Room>().ReverseMap();
            CreateMap<InputRoomDto, Room>().ReverseMap();

            CreateMap<ClientDto,Client>().ReverseMap();
            CreateMap<InputClientDto, Client>().ReverseMap();

            CreateMap<InputReservationDto, Reservation>().ReverseMap();
            CreateMap<ReservationDto, Reservation>();
            CreateMap<Reservation,ReservationDto>()
               .ForMember(dto => dto.Clients, opt => opt.MapFrom(x=>x.Clients))
               .ForMember(dto=>dto.User,opt=>opt.MapFrom(x=>x.User))
               .ForMember(dto=>dto.Room,opt=>opt.MapFrom(x=>x.Room));

        }
    }
}
