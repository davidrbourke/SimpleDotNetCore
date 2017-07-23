using Microsoft.Extensions.DependencyInjection;
using Simple.DAL;
using Simple.Models;

namespace Simple.Infrastructure
{
    public static class IoCExtensions
    {
        public static void RegisterIoCServices(this IServiceCollection services)
        {
            services.AddTransient<IRepository<User>, UserRepository>();
        }
    }
}