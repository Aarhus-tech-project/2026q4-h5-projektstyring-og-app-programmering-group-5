using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H5FlightApi.Migrations
{
    /// <inheritdoc />
    public partial class addTripTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Trips",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Trips");
        }
    }
}
