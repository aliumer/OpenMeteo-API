using Microsoft.EntityFrameworkCore;
using Weather.Domain.Entities;

namespace Weather.DataAccessLayer
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options):base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherData> WeatherData { get; set; }
        public DbSet<Hourly> HourlyData { get; set; }
        public DbSet<HourlyUnits> HourlyUnits { get; set; }
        public DbSet<Daily> DailyData { get; set; }
        public DbSet<DailyUnits> DailyUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeatherDbContext).Assembly);

            modelBuilder.Entity<WeatherData>()
                    .HasOne(w => w.hourly)
                    .WithOne(h => h.WeatherData)
                    .HasForeignKey<Hourly>(h => h.weatherId)
                    .OnDelete(DeleteBehavior.Cascade);

            // Define one-to-one relationship: WeatherData -> HourlyUnits
            modelBuilder.Entity<WeatherData>()
                .HasOne(w => w.hourly_units)
                .WithOne(hu => hu.WeatherData)
                .HasForeignKey<HourlyUnits>(hu => hu.weatherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WeatherData>()
                .HasOne(w => w.daily)
                .WithOne(d => d.WeatherData)
                .HasForeignKey<Daily>(d => d.weatherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WeatherData>()
                .HasOne(w => w.daily_units)
                .WithOne(du => du.WeatherData)
                .HasForeignKey<DailyUnits>(du => du.weatherId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
