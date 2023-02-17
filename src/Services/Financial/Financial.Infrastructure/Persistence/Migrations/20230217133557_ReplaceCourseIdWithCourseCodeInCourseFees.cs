using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceCourseIdWithCourseCodeInCourseFees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseFees",
                table: "CourseFees");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CourseFees");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "CourseFees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseFees",
                table: "CourseFees",
                column: "CourseCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseFees",
                table: "CourseFees");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "CourseFees");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "CourseFees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseFees",
                table: "CourseFees",
                column: "CourseId");
        }
    }
}
