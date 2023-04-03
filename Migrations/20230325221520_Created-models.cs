using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace qandr_api.Migrations
{
    public partial class Createdmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lecturer_id",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Student_id",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Lecturer_id",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lecturer_id",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_id",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lecturer_id",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
