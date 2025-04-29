using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class columnnamechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "temperature_10m_min",
                table: "DailyData",
                newName: "temperature_2m_min");

            migrationBuilder.RenameColumn(
                name: "temperature_10m_max",
                table: "DailyData",
                newName: "temperature_2m_max");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "temperature_2m_min",
                table: "DailyData",
                newName: "temperature_10m_min");

            migrationBuilder.RenameColumn(
                name: "temperature_2m_max",
                table: "DailyData",
                newName: "temperature_10m_max");
        }
    }
}
