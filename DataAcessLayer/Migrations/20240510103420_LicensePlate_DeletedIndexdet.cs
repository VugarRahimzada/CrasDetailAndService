using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class LicensePlate_DeletedIndexdet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_Id_Delete",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_Id_Delete",
                table: "Abouts");

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LicensePlate_Delete",
                table: "Orders",
                columns: new[] { "LicensePlate", "Delete" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_LicensePlate_Delete",
                table: "Orders");

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_Delete",
                table: "Orders",
                columns: new[] { "Id", "Delete" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_Id_Delete",
                table: "Abouts",
                columns: new[] { "Id", "Delete" },
                unique: true);
        }
    }
}
