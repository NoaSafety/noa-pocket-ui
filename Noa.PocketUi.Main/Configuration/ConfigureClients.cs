using Microsoft.Extensions.DependencyInjection;
using Noa.PocketUi.Main.Configuration;
using Noa.PocketUI.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Noa.PocketUI.Main.Configuration
{
    public static class ConfigureClients
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<ISectorClient, SectorClient>().ConfigureHttpClient((serviceProvider, httpClient) =>
            {
                httpClient.BaseAddress = new Uri(NOAConfiguration.SectorServiceURL);
                httpClient.Timeout = TimeSpan.FromMilliseconds(NOAConfiguration.RequestTimeout);
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            serviceCollection.AddHttpClient<IAuthenticationClient, AuthenticationClient>().ConfigureHttpClient((serviceProvider, httpClient) =>
            {
                httpClient.BaseAddress = new Uri(NOAConfiguration.AuthenticationServiceURL);
                httpClient.Timeout = TimeSpan.FromMilliseconds(NOAConfiguration.RequestTimeout);
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            return serviceCollection;
        }
    }
}
