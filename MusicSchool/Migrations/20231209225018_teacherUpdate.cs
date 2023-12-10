using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSchool.Migrations
{
    /// <inheritdoc />
    public partial class teacherUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeachersPositions_PositionId",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeachersPositions_PositionId",
                table: "Teachers",
                column: "PositionId",
                principalTable: "TeachersPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeachersPositions_PositionId",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Teachers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeachersPositions_PositionId",
                table: "Teachers",
                column: "PositionId",
                principalTable: "TeachersPositions",
                principalColumn: "Id");
        }
    }
}
