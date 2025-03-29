using ContactManager.Services;
using ContactManager.Services.Interfaces;
using System.ComponentModel.Design;

namespace ContactManager
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();

            return services;
        }
    }
}
