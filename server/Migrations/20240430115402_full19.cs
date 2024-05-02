using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassroomId",
                table: "StudentRegisteredSubject",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "StudentRegisteredSubject",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<string>(
                name: "TimeId",
                table: "StudentRegisteredSubject",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegisteredSubject_ClassroomId",
                table: "StudentRegisteredSubject",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegisteredSubject_TeacherId",
                table: "StudentRegisteredSubject",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegisteredSubject_TimeId",
                table: "StudentRegisteredSubject",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisteredSubject_Classroom_ClassroomId",
                table: "StudentRegisteredSubject",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "ClassRoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisteredSubject_Teacher_TeacherId",
                table: "StudentRegisteredSubject",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisteredSubject_Time_TimeId",
                table: "StudentRegisteredSubject",
                column: "TimeId",
                principalTable: "Time",
                principalColumn: "TimeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisteredSubject_Classroom_ClassroomId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisteredSubject_Teacher_TeacherId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisteredSubject_Time_TimeId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegisteredSubject_ClassroomId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegisteredSubject_TeacherId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegisteredSubject_TimeId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "StudentRegisteredSubject");
        }
    }
}
