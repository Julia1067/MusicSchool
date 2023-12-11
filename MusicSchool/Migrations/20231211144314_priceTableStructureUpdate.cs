using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSchool.Migrations
{
    /// <inheritdoc />
    public partial class priceTableStructureUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Classes_ClassId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_ClassId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Classes");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Prices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ClassId",
                table: "Prices",
                column: "ClassId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Classes_ClassId",
                table: "Prices",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Classes_ClassId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_ClassId",
                table: "Prices");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Prices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ClassId",
                table: "Prices",
                column: "ClassId",
                unique: true,
                filter: "[ClassId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Classes_ClassId",
                table: "Prices",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }
    }
}
