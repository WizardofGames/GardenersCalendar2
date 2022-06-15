using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenersCalendar2.Migrations
{
    public partial class AddedPropertiesToToDoTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayNumber",
                table: "ToDoTemplates",
                newName: "StartDayNumber");

            migrationBuilder.AddColumn<int>(
                name: "EndDayNumber",
                table: "ToDoTemplates",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecurrenceInterval",
                table: "ToDoTemplates",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDayNumber",
                table: "ToDoTemplates");

            migrationBuilder.DropColumn(
                name: "RecurrenceInterval",
                table: "ToDoTemplates");

            migrationBuilder.RenameColumn(
                name: "StartDayNumber",
                table: "ToDoTemplates",
                newName: "DayNumber");
        }
    }
}
