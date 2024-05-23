using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class TeamConfigurationRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_Name_Delete",
                table: "Teams");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Id_Delete",
                table: "Teams",
                columns: new[] { "Id", "Delete" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_Id_Delete",
                table: "Teams");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name_Delete",
                table: "Teams",
                columns: new[] { "Name", "Delete" },
                unique: true);
        }
    }
}
