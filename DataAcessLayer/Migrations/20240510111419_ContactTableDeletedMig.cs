using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ContactTableDeletedMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Teams_Id_Delete",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Services_Id_Delete",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_ContactUses_Id_Delete",
                table: "ContactUses");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_Id_Delete",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_Id_Delete",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name_Delete",
                table: "Teams",
                columns: new[] { "Name", "Delete" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_Title_Delete",
                table: "Services",
                columns: new[] { "Title", "Delete" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Process_Title_Delete",
                table: "Process",
                columns: new[] { "Title", "Delete" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactUses_Email_Delete",
                table: "ContactUses",
                columns: new[] { "Email", "Delete" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Title_Delete",
                table: "Blogs",
                columns: new[] { "Title", "Delete" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Email_Delete",
                table: "Appointments",
                columns: new[] { "Email", "Delete" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_Name_Delete",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Services_Title_Delete",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Process_Title_Delete",
                table: "Process");

            migrationBuilder.DropIndex(
                name: "IX_ContactUses_Email_Delete",
                table: "ContactUses");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_Title_Delete",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_Email_Delete",
                table: "Appointments");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delete = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Id_Delete",
                table: "Teams",
                columns: new[] { "Id", "Delete" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_Id_Delete",
                table: "Services",
                columns: new[] { "Id", "Delete" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactUses_Id_Delete",
                table: "ContactUses",
                columns: new[] { "Id", "Delete" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Id_Delete",
                table: "Blogs",
                columns: new[] { "Id", "Delete" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Id_Delete",
                table: "Appointments",
                columns: new[] { "Id", "Delete" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Id_Delete",
                table: "Contacts",
                columns: new[] { "Id", "Delete" },
                unique: true);
        }
    }
}
