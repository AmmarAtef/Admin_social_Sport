using Api.Dto.CountryDto;
using AutoMapper;
using Sports_Admin_Core.Entities;

namespace Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
        }
    }
}
