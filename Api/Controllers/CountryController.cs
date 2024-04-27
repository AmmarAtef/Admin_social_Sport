using Api.Dto;
using Api.Dto.CountryDto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sports_Admin_Core.Entities;
using Sports_Admin_Core.Entities.Dto;
using Sports_Admin_Core.UnitOfWorks;

namespace Api.Controllers
{
    public class CountryController : BaseApiController
    {
        private readonly IUserFavoriteClubUnitOfWork _userFavoriteClubUnitOfWork;
        private IMapper _mapper;
        public CountryController(IUserFavoriteClubUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userFavoriteClubUnitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponseStronglyTyped<IEnumerable<CountryDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ServiceResponseStronglyTyped<IEnumerable<CountryDto>>))]
        public async Task<ActionResult<ServiceResponseStronglyTyped<IEnumerable<CountryDto>>>> GetAll([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            if (_userFavoriteClubUnitOfWork.CountryRepository.GetAll().ToList().Count != 0)
            {
                return this.HandleServiceResponse<IEnumerable<CountryDto>>(ServiceResponseStronglyTyped<IEnumerable<CountryDto>>.TypedSuccess(_mapper.Map<IEnumerable<CountryDto>>(_userFavoriteClubUnitOfWork.CountryRepository.GetAll())));
            }
            else
            {
                var error = new Error { Code = "404", ErrorData = "error in retrive Data" };
                var failresponse = ServiceResponseStronglyTyped<IEnumerable<CountryDto>>.Fail(error);
                return this.HandleServiceResponse<IEnumerable<CountryDto>>(failresponse);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponseStronglyTyped<CountryDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ServiceResponseStronglyTyped<CountryDto>))]
        public async Task<ActionResult<ServiceResponseStronglyTyped<CountryDto>>> AddCountry([FromBody] CountryDto countryDto)
        {
            var country = await _userFavoriteClubUnitOfWork.CountryRepository.CreateOneAsync(_mapper.Map<Country>(countryDto));

            if (country == null)
            {
                var error = new Error { Code = "404", ErrorData = "error in retrive Data" };
                var failresponse = ServiceResponseStronglyTyped<CountryDto>.Fail(error);
                return this.HandleServiceResponse<CountryDto>(failresponse);
            }
            else
            {
                return this.HandleServiceResponse<CountryDto>(ServiceResponseStronglyTyped<CountryDto>.TypedSuccess(_mapper.Map<CountryDto>(country)));
            }
        }

    }
}
