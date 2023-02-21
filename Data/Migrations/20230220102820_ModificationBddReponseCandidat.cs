using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRougeTestCodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModificationBddReponseCandidat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answers",
                table: "theAnswers");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "theAnswers");

            migrationBuilder.RenameColumn(
                name: "Questions",
                table: "theAnswers",
                newName: "ContentAnswers");

            migrationBuilder.AddColumn<bool>(
                name: "IsCheck",
                table: "theAnswers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QuestionsIdQuestionId",
                table: "theAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_theAnswers_QuestionsIdQuestionId",
                table: "theAnswers",
                column: "QuestionsIdQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_theAnswers_Questions_QuestionsIdQuestionId",
                table: "theAnswers",
                column: "QuestionsIdQuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_theAnswers_Questions_QuestionsIdQuestionId",
                table: "theAnswers");

            migrationBuilder.DropIndex(
                name: "IX_theAnswers_QuestionsIdQuestionId",
                table: "theAnswers");

            migrationBuilder.DropColumn(
                name: "IsCheck",
                table: "theAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionsIdQuestionId",
                table: "theAnswers");

            migrationBuilder.RenameColumn(
                name: "ContentAnswers",
                table: "theAnswers",
                newName: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "Answers",
                table: "theAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "theAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
