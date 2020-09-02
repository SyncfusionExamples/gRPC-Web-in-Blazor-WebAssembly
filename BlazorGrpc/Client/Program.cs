using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components;
using Grpc.Net.Client;
using BlazorGrpc.Shared;

namespace BlazorGrpc.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton(services =>
            {
                var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
                var backendUrl = services.GetRequiredService<NavigationManager>().BaseUri;
                var channel = GrpcChannel.ForAddress(backendUrl, new GrpcChannelOptions { HttpClient = httpClient });

                return new WeatherForecastService.WeatherForecastServiceClient(channel);
            });

            await builder.Build().RunAsync();
        }
    }
}
