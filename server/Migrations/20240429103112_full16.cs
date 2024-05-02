using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisteredSubject_RegisteredSubject_RegisteredSubjectId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisteredSubject_Subject_SubjectId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropTable(
                name: "RegisteredSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRegisteredSubject",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegisteredSubject_RegisteredSubjectId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropColumn(
                name: "RegisteredSubjectId",
                table: "StudentRegisteredSubject");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "StudentRegisteredSubject",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "StudentRegisteredSubject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRegisteredSubject",
                table: "StudentRegisteredSubject",
                columns: new[] { "StudentId", "SubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisteredSubject_Subject_SubjectId",
                table: "StudentRegisteredSubject",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisteredSubject_Subject_SubjectId",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRegisteredSubject",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "StudentRegisteredSubject");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "StudentRegisteredSubject",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<string>(
                name: "RegisteredSubjectId",
                table: "StudentRegisteredSubject",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRegisteredSubject",
                table: "StudentRegisteredSubject",
                columns: new[] { "StudentId", "RegisteredSubjectId" });

            migrationBuilder.CreateTable(
                name: "RegisteredSubject",
                columns: table => new
                {
                    RegisteredSubjecId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredSubject", x => x.RegisteredSubjecId);
                    table.UniqueConstraint("AK_RegisteredSubject_SubjectId", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_RegisteredSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegisteredSubject_RegisteredSubjectId",
                table: "StudentRegisteredSubject",
                column: "RegisteredSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisteredSubject_RegisteredSubject_RegisteredSubjectId",
                table: "StudentRegisteredSubject",
                column: "RegisteredSubjectId",
                principalTable: "RegisteredSubject",
                principalColumn: "RegisteredSubjecId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisteredSubject_Subject_SubjectId",
                table: "StudentRegisteredSubject",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId");
        }
    }
}
