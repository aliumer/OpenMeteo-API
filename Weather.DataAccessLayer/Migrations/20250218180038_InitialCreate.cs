using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Weather.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<string>(type: "text", nullable: false),
                    Elevation = table.Column<string>(type: "text", nullable: false),
                    Feature_code = table.Column<string>(type: "text", nullable: false),
                    Country_code = table.Column<string>(type: "text", nullable: false),
                    Admin1_id = table.Column<int>(type: "integer", nullable: false),
                    Admin2_id = table.Column<int>(type: "integer", nullable: false),
                    Admin3_id = table.Column<int>(type: "integer", nullable: false),
                    Timezone = table.Column<string>(type: "text", nullable: false),
                    Population = table.Column<int>(type: "integer", nullable: false),
                    Postcodes = table.Column<int[]>(type: "integer[]", nullable: false),
                    Country_id = table.Column<int>(type: "integer", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Admin1 = table.Column<string>(type: "text", nullable: false),
                    Admin2 = table.Column<string>(type: "text", nullable: false),
                    Admin3 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    latitude = table.Column<double>(type: "double precision", nullable: false),
                    longitude = table.Column<double>(type: "double precision", nullable: false),
                    generationtime_ms = table.Column<double>(type: "double precision", nullable: false),
                    utc_offset_seconds = table.Column<int>(type: "integer", nullable: false),
                    timezone = table.Column<string>(type: "text", nullable: false),
                    timezone_abbreviation = table.Column<string>(type: "text", nullable: false),
                    elevation = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    weatherId = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<List<int>>(type: "integer[]", nullable: false),
                    rain_sum = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    weather_code = table.Column<List<int>>(type: "integer[]", nullable: false),
                    temperature_10m_max = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    temperature_10m_min = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    wind_speed_10m_max = table.Column<List<double>>(type: "double precision[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyData_WeatherData_weatherId",
                        column: x => x.weatherId,
                        principalTable: "WeatherData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    weatherId = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<string>(type: "text", nullable: false),
                    weather_code = table.Column<string>(type: "text", nullable: false),
                    temperature_2m_max = table.Column<string>(type: "text", nullable: false),
                    temperature_2m_min = table.Column<string>(type: "text", nullable: false),
                    rain_sum = table.Column<string>(type: "text", nullable: false),
                    wind_speed_10m_max = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyUnits_WeatherData_weatherId",
                        column: x => x.weatherId,
                        principalTable: "WeatherData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HourlyData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    weatherId = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<List<int>>(type: "integer[]", nullable: false),
                    rain = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    weather_code = table.Column<List<int>>(type: "integer[]", nullable: false),
                    wind_speed_180m = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    temperature_180m = table.Column<List<double>>(type: "double precision[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourlyData_WeatherData_weatherId",
                        column: x => x.weatherId,
                        principalTable: "WeatherData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HourlyUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    weatherId = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<string>(type: "text", nullable: false),
                    rain = table.Column<string>(type: "text", nullable: false),
                    weather_code = table.Column<string>(type: "text", nullable: false),
                    wind_speed_180m = table.Column<string>(type: "text", nullable: false),
                    temperature_180m = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourlyUnits_WeatherData_weatherId",
                        column: x => x.weatherId,
                        principalTable: "WeatherData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyData_weatherId",
                table: "DailyData",
                column: "weatherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyUnits_weatherId",
                table: "DailyUnits",
                column: "weatherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HourlyData_weatherId",
                table: "HourlyData",
                column: "weatherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HourlyUnits_weatherId",
                table: "HourlyUnits",
                column: "weatherId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "DailyData");

            migrationBuilder.DropTable(
                name: "DailyUnits");

            migrationBuilder.DropTable(
                name: "HourlyData");

            migrationBuilder.DropTable(
                name: "HourlyUnits");

            migrationBuilder.DropTable(
                name: "WeatherData");
        }
    }
}
