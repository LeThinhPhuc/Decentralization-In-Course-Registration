using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectClass",
                table: "SubjectClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectClass",
                table: "SubjectClass",
                columns: new[] { "SubjectId", "ClassroomId", "TimeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectClass",
                table: "SubjectClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectClass",
                table: "SubjectClass",
                columns: new[] { "SubjectId", "ClassroomId" });
        }
    }
}
