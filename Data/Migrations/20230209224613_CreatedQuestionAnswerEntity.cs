using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRougeTestCodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedQuestionAnswerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionAnswerIdentityUserId",
                table: "theAnswers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionAnswerQuestionId",
                table: "theAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionAnswerTheAnswerId",
                table: "theAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionAnswerIdentityUserId",
                table: "Questions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionAnswerQuestionId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionAnswerTheAnswerId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionsAnswers",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    TheAnswerId = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateValidation = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsAnswers", x => new { x.QuestionId, x.TheAnswerId, x.IdentityUserId });
                    table.ForeignKey(
                        name: "FK_QuestionsAnswers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_theAnswers_QuestionAnswerQuestionId_QuestionAnswerTheAnswerId_QuestionAnswerIdentityUserId",
                table: "theAnswers",
                columns: new[] { "QuestionAnswerQuestionId", "QuestionAnswerTheAnswerId", "QuestionAnswerIdentityUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionAnswerQuestionId_QuestionAnswerTheAnswerId_QuestionAnswerIdentityUserId",
                table: "Questions",
                columns: new[] { "QuestionAnswerQuestionId", "QuestionAnswerTheAnswerId", "QuestionAnswerIdentityUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsAnswers_IdentityUserId",
                table: "QuestionsAnswers",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionsAnswers_QuestionAnswerQuestionId_QuestionAnswerTheAnswerId_QuestionAnswerIdentityUserId",
                table: "Questions",
                columns: new[] { "QuestionAnswerQuestionId", "QuestionAnswerTheAnswerId", "QuestionAnswerIdentityUserId" },
                principalTable: "QuestionsAnswers",
                principalColumns: new[] { "QuestionId", "TheAnswerId", "IdentityUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_theAnswers_QuestionsAnswers_QuestionAnswerQuestionId_QuestionAnswerTheAnswerId_QuestionAnswerIdentityUserId",
                table: "theAnswers",
                columns: new[] { "QuestionAnswerQuestionId", "QuestionAnswerTheAnswerId", "QuestionAnswerIdentityUserId" },
                principalTable: "QuestionsAnswers",
                principalColumns: new[] { "QuestionId", "TheAnswerId", "IdentityUserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionsAnswers_QuestionAnswerQuestionId_QuestionAnswerTheAnswerId_QuestionAnswerIdentityUserId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_theAnswers_QuestionsAnswers_QuestionAnswerQuestionId_QuestionAnswerTheAnswerId_QuestionAnswerIdentityUserId",
                table: "theAnswers");

            migrationBuilder.DropTable(
                name: "QuestionsAnswers");

            migrationBuilder.DropIndex(
                name: "IX_theAnswers_QuestionAnswerQuestionId_QuestionAnswerTheAnswerId_QuestionAnswerIdentityUserId",
                table: "theAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionAnswerQuestionId_QuestionAnswerTheAnswerId_QuestionAnswerIdentityUserId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionAnswerIdentityUserId",
                table: "theAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionAnswerQuestionId",
                table: "theAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionAnswerTheAnswerId",
                table: "theAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionAnswerIdentityUserId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionAnswerQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionAnswerTheAnswerId",
                table: "Questions");
        }
    }
}
