using Microsoft.EntityFrameworkCore.Migrations;

namespace JD.CRS.Migrations
{
    public partial class FixData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor_AdministratorId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_AdministratorId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "Department");

            migrationBuilder.AddColumn<string>(
                name: "InstructorCode",
                table: "Department",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructorCode",
                table: "Department");

            migrationBuilder.AddColumn<int>(
                name: "AdministratorId",
                table: "Department",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_AdministratorId",
                table: "Department",
                column: "AdministratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor_AdministratorId",
                table: "Department",
                column: "AdministratorId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
