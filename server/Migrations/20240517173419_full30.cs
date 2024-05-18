using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiaoVu_Person_PersonId",
                table: "GiaoVu");

            migrationBuilder.DropForeignKey(
                name: "FK_TruongBoMon_Person_PersonId",
                table: "TruongBoMon");

            migrationBuilder.DropForeignKey(
                name: "FK_TruongPhoKhoa_Person_PersonId",
                table: "TruongPhoKhoa");

            migrationBuilder.AddForeignKey(
                name: "FK_GiaoVu_Person_PersonId",
                table: "GiaoVu",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TruongBoMon_Person_PersonId",
                table: "TruongBoMon",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TruongPhoKhoa_Person_PersonId",
                table: "TruongPhoKhoa",
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

            migrationBuilder.DropForeignKey(
                name: "FK_TruongBoMon_Person_PersonId",
                table: "TruongBoMon");

            migrationBuilder.DropForeignKey(
                name: "FK_TruongPhoKhoa_Person_PersonId",
                table: "TruongPhoKhoa");

            migrationBuilder.AddForeignKey(
                name: "FK_GiaoVu_Person_PersonId",
                table: "GiaoVu",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TruongBoMon_Person_PersonId",
                table: "TruongBoMon",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TruongPhoKhoa_Person_PersonId",
                table: "TruongPhoKhoa",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId");
        }
    }
}
