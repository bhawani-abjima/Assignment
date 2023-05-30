using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDataBase.Migrations
{
    public partial class update_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Studentdata",
                table: "Studentdata");

            migrationBuilder.RenameTable(
                name: "Studentdata",
                newName: "Student");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Studentdata");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studentdata",
                table: "Studentdata",
                column: "Id");
        }
    }
}
