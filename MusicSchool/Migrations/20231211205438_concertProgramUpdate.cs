using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSchool.Migrations
{
    /// <inheritdoc />
    public partial class concertProgramUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcertProgram_Students_StudentId",
                table: "ConcertProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcertProgram_Teachers_TeacherId",
                table: "ConcertProgram");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "ConcertProgram",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "ConcertProgram",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcertProgram_Students_StudentId",
                table: "ConcertProgram",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcertProgram_Teachers_TeacherId",
                table: "ConcertProgram",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcertProgram_Students_StudentId",
                table: "ConcertProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcertProgram_Teachers_TeacherId",
                table: "ConcertProgram");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "ConcertProgram",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "ConcertProgram",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcertProgram_Students_StudentId",
                table: "ConcertProgram",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcertProgram_Teachers_TeacherId",
                table: "ConcertProgram",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
