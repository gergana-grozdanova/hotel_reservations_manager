using AutoMapper;
using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Dtos;

namespace HotelReservationsManager
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomDto, Room>();
            CreateMap<Room, RoomDto>();
            CreateMap<InputRoomDto, Room>();
            CreateMap<Room, InputRoomDto>();
        }
    }
}
