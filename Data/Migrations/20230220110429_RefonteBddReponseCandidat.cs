using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRougeTestCodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefonteBddReponseCandidat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentAnswers",
                table: "theAnswers");

            migrationBuilder.AddColumn<int>(
                name: "choiceIdUser",
                table: "theAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "choiceIdUser",
                table: "theAnswers");

            migrationBuilder.AddColumn<string>(
                name: "ContentAnswers",
                table: "theAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
