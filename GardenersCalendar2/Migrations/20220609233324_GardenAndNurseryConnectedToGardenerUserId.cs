using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenersCalendar2.Migrations
{
    public partial class GardenAndNurseryConnectedToGardenerUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_AspNetUsers_GardenerUserId",
                table: "Gardens");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurseries_AspNetUsers_GardenerUserId",
                table: "Nurseries");

            migrationBuilder.AlterColumn<string>(
                name: "GardenerUserId",
                table: "Nurseries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GardenerUserId",
                table: "Gardens",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_AspNetUsers_GardenerUserId",
                table: "Gardens",
                column: "GardenerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurseries_AspNetUsers_GardenerUserId",
                table: "Nurseries",
                column: "GardenerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_AspNetUsers_GardenerUserId",
                table: "Gardens");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurseries_AspNetUsers_GardenerUserId",
                table: "Nurseries");

            migrationBuilder.AlterColumn<string>(
                name: "GardenerUserId",
                table: "Nurseries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "GardenerUserId",
                table: "Gardens",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_AspNetUsers_GardenerUserId",
                table: "Gardens",
                column: "GardenerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurseries_AspNetUsers_GardenerUserId",
                table: "Nurseries",
                column: "GardenerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
