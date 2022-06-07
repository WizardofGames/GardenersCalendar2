using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenersCalendar2.Migrations
{
    public partial class NullableParentLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Gardens_ParentList2Id",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Nurseries_ParentList1Id",
                table: "Plants");

            migrationBuilder.AlterColumn<int>(
                name: "ParentList2Id",
                table: "Plants",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ParentList1Id",
                table: "Plants",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Gardens_ParentList2Id",
                table: "Plants",
                column: "ParentList2Id",
                principalTable: "Gardens",
                principalColumn: "GardenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Nurseries_ParentList1Id",
                table: "Plants",
                column: "ParentList1Id",
                principalTable: "Nurseries",
                principalColumn: "NurseryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Gardens_ParentList2Id",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Nurseries_ParentList1Id",
                table: "Plants");

            migrationBuilder.AlterColumn<int>(
                name: "ParentList2Id",
                table: "Plants",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentList1Id",
                table: "Plants",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Gardens_ParentList2Id",
                table: "Plants",
                column: "ParentList2Id",
                principalTable: "Gardens",
                principalColumn: "GardenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Nurseries_ParentList1Id",
                table: "Plants",
                column: "ParentList1Id",
                principalTable: "Nurseries",
                principalColumn: "NurseryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
