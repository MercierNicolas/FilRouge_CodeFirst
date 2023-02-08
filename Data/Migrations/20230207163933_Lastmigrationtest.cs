using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRougeTestCodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class Lastmigrationtest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionQuiz_Questions_QuestionsQuestionId",
                table: "QuestionQuiz");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionQuiz_Quiz_QuizzId",
                table: "QuestionQuiz");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_levels_LevelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_sujets_Sujetid",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_levels_LevelId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_sujets_Sujetid",
                table: "Quiz");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Average",
                table: "Quiz",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionQuiz_Questions_QuestionsQuestionId",
                table: "QuestionQuiz",
                column: "QuestionsQuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionQuiz_Quiz_QuizzId",
                table: "QuestionQuiz",
                column: "QuizzId",
                principalTable: "Quiz",
                principalColumn: "QuizzId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_levels_LevelId",
                table: "Questions",
                column: "LevelId",
                principalTable: "levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_sujets_Sujetid",
                table: "Questions",
                column: "Sujetid",
                principalTable: "sujets",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_levels_LevelId",
                table: "Quiz",
                column: "LevelId",
                principalTable: "levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_sujets_Sujetid",
                table: "Quiz",
                column: "Sujetid",
                principalTable: "sujets",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionQuiz_Questions_QuestionsQuestionId",
                table: "QuestionQuiz");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionQuiz_Quiz_QuizzId",
                table: "QuestionQuiz");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_levels_LevelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_sujets_Sujetid",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_levels_LevelId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_sujets_Sujetid",
                table: "Quiz");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Average",
                table: "Quiz",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionQuiz_Questions_QuestionsQuestionId",
                table: "QuestionQuiz",
                column: "QuestionsQuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionQuiz_Quiz_QuizzId",
                table: "QuestionQuiz",
                column: "QuizzId",
                principalTable: "Quiz",
                principalColumn: "QuizzId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_levels_LevelId",
                table: "Questions",
                column: "LevelId",
                principalTable: "levels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_sujets_Sujetid",
                table: "Questions",
                column: "Sujetid",
                principalTable: "sujets",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_levels_LevelId",
                table: "Quiz",
                column: "LevelId",
                principalTable: "levels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_sujets_Sujetid",
                table: "Quiz",
                column: "Sujetid",
                principalTable: "sujets",
                principalColumn: "id");
        }
    }
}
