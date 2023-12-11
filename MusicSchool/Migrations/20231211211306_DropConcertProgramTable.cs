using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSchool.Migrations
{
    /// <inheritdoc />
    public partial class DropConcertProgramTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcertProgram");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcertProgram",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcertProgram_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcertProgram_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcertProgram_StudentId",
                table: "ConcertProgram",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertProgram_TeacherId",
                table: "ConcertProgram",
                column: "TeacherId");
        }
    }
}
