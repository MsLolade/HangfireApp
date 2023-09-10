using Hangfire;
using HangfireApp;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddHangfire(options =>
{
    options.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseMaxArgumentSizeToRender(8192);
});

builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard("/hangfire");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


var weather = new WeatherService();
BackgroundJob.Enqueue(() => weather.GetForecasts());
RecurringJob.AddOrUpdate("Weather_Forecast_Job", () => weather.GetForecasts(), Cron.HourInterval(5));

app.Run();
