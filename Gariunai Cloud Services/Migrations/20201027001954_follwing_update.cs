using Microsoft.EntityFrameworkCore.Migrations;

namespace Gariunai_Cloud_Services.Migrations
{
    public partial class follwing_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ShopId",
                table: "Notifications",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Businesses_ShopId",
                table: "Notifications",
                column: "ShopId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Businesses_ShopId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ShopId",
                table: "Notifications");
        }
    }
}
