using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Roofcare_APIs.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_BookingToId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookingToId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingToId",
                table: "Bookings");

            migrationBuilder.AlterColumn<double>(
                name: "TravellingCost",
                table: "Bookings",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCharge",
                table: "Bookings",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "ServiceCharge",
                table: "Bookings",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "PaidStatus",
                table: "Bookings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssuedDate",
                table: "Bookings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "DiscountPercentage",
                table: "Bookings",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "CustomerAcceptance",
                table: "Bookings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "BookingToUserId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingToUserId",
                table: "Bookings",
                column: "BookingToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_BookingToUserId",
                table: "Bookings",
                column: "BookingToUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_BookingToUserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookingToUserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingToUserId",
                table: "Bookings");

            migrationBuilder.AlterColumn<double>(
                name: "TravellingCost",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalCharge",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ServiceCharge",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PaidStatus",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssuedDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DiscountPercentage",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CustomerAcceptance",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingToId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingToId",
                table: "Bookings",
                column: "BookingToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_BookingToId",
                table: "Bookings",
                column: "BookingToId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
