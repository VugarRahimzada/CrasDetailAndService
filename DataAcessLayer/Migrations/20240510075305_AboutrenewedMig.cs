using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AboutrenewedMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "History",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Misson",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "Vision",
                table: "Abouts",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Abouts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Abouts",
                newName: "Vision");

            migrationBuilder.AddColumn<string>(
                name: "History",
                table: "Abouts",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Misson",
                table: "Abouts",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");
        }
    }
}
