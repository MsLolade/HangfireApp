using System.Net.Mail;
using System.Net;

namespace HangfireApp
{
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
       {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public WeatherService()
        {

        }
        public IEnumerable<WeatherForecast> GetForecasts()
        {
            var weather = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();
            var mailBody = $"Temparatute in celsius for {string.Join(',', weather.Select(v => v.Date))} is \n {string.Join(',', weather.Select(v => v.TemperatureC))} respectively";
            
            return weather;
        }
    }
}
