using NestQuestBackEnd.Domain.Models.Entities;

namespace NestQuestBackEnd.Domain.Models.Contracts
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetAllAsync();
    }
}
