using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenersCalendar2.Migrations
{
    public partial class ParentListIssuesCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Gardens_ParentList2Id",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Nurseries_ParentList1Id",
                table: "Plants");

            migrationBuilder.RenameColumn(
                name: "ParentList2Id",
                table: "Plants",
                newName: "NurseryId");

            migrationBuilder.RenameColumn(
                name: "ParentList1Id",
                table: "Plants",
                newName: "GardenId");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_ParentList2Id",
                table: "Plants",
                newName: "IX_Plants_NurseryId");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_ParentList1Id",
                table: "Plants",
                newName: "IX_Plants_GardenId");

            migrationBuilder.AddColumn<string>(
                name: "GardenerUserId",
                table: "Nurseries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GardenerUserId",
                table: "Gardens",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nurseries_GardenerUserId",
                table: "Nurseries",
                column: "GardenerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_GardenerUserId",
                table: "Gardens",
                column: "GardenerUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Gardens_GardenId",
                table: "Plants",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "GardenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Nurseries_NurseryId",
                table: "Plants",
                column: "NurseryId",
                principalTable: "Nurseries",
                principalColumn: "NurseryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_AspNetUsers_GardenerUserId",
                table: "Gardens");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurseries_AspNetUsers_GardenerUserId",
                table: "Nurseries");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Gardens_GardenId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Nurseries_NurseryId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Nurseries_GardenerUserId",
                table: "Nurseries");

            migrationBuilder.DropIndex(
                name: "IX_Gardens_GardenerUserId",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "GardenerUserId",
                table: "Nurseries");

            migrationBuilder.DropColumn(
                name: "GardenerUserId",
                table: "Gardens");

            migrationBuilder.RenameColumn(
                name: "NurseryId",
                table: "Plants",
                newName: "ParentList2Id");

            migrationBuilder.RenameColumn(
                name: "GardenId",
                table: "Plants",
                newName: "ParentList1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_NurseryId",
                table: "Plants",
                newName: "IX_Plants_ParentList2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_GardenId",
                table: "Plants",
                newName: "IX_Plants_ParentList1Id");

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
    }
}
