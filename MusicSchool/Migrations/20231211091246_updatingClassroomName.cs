using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSchool.Migrations
{
    /// <inheritdoc />
    public partial class updatingClassroomName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Classroomes_ClassroomId",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classroomes",
                table: "Classroomes");

            migrationBuilder.RenameTable(
                name: "Classroomes",
                newName: "Classrooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classrooms",
                table: "Classrooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Classrooms_ClassroomId",
                table: "Schedule",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Classrooms_ClassroomId",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classrooms",
                table: "Classrooms");

            migrationBuilder.RenameTable(
                name: "Classrooms",
                newName: "Classroomes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classroomes",
                table: "Classroomes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Classroomes_ClassroomId",
                table: "Schedule",
                column: "ClassroomId",
                principalTable: "Classroomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
