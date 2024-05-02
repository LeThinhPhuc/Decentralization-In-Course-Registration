using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMCSDL.Migrations
{
    /// <inheritdoc />
    public partial class full5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "SubjectClass");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "SubjectClass");

            migrationBuilder.AddColumn<string>(
                name: "TimeId",
                table: "SubjectClass",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClass_TimeId",
                table: "SubjectClass",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectClass_Time_TimeId",
                table: "SubjectClass",
                column: "TimeId",
                principalTable: "Time",
                principalColumn: "TimeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectClass_Time_TimeId",
                table: "SubjectClass");

            migrationBuilder.DropIndex(
                name: "IX_SubjectClass_TimeId",
                table: "SubjectClass");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "SubjectClass");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "SubjectClass",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "SubjectClass",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
