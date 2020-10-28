using Microsoft.EntityFrameworkCore.Migrations;

namespace Gariunai_Cloud_Services.Migrations
{
    public partial class renameShopsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Users_OwnerId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Businesses_ShopId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Businesses_ShopId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Produce_Businesses_ShopId",
                table: "Produce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Businesses",
                table: "Businesses");

            migrationBuilder.RenameTable(
                name: "Businesses",
                newName: "Shops");

            migrationBuilder.RenameIndex(
                name: "IX_Businesses_OwnerId",
                table: "Shops",
                newName: "IX_Shops_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shops",
                table: "Shops",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Shops_ShopId",
                table: "Follows",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Shops_ShopId",
                table: "Notifications",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produce_Shops_ShopId",
                table: "Produce",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Users_OwnerId",
                table: "Shops",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Shops_ShopId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Shops_ShopId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Produce_Shops_ShopId",
                table: "Produce");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Users_OwnerId",
                table: "Shops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shops",
                table: "Shops");

            migrationBuilder.RenameTable(
                name: "Shops",
                newName: "Businesses");

            migrationBuilder.RenameIndex(
                name: "IX_Shops_OwnerId",
                table: "Businesses",
                newName: "IX_Businesses_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Businesses",
                table: "Businesses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Users_OwnerId",
                table: "Businesses",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Businesses_ShopId",
                table: "Follows",
                column: "ShopId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Businesses_ShopId",
                table: "Notifications",
                column: "ShopId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produce_Businesses_ShopId",
                table: "Produce",
                column: "ShopId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
