using Microsoft.EntityFrameworkCore.Migrations;

namespace Highscores.Website.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReleaseYear = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UrlSlug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Highscores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlSlug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Highscores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameCategoryHighscore",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    HighscoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategoryHighscore", x => new { x.CategoriesId, x.HighscoresId });
                    table.ForeignKey(
                        name: "FK_GameCategoryHighscore_GameCategories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "GameCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCategoryHighscore_Highscores_HighscoresId",
                        column: x => x.HighscoresId,
                        principalTable: "Highscores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameCategoryHighscore_HighscoresId",
                table: "GameCategoryHighscore",
                column: "HighscoresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCategoryHighscore");

            migrationBuilder.DropTable(
                name: "GameCategories");

            migrationBuilder.DropTable(
                name: "Highscores");
        }
    }
}
