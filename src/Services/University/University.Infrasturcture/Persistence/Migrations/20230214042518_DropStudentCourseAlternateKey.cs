using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Infrasturcture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DropStudentCourseAlternateKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_StudentCourses_StudentId_CourseId_TermId",
                table: "StudentCourses");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_StudentCourses_StudentId_CourseId_TermId",
                table: "StudentCourses",
                columns: new[] { "StudentId", "CourseId", "TermId" });
        }
    }
}
