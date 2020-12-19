using Microsoft.EntityFrameworkCore.Migrations;

namespace Roofcare_APIs.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAcceptance",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PaidStatus",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ProblemImage",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CustomerAcceptance",
                table: "Bookings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PaidStatus",
                table: "Bookings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProblemImage",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
