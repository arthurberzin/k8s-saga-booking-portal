using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updatebookingmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "HotelBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompleteRentDate",
                table: "HotelBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "HotelBookings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartRentDate",
                table: "HotelBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<string>(
                name: "ArrivalAirport",
                table: "FlightBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDateTime",
                table: "FlightBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<string>(
                name: "DepartureAirport",
                table: "FlightBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDateTime",
                table: "FlightBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "FlightBookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompleteRentDate",
                table: "CarBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CarBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "CarBookings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartRentDate",
                table: "CarBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "CompleteRentDate",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "StartRentDate",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "ArrivalAirport",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "ArrivalDateTime",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "DepartureAirport",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "DepartureDateTime",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "CompleteRentDate",
                table: "CarBookings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CarBookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CarBookings");

            migrationBuilder.DropColumn(
                name: "StartRentDate",
                table: "CarBookings");
        }
    }
}
