using NestQuestBackEnd.Domain.Models.Dtos;
using NestQuestBackEnd.Domain.Models.Entities;
using NestQuestBackEnd.Domain.Models.ResponseWrapper;

namespace NestQuestBackEnd.Domain.Models.Contracts
{
    public interface IHouseToRentService
    {
        Task<IEnumerable<Property>> GetAvailableHouses();
        Task<IEnumerable<Property>> FilterHouses(HouseSearchParameterDto filters);
        //Task<ResponseWrapper<string>> AddHouseToFavorites(int houseId);
        //Task<ResponseWrapper<string>> ContactOwnerForInquiry(int houseId, ContactInfoDto contactInfo);
    }
}
