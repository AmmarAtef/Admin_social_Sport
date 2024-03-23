using Api.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sports_Admin_Core.IRepositories.Users_Clubs;

namespace Api.Controllers
{
    public class CountryController : BaseApiController
    {
        private readonly IUserFavoriteClubUnitOfWork _favoriteClubRepository;
        private IMapper _mapper;
        public CountryController(IUserFavoriteClubUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _favoriteClubRepository = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CountryDto>))]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<CountryDto>>(_favoriteClubRepository.countryRepository.GetAll()));
        }
    }
}
