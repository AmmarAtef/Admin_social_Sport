using Infra.Data_Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;



namespace Api.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdminSportsContext>(
                opts => opts.UseSqlServer
                    (configuration.GetConnectionString("AdminSports"),
                        b => b.MigrationsAssembly("Infra"))
                    .EnableDetailedErrors());
        }
    }
}
