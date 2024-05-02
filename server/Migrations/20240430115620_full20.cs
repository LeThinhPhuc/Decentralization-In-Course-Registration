using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRegisteredSubject",
                table: "StudentRegisteredSubject");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRegisteredSubject",
                table: "StudentRegisteredSubject",
                columns: new[] { "StudentId", "SubjectId", "ClassroomId", "TeacherId", "TimeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRegisteredSubject",
                table: "StudentRegisteredSubject");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRegisteredSubject",
                table: "StudentRegisteredSubject",
                columns: new[] { "StudentId", "SubjectId" });
        }
    }
}
