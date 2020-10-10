using Microsoft.EntityFrameworkCore.Migrations;

namespace Gariunai_Cloud_Services.Migrations
{
    public partial class produceKeyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produce",
                table: "Produce",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produce",
                table: "Produce");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Produce",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Produce",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produce",
                table: "Produce",
                column: "Id");
        }
    }
}
