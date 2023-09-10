namespace HangfireApp
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetForecasts();
    }
}
