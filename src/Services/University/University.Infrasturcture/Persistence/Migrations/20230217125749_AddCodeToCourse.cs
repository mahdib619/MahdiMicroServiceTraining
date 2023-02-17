using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Infrasturcture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCodeToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Courses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Courses_Code",
                table: "Courses",
                column: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Courses_Code",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Courses");
        }
    }
}
