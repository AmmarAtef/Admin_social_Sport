using Api.Helpers;
using Infra.Repositories.Sports;
using Sports_Admin_Core.UnitOfWorks;

namespace Api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServicesExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUserFavoriteClubUnitOfWork, UserFavoriteClubUnitOfWork>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services;
        }
    }
}
