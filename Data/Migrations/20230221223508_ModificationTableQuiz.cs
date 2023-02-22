using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRougeTestCodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModificationTableQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecruterIdId",
                table: "Quiz",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_RecruterIdId",
                table: "Quiz",
                column: "RecruterIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_AspNetUsers_RecruterIdId",
                table: "Quiz",
                column: "RecruterIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_AspNetUsers_RecruterIdId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_RecruterIdId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "RecruterIdId",
                table: "Quiz");
        }
    }
}
