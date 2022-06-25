using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenersCalendar2.Migrations
{
    public partial class AddedGardenerUserIdToToDoTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GardenerUserId",
                table: "ToDoTemplates",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GardenerUserId",
                table: "ToDoTemplates");
        }
    }
}
