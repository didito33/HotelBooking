using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Data.Migrations
{
    public partial class HotelUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_UserId",
                table: "Hotels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_AspNetUsers_UserId",
                table: "Hotels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_AspNetUsers_UserId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_UserId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hotels");
        }
    }
}
