using Microsoft.AspNetCore.Mvc;
using NestQuestBackEnd.Domain.Models.Contracts;
using NestQuestBackEnd.Domain.Models.Dtos;
using NestQuestBackEnd.Domain.Models.Entities;
using NestQuestBackEnd.Domain.Models.ResponseWrapper;

namespace NestQuestBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseToRentController : ControllerBase
    {
        private readonly IHouseToRentService _houseToRentservice;
        public HouseToRentController(IHouseToRentService houseToRentService)
        {
            _houseToRentservice = houseToRentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetHousesToRent()
        {
            try
            {
                var res = await _houseToRentservice.GetAvailableHouses();
                return Ok(res);

            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<ActionResult<ResponseWrapper<IEnumerable<Property>>>> FilterHouse(HouseSearchParameterDto houseSearchParameterDto)
        {
            try
            {
                var response = new ResponseWrapper<IEnumerable<Property>>();

                var properties = await _houseToRentservice.FilterHouses(houseSearchParameterDto);

                if (properties.Count() > 0)
                {
                    response.Data = properties;
                    response.SuccessMessage = "Filtered Propperties";
                    response.IsSuccess = true;

                }
                else
                {
                    response.Data = properties;
                    response.ErrorMessage = "No Result Found";
                    response.IsSuccess = false;
                }
                return response;
            }
            catch
            {
                throw;

            }
        }

    }
}
