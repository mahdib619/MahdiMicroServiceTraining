using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Infrasturcture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StudentNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    SignUpTermId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.UniqueConstraint("AK_Students_StudentNumber", x => x.StudentNumber);
                    table.ForeignKey(
                        name: "FK_Students_Terms_SignUpTermId",
                        column: x => x.SignUpTermId,
                        principalTable: "Terms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SignUpTermId",
                table: "Students",
                column: "SignUpTermId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
