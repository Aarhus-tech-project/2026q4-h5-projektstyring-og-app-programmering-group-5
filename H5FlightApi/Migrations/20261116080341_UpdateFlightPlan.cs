using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H5FlightApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFlightPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Flights_FlightId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "Trips",
                newName: "FlightPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_FlightId",
                table: "Trips",
                newName: "IX_Trips_FlightPlanId");

            migrationBuilder.RenameColumn(
                name: "TripId",
                table: "Flights",
                newName: "FlightPlanId");

            migrationBuilder.AddColumn<string>(
                name: "Airline",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Airplane",
                table: "Flights",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArrivalAirportCode",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalAirportName",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalLocalTime",
                table: "Flights",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DepartureAirportCode",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartureAirportName",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureLocalTime",
                table: "Flights",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "Flights",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Flights",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Flights",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FlightPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TripId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    OutboundDuration = table.Column<int>(type: "integer", nullable: false),
                    ReturnDuration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPlans", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FlightPlanId",
                table: "Flights",
                column: "FlightPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_FlightPlans_FlightPlanId",
                table: "Flights",
                column: "FlightPlanId",
                principalTable: "FlightPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_FlightPlans_FlightPlanId",
                table: "Trips",
                column: "FlightPlanId",
                principalTable: "FlightPlans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_FlightPlans_FlightPlanId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_FlightPlans_FlightPlanId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "FlightPlans");

            migrationBuilder.DropIndex(
                name: "IX_Flights_FlightPlanId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Airline",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Airplane",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ArrivalAirportCode",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ArrivalAirportName",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ArrivalLocalTime",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureAirportCode",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureAirportName",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureLocalTime",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "FlightPlanId",
                table: "Trips",
                newName: "FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_FlightPlanId",
                table: "Trips",
                newName: "IX_Trips_FlightId");

            migrationBuilder.RenameColumn(
                name: "FlightPlanId",
                table: "Flights",
                newName: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Flights_FlightId",
                table: "Trips",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");
        }
    }
}
