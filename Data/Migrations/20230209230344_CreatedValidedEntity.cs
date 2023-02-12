using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRougeTestCodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedValidedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ValidedIdentityUserId",
                table: "theAnswers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValidedTheAnswerId",
                table: "theAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "valides",
                columns: table => new
                {
                    TheAnswerId = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ValidedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valides", x => new { x.TheAnswerId, x.IdentityUserId });
                    table.ForeignKey(
                        name: "FK_valides_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_theAnswers_ValidedTheAnswerId_ValidedIdentityUserId",
                table: "theAnswers",
                columns: new[] { "ValidedTheAnswerId", "ValidedIdentityUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_valides_IdentityUserId",
                table: "valides",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_theAnswers_valides_ValidedTheAnswerId_ValidedIdentityUserId",
                table: "theAnswers",
                columns: new[] { "ValidedTheAnswerId", "ValidedIdentityUserId" },
                principalTable: "valides",
                principalColumns: new[] { "TheAnswerId", "IdentityUserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_theAnswers_valides_ValidedTheAnswerId_ValidedIdentityUserId",
                table: "theAnswers");

            migrationBuilder.DropTable(
                name: "valides");

            migrationBuilder.DropIndex(
                name: "IX_theAnswers_ValidedTheAnswerId_ValidedIdentityUserId",
                table: "theAnswers");

            migrationBuilder.DropColumn(
                name: "ValidedIdentityUserId",
                table: "theAnswers");

            migrationBuilder.DropColumn(
                name: "ValidedTheAnswerId",
                table: "theAnswers");
        }
    }
}
