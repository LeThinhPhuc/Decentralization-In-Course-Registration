using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Faculty_SubjectId",
                table: "Subject");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Subject",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_FacultyId",
                table: "Subject",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Faculty_FacultyId",
                table: "Subject",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Faculty_FacultyId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_FacultyId",
                table: "Subject");

            migrationBuilder.AlterColumn<string>(
                name: "FacultyId",
                table: "Subject",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Faculty_SubjectId",
                table: "Subject",
                column: "SubjectId",
                principalTable: "Faculty",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
