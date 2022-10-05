using Microsoft.Extensions.DependencyInjection;
using Noa.PocketUi.Main.Configuration;
using Noa.PocketUI.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noa.PocketUI.Main.Configuration
{
    public static class ConfigureClients
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<ILocationClient, LocationClient>().ConfigureHttpClient((serviceProvider, httpClient) =>
            {
                httpClient.BaseAddress = new Uri(PocketUIConfiguration.LocationServiceURL);
                httpClient.Timeout = TimeSpan.FromMilliseconds(PocketUIConfiguration.RequestTimeout);
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            return serviceCollection;
        }
    }
}
