using Microsoft.EntityFrameworkCore.Migrations;

namespace Gariunai_Cloud_Services.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OwnerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Users_OwnerName",
                        column: x => x.OwnerName,
                        principalTable: "Users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    UserName1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.UserName);
                    table.ForeignKey(
                        name: "FK_Passwords_Users_UserName1",
                        column: x => x.UserName1,
                        principalTable: "Users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produce",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ShopId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produce_Businesses_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_OwnerName",
                table: "Businesses",
                column: "OwnerName");

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_UserName1",
                table: "Passwords",
                column: "UserName1");

            migrationBuilder.CreateIndex(
                name: "IX_Produce_ShopId",
                table: "Produce",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropTable(
                name: "Produce");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
