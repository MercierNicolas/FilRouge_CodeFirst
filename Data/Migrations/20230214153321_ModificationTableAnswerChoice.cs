using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRougeTestCodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModificationTableAnswerChoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerChoiceQuestion");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "AnswerChoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnswerChoice_QuestionId",
                table: "AnswerChoice",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerChoice_Questions_QuestionId",
                table: "AnswerChoice",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerChoice_Questions_QuestionId",
                table: "AnswerChoice");

            migrationBuilder.DropIndex(
                name: "IX_AnswerChoice_QuestionId",
                table: "AnswerChoice");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "AnswerChoice");

            migrationBuilder.CreateTable(
                name: "AnswerChoiceQuestion",
                columns: table => new
                {
                    CorrectionId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerChoiceQuestion", x => new { x.CorrectionId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_AnswerChoiceQuestion_AnswerChoice_CorrectionId",
                        column: x => x.CorrectionId,
                        principalTable: "AnswerChoice",
                        principalColumn: "CorrectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerChoiceQuestion_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerChoiceQuestion_QuestionId",
                table: "AnswerChoiceQuestion",
                column: "QuestionId");
        }
    }
}
