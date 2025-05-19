using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;
using Weather.Api.Settings;
using Weather.DataAccessLayer;
using Weather.DataAccessLayer.Repositories;
using Weather.ExternalServices.Wrapper;

var builder = WebApplication.CreateBuilder(args);

// Add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Registering mediater for CQRS
builder.Services.AddMediatR(cfg => cfg.AsScoped(), Assembly.GetExecutingAssembly());

//builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registering IMemorey cache.
builder.Services.AddMemoryCache();

// Registering DbContext
builder.Services.AddDbContext<WeatherDbContext>(options =>
{
    // setting connection string for sqlite.
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectionString"));
});

// Adding http clients
builder.Services.AddHttpClient<IWrapperApiService, WrapperApiService>("CityApi", c =>
{
    var cityApiSettings = new CityApiSettings();
    builder.Configuration.GetRequiredSection(nameof(CityApiSettings)).Bind(cityApiSettings);
    c.BaseAddress = new Uri(cityApiSettings.ApiUrl);
});

builder.Services.AddHttpClient("WeatherApi", c => 
{
    var weatherApiSettings = new WeatherApiSettings();
    builder.Configuration.GetRequiredSection(nameof(WeatherApiSettings)).Bind(weatherApiSettings);
    c.BaseAddress = new Uri(weatherApiSettings.ApiUrl);
});

// Registering city repository.
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IWeatherDataRepository, WeatherDataRepository>();
builder.Services.AddScoped<IWrapperApiService, WrapperApiService>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
