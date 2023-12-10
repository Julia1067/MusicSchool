using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSchool.Migrations
{
    /// <inheritdoc />
    public partial class studetUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentGroups_StudentGroupId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "StudentGroupId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentGroups_StudentGroupId",
                table: "Students",
                column: "StudentGroupId",
                principalTable: "StudentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentGroups_StudentGroupId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "StudentGroupId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentGroups_StudentGroupId",
                table: "Students",
                column: "StudentGroupId",
                principalTable: "StudentGroups",
                principalColumn: "Id");
        }
    }
}
