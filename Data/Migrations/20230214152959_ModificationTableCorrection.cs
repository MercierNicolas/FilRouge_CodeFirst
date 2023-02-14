using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRougeTestCodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModificationTableCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrectionQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_corrections",
                table: "corrections");

            migrationBuilder.RenameTable(
                name: "corrections",
                newName: "AnswerChoice");

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "AnswerChoice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerChoice",
                table: "AnswerChoice",
                column: "CorrectionId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerChoiceQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerChoice",
                table: "AnswerChoice");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "AnswerChoice");

            migrationBuilder.RenameTable(
                name: "AnswerChoice",
                newName: "corrections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_corrections",
                table: "corrections",
                column: "CorrectionId");

            migrationBuilder.CreateTable(
                name: "CorrectionQuestion",
                columns: table => new
                {
                    CorrectionId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectionQuestion", x => new { x.CorrectionId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_CorrectionQuestion_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorrectionQuestion_corrections_CorrectionId",
                        column: x => x.CorrectionId,
                        principalTable: "corrections",
                        principalColumn: "CorrectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorrectionQuestion_QuestionId",
                table: "CorrectionQuestion",
                column: "QuestionId");
        }
    }
}
