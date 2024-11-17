using Microsoft.EntityFrameworkCore;
using Providers_API.BLL.Definitions;
using Providers_API.BLL.Implementations;
using Providers_API.DAL.DBContext;
using Providers_API.DAL.Definitions;
using Providers_API.DAL.Implementations;
using System.Runtime.CompilerServices;

namespace Providers_API.IOC
{
    public static class Dependencies
    {
        public static void InjectionDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProvidersPlatformContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultDB"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
