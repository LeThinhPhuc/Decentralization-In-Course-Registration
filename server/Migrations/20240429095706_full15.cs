using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubjectId",
                table: "StudentRegisteredSubject",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeacherTime",
                columns: table => new
                {
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherTime", x => new { x.TeacherId, x.TimeId });
                    table.ForeignKey(
                        name: "FK_TeacherTime_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherTime_Time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Time",
                        principalColumn: "TimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegisteredSubject_SubjectId",
                table: "StudentRegisteredSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTime_TimeId",
                table: "TeacherTime",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisteredSubject_Subject_SubjectId",
                table: "StudentRegisteredSubject",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisteredSubject_Subject_SubjectId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropTable(
                name: "TeacherTime");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegisteredSubject_SubjectId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "StudentRegisteredSubject");
        }
    }
}
