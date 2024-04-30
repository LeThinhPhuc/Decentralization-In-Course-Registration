using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectClass",
                table: "SubjectClass");

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "SubjectClass",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectClass",
                table: "SubjectClass",
                columns: new[] { "SubjectId", "ClassroomId", "TimeId", "TeacherId" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClass_TeacherId",
                table: "SubjectClass",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectClass_Teacher_TeacherId",
                table: "SubjectClass",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectClass_Teacher_TeacherId",
                table: "SubjectClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectClass",
                table: "SubjectClass");

            migrationBuilder.DropIndex(
                name: "IX_SubjectClass_TeacherId",
                table: "SubjectClass");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "SubjectClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectClass",
                table: "SubjectClass",
                columns: new[] { "SubjectId", "ClassroomId", "TimeId" });

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
                name: "IX_TeacherTime_TimeId",
                table: "TeacherTime",
                column: "TimeId");
        }
    }
}
