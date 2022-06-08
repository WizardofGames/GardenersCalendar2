using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenersCalendar2.Migrations
{
    public partial class ParentListIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Plants_ParentListId",
                table: "ToDos");

            migrationBuilder.RenameColumn(
                name: "ParentListId",
                table: "ToDos",
                newName: "PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDos_ParentListId",
                table: "ToDos",
                newName: "IX_ToDos_PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Plants_PlantId",
                table: "ToDos",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Plants_PlantId",
                table: "ToDos");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "ToDos",
                newName: "ParentListId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDos_PlantId",
                table: "ToDos",
                newName: "IX_ToDos_ParentListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Plants_ParentListId",
                table: "ToDos",
                column: "ParentListId",
                principalTable: "Plants",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
