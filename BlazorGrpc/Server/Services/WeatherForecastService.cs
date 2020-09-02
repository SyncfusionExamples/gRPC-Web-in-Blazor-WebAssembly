using BlazorGrpc.Shared;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGrpc.Server
{
    public class WeatherForecastService : BlazorGrpc.Shared.WeatherForecastService.WeatherForecastServiceBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public override Task<WeatherForecastResponse> GetWeatherForecast(Empty request, ServerCallContext context)
        {
            var response = new WeatherForecastResponse();

            response.Forecasts.AddRange(GetWeatherForecast());

            return Task.FromResult<WeatherForecastResponse>(response);
        }

        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            var rng = new Random();
            return Enumerable.Range(1, 365).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
    }
}
