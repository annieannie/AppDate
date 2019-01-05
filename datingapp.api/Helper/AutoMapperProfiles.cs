using System.Linq;
using AutoMapper;
using datingapp.api.Dtos;
using datingapp.api.Models;

namespace datingapp.api.Helper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForDetailsDto>()
            .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            }).ForMember(dest => dest.Age, opt => {
                opt.ResolveUsing(src => src.DateOfBirth.CalculateAge());
            });

            CreateMap<User,UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            }).ForMember(dest => dest.Age, opt => {
                opt.ResolveUsing(src => src.DateOfBirth.CalculateAge());
            });

              CreateMap<Photo,PhotoForDetailedDto>();
        }
        
    }
}