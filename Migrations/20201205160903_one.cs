using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Roofcare_APIs.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    ProfessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.ProfessionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingToId = table.Column<int>(type: "int", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProblemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProblemImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorAcceptance = table.Column<bool>(type: "bit", nullable: false),
                    CompletedStatus = table.Column<bool>(type: "bit", nullable: false),
                    ServiceCharge = table.Column<double>(type: "float", nullable: false),
                    TravellingCost = table.Column<double>(type: "float", nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    TotalCharge = table.Column<double>(type: "float", nullable: false),
                    CustomerAcceptance = table.Column<bool>(type: "bit", nullable: false),
                    PaidStatus = table.Column<bool>(type: "bit", nullable: false),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_BookingByUserId",
                        column: x => x.BookingByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_BookingToId",
                        column: x => x.BookingToId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserFavByUserId = table.Column<int>(type: "int", nullable: true),
                    UserFavToUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserFavByUserId",
                        column: x => x.UserFavByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserFavToUserId",
                        column: x => x.UserFavToUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    FeedbackDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeedbackByUserId = table.Column<int>(type: "int", nullable: true),
                    FeedbackToUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_FeedbackByUserId",
                        column: x => x.FeedbackByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_FeedbackToUserId",
                        column: x => x.FeedbackToUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfferDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offers_Users_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProfessions",
                columns: table => new
                {
                    UserProfessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ProfessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfessions", x => x.UserProfessionId);
                    table.ForeignKey(
                        name: "FK_UserProfessions_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "ProfessionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferReports_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferReports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SavedOffers",
                columns: table => new
                {
                    SavedOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedOffers", x => x.SavedOfferId);
                    table.ForeignKey(
                        name: "FK_SavedOffers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavedOffers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingByUserId",
                table: "Bookings",
                column: "BookingByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingToId",
                table: "Bookings",
                column: "BookingToId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserFavByUserId",
                table: "Favorites",
                column: "UserFavByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserFavToUserId",
                table: "Favorites",
                column: "UserFavToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackByUserId",
                table: "Feedbacks",
                column: "FeedbackByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackToUserId",
                table: "Feedbacks",
                column: "FeedbackToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferReports_OfferId",
                table: "OfferReports",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferReports_UserId",
                table: "OfferReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_AddedByUserId",
                table: "Offers",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedOffers_OfferId",
                table: "SavedOffers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedOffers_UserId",
                table: "SavedOffers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfessions_ProfessionId",
                table: "UserProfessions",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfessions_UserId",
                table: "UserProfessions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "OfferReports");

            migrationBuilder.DropTable(
                name: "SavedOffers");

            migrationBuilder.DropTable(
                name: "UserProfessions");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
