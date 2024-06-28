using Microsoft.EntityFrameworkCore;
using NestQuestBackEnd.DAL.DBContext;
using NestQuestBackEnd.Domain.Models.Contracts;
using NestQuestBackEnd.Domain.Models.Entities;

namespace NestQuestBackEnd.DAL.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DbServiceContext _dbContextServices;

        public PropertyRepository(DbServiceContext dbContextServices) {
        _dbContextServices = dbContextServices;
        }

        public async Task<List<Property>> GetAllAsync()
        {
            try
            {
                return  await _dbContextServices.Properties.ToListAsync();
            }
            catch
            {
                throw;
            }
        }


    }
}
