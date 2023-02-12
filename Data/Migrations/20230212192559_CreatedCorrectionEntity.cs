using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRougeTestCodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedCorrectionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "corrections",
                columns: table => new
                {
                    CorrectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corrections", x => x.CorrectionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "corrections");
        }
    }
}
