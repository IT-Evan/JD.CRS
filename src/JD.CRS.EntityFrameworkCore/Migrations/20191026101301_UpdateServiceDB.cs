using Microsoft.EntityFrameworkCore.Migrations;

namespace JD.CRS.Migrations
{
    public partial class UpdateServiceDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "StudentCourse",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "StudentCourse",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructorName",
                table: "OfficeInstructor",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficeName",
                table: "OfficeInstructor",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "InstructorCourse",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructorName",
                table: "InstructorCourse",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "DepartmentInstructor",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructorName",
                table: "DepartmentInstructor",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "DepartmentCourse",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "DepartmentCourse",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "StudentCourse");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "StudentCourse");

            migrationBuilder.DropColumn(
                name: "InstructorName",
                table: "OfficeInstructor");

            migrationBuilder.DropColumn(
                name: "OfficeName",
                table: "OfficeInstructor");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "InstructorCourse");

            migrationBuilder.DropColumn(
                name: "InstructorName",
                table: "InstructorCourse");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "DepartmentInstructor");

            migrationBuilder.DropColumn(
                name: "InstructorName",
                table: "DepartmentInstructor");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "DepartmentCourse");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "DepartmentCourse");
        }
    }
}
