using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "StudentRegisteredSubject",
                newName: "Mark3");

            migrationBuilder.AddColumn<float>(
                name: "Mark1",
                table: "StudentRegisteredSubject",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Mark2",
                table: "StudentRegisteredSubject",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark1",
                table: "StudentRegisteredSubject");

            migrationBuilder.DropColumn(
                name: "Mark2",
                table: "StudentRegisteredSubject");

            migrationBuilder.RenameColumn(
                name: "Mark3",
                table: "StudentRegisteredSubject",
                newName: "Mark");
        }
    }
}
