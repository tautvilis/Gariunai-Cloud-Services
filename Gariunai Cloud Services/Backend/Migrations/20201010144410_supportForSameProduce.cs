using Microsoft.EntityFrameworkCore.Migrations;

namespace Gariunai_Cloud_Services.Migrations
{
    public partial class supportForSameProduce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produce",
                table: "Produce");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Produce",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Produce",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produce",
                table: "Produce",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produce",
                table: "Produce");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Produce");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Produce",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produce",
                table: "Produce",
                column: "Name");
        }
    }
}
