using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Person_PersonId",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Person_PersonId",
                table: "Student",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Person_PersonId",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Person_PersonId",
                table: "Student",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId");
        }
    }
}
