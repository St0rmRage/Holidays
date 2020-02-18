using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace App.Client.Background.Service
{
    /// <summary>
    /// Extensions for hosting lifetime
    /// </summary>
    public static class ServiceBaseLifetimeHostExtensions
    {
        /// <summary>
        /// Lifetime configuration
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IHostBuilder UseServiceBaseLifetime(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((hostContext, services) => services.AddSingleton<IHostLifetime, ServiceBaseLifetime>());
        }

        /// <summary>
        /// Extension for running as windows service
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task RunAsServiceAsync(this IHostBuilder hostBuilder, CancellationToken cancellationToken = default(CancellationToken))
        {
            return hostBuilder.UseServiceBaseLifetime().Build().RunAsync(cancellationToken);
        }
    }
}