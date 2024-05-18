using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiaoVu_Person_PersonId",
                table: "GiaoVu");

            migrationBuilder.AddForeignKey(
                name: "FK_GiaoVu_Person_PersonId",
                table: "GiaoVu",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiaoVu_Person_PersonId",
                table: "GiaoVu");

            migrationBuilder.AddForeignKey(
                name: "FK_GiaoVu_Person_PersonId",
                table: "GiaoVu",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId");
        }
    }
}
