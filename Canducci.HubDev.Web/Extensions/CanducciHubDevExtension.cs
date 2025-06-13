using Microsoft.Extensions.DependencyInjection;
using System;
namespace Canducci.HubDev.Web.Extensions
{
    public static class CanducciHubDevExtension
    {
        /// <summary>
        /// Adds the Canducci Hub Dev services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <remarks>This method registers the following services in the dependency injection container:
        /// <list type="bullet"> <item><description><see cref="HubDev"/> initialized with the provided <paramref
        /// name="token"/>.</description></item> <item><description><see cref="CnpjSearch"/> for CNPJ-related
        /// searches.</description></item> <item><description><see cref="CpfSearch"/> for CPF-related
        /// searches.</description></item> <item><description><see cref="ZipSearch"/> for ZIP code-related
        /// searches.</description></item> </list></remarks>
        /// <param name="services">The <see cref="IServiceCollection"/> to which the services will be added.</param>
        /// <param name="token">The authentication token required to initialize the Canducci Hub Dev services.  Cannot be null or empty.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="token"/> is null or empty.</exception>
        public static IServiceCollection AddCanducciHubDev(this IServiceCollection services, string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException($"'{nameof(token)}' cannot be null or empty.", nameof(token));
            }
            services.AddScoped(hubDev => new HubDev(token));
            services.AddScoped<BalanceSearch>();
            services.AddScoped<CnpjSearch>();
            services.AddScoped<CpfSearch>();
            services.AddScoped<ZipSearch>();
            return services;
        }

        /// <summary>
        /// Adds the Canducci Hub Dev service to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <remarks>This method registers the necessary dependencies for the Canducci Hub Dev service,
        /// including the  <see cref="IHubDevService"/> implementation. Call this method during application startup to
        /// ensure  the service is properly configured.</remarks>
        /// <param name="services">The <see cref="IServiceCollection"/> to which the service will be added.</param>
        /// <param name="token">The authentication token required to configure the Canducci Hub Dev service. Cannot be null or empty.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddCanducciHubDevService(this IServiceCollection services, string token)
        {
            services.AddCanducciHubDev(token);
            services.AddScoped<IHubDevService, HubDevService>();
            return services;
        }
    }
}
