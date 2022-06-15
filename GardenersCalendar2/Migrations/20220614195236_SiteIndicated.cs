using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenersCalendar2.Migrations
{
    public partial class SiteIndicated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GardenerUserId",
                table: "Plants",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_GardenerUserId",
                table: "Plants",
                column: "GardenerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_AspNetUsers_GardenerUserId",
                table: "Plants",
                column: "GardenerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AspNetUsers_GardenerUserId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_GardenerUserId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "GardenerUserId",
                table: "Plants");
        }
    }
}
