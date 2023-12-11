using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSchool.Migrations
{
    /// <inheritdoc />
    public partial class unifyClassSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceModel_ExtraClasses_ExtraClassId",
                table: "PriceModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Classes_ClassId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Classroomes_ClassroomId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Teachers_TeacherId",
                table: "Schedule");

            migrationBuilder.DropTable(
                name: "ExtraSchedule");

            migrationBuilder.DropTable(
                name: "ExtraClasses");

            migrationBuilder.DropIndex(
                name: "IX_PriceModel_ExtraClassId",
                table: "PriceModel");

            migrationBuilder.RenameColumn(
                name: "ExtraClassId",
                table: "PriceModel",
                newName: "ClassId");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassType",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentGroupId",
                table: "Schedule",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_StudentGroupId",
                table: "Schedule",
                column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceModel_ClassId",
                table: "PriceModel",
                column: "ClassId",
                unique: true,
                filter: "[ClassId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceModel_Classes_ClassId",
                table: "PriceModel",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Classes_ClassId",
                table: "Schedule",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Classroomes_ClassroomId",
                table: "Schedule",
                column: "ClassroomId",
                principalTable: "Classroomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_StudentGroups_StudentGroupId",
                table: "Schedule",
                column: "StudentGroupId",
                principalTable: "StudentGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Teachers_TeacherId",
                table: "Schedule",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceModel_Classes_ClassId",
                table: "PriceModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Classes_ClassId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Classroomes_ClassroomId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_StudentGroups_StudentGroupId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Teachers_TeacherId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_StudentGroupId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_PriceModel_ClassId",
                table: "PriceModel");

            migrationBuilder.DropColumn(
                name: "ClassType",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "StudentGroupId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "PriceModel",
                newName: "ExtraClassId");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Schedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Schedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Schedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ExtraClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    ClassroomId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    Fromdt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Todt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeekDay = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraSchedule_Classroomes_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroomes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExtraSchedule_ExtraClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "ExtraClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExtraSchedule_StudentGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "StudentGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExtraSchedule_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceModel_ExtraClassId",
                table: "PriceModel",
                column: "ExtraClassId",
                unique: true,
                filter: "[ExtraClassId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraSchedule_ClassId",
                table: "ExtraSchedule",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraSchedule_ClassroomId",
                table: "ExtraSchedule",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraSchedule_GroupId",
                table: "ExtraSchedule",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraSchedule_TeacherId",
                table: "ExtraSchedule",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceModel_ExtraClasses_ExtraClassId",
                table: "PriceModel",
                column: "ExtraClassId",
                principalTable: "ExtraClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Classes_ClassId",
                table: "Schedule",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Classroomes_ClassroomId",
                table: "Schedule",
                column: "ClassroomId",
                principalTable: "Classroomes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Teachers_TeacherId",
                table: "Schedule",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
