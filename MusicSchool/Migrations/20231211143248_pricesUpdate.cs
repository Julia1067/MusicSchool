using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSchool.Migrations
{
    /// <inheritdoc />
    public partial class pricesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcertPrograms_Students_StudentId",
                table: "ConcertPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcertPrograms_Teachers_TeacherId",
                table: "ConcertPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceModel_Classes_ClassId",
                table: "PriceModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceModel",
                table: "PriceModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConcertPrograms",
                table: "ConcertPrograms");

            migrationBuilder.RenameTable(
                name: "PriceModel",
                newName: "Prices");

            migrationBuilder.RenameTable(
                name: "ConcertPrograms",
                newName: "ConcertProgram");

            migrationBuilder.RenameIndex(
                name: "IX_PriceModel_ClassId",
                table: "Prices",
                newName: "IX_Prices_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_ConcertPrograms_TeacherId",
                table: "ConcertProgram",
                newName: "IX_ConcertProgram_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ConcertPrograms_StudentId",
                table: "ConcertProgram",
                newName: "IX_ConcertProgram_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prices",
                table: "Prices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConcertProgram",
                table: "ConcertProgram",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Classes_ClassId",
                table: "Prices",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
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

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Classes_ClassId",
                table: "Prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prices",
                table: "Prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConcertProgram",
                table: "ConcertProgram");

            migrationBuilder.RenameTable(
                name: "Prices",
                newName: "PriceModel");

            migrationBuilder.RenameTable(
                name: "ConcertProgram",
                newName: "ConcertPrograms");

            migrationBuilder.RenameIndex(
                name: "IX_Prices_ClassId",
                table: "PriceModel",
                newName: "IX_PriceModel_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_ConcertProgram_TeacherId",
                table: "ConcertPrograms",
                newName: "IX_ConcertPrograms_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ConcertProgram_StudentId",
                table: "ConcertPrograms",
                newName: "IX_ConcertPrograms_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceModel",
                table: "PriceModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConcertPrograms",
                table: "ConcertPrograms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcertPrograms_Students_StudentId",
                table: "ConcertPrograms",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcertPrograms_Teachers_TeacherId",
                table: "ConcertPrograms",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceModel_Classes_ClassId",
                table: "PriceModel",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }
    }
}
