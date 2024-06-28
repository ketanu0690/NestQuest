using NestQuestBackEnd.Domain.Models.Contracts;
using NestQuestBackEnd.Domain.Models.Dtos;
using NestQuestBackEnd.Domain.Models.Entities;
using NestQuestBackEnd.Domain.Models.ResponseWrapper;

namespace NestQuestBackEnd.Services
{
    public class HouseToRentServices : IHouseToRentService
    {
        private readonly IPropertyRepository _propertyRepository;

        public HouseToRentServices(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<IEnumerable<Property>> GetAvailableHouses()
        {
            try
            {
                var properties = await _propertyRepository.GetAllAsync();
                return properties;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Property>> FilterHouses(HouseSearchParameterDto filters)
        {
            try
            {
                var properties = await _propertyRepository.GetAllAsync();
                var filteredProperties = properties.Where(p =>
                    (string.IsNullOrEmpty(filters.City) || p.City == filters.City) &&
                    (filters.MinPrice == 0 || p.Price >= filters.MinPrice) && 
                    (filters.MaxPrice == 0 || p.Price <= filters.MaxPrice) && 
                    (string.IsNullOrEmpty(filters.Country) || p.Country == filters.Country) && 
                    (filters.MinBedrooms == 0 || p.Bedrooms >= filters.MinBedrooms) &&
                    (filters.MinBathrooms == 0 || p.Bathrooms >= filters.MinBathrooms) &&
                    (!filters.Furnished.HasValue || p.Furnished == filters.Furnished));

                return filteredProperties.ToList();
            }
            catch
            {
                throw;
            }
        }


        //public async Task<ResponseWrapper<string>> AddHouseToFavorites(int userId ,int propertyId)
        //{
        //    try
        //    {

        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        //public async Task<ResponseWrapper<string>> ContactOwnerForInquiry(int houseId, ContactInfoDto contactInfo)
        //{
        //    try
        //    {

        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


    }
}
