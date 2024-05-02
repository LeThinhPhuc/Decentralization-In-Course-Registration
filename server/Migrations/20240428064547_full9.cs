using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Faculty_FacultyId",
                table: "Subject");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Faculty_FacultyId",
                table: "Subject",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "FacultyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Faculty_FacultyId",
                table: "Subject");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Faculty_FacultyId",
                table: "Subject",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
