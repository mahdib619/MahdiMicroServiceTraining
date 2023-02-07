using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Infrasturcture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCodeToMajor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Majors",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Majors_Code",
                table: "Majors",
                column: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Majors_Code",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Majors");
        }
    }
}
