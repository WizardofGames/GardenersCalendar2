using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenersCalendar2.Migrations
{
    public partial class WorkingOnCss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GardenerUserId",
                table: "ToDos",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_GardenerUserId",
                table: "ToDos",
                column: "GardenerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AspNetUsers_GardenerUserId",
                table: "ToDos",
                column: "GardenerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AspNetUsers_GardenerUserId",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_GardenerUserId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "GardenerUserId",
                table: "ToDos");
        }
    }
}
