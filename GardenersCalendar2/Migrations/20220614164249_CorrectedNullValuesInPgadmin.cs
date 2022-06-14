using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenersCalendar2.Migrations
{
    public partial class CorrectedNullValuesInPgadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AspNetUsers_GardenerUserId",
                table: "ToDos");

            migrationBuilder.AlterColumn<string>(
                name: "GardenerUserId",
                table: "ToDos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AspNetUsers_GardenerUserId",
                table: "ToDos",
                column: "GardenerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AspNetUsers_GardenerUserId",
                table: "ToDos");

            migrationBuilder.AlterColumn<string>(
                name: "GardenerUserId",
                table: "ToDos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AspNetUsers_GardenerUserId",
                table: "ToDos",
                column: "GardenerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
