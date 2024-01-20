using AutoMapper;
using HotelManagement.DTO.Auths;
using HotelManagement.DTO.Controls;
using HotelManagement.Models;

namespace HotelManagement.MapperProfile
{
    public class AutoMapperProfile:Profile
    {
        //CreateMap<>();
       public AutoMapperProfile() { 
        
        CreateMap<RegisterDTO, User>().ReverseMap();
        CreateMap<RoomDTO,Room>().ReverseMap();

        }
    }
}
