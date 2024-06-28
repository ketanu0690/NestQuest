using Microsoft.Extensions.DependencyInjection;
using NestQuestBackEnd.DAL.Repositories;
using NestQuestBackEnd.Domain.Models.Contracts;

namespace NestQuestBackEnd.Services.RegisterService
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterInterfaceWithClass(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUsers, UserServices>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IHouseToRentService, HouseToRentServices>();
            return services;
        }
    }
}



