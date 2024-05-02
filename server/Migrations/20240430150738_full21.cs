using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Classroom",
                newName: "MaxQuantity");

            migrationBuilder.AddColumn<int>(
                name: "CurrentQuantity",
                table: "Classroom",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentQuantity",
                table: "Classroom");

            migrationBuilder.RenameColumn(
                name: "MaxQuantity",
                table: "Classroom",
                newName: "Quantity");
        }
    }
}
