using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRougeTestCodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestSujetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_sujets_Sujetid",
                table: "Quiz");

            migrationBuilder.AlterColumn<int>(
                name: "Sujetid",
                table: "Quiz",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_sujets_Sujetid",
                table: "Quiz",
                column: "Sujetid",
                principalTable: "sujets",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_sujets_Sujetid",
                table: "Quiz");

            migrationBuilder.AlterColumn<int>(
                name: "Sujetid",
                table: "Quiz",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_sujets_Sujetid",
                table: "Quiz",
                column: "Sujetid",
                principalTable: "sujets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
