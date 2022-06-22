using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcTourney3.Migrations
{
    public partial class FirstAttemptAtSixModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Game",
                table: "Team");

            migrationBuilder.AddColumn<int>(
                name: "GametitleId",
                table: "Team",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team1Id = table.Column<int>(type: "int", nullable: true),
                    Team2Id = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Team1Score = table.Column<int>(type: "int", nullable: false),
                    Team2Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchGames_Team_Team1Id",
                        column: x => x.Team1Id,
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchGames_Team_Team2Id",
                        column: x => x.Team2Id,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team1Id = table.Column<int>(type: "int", nullable: true),
                    Team2Id = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Team1W = table.Column<int>(type: "int", nullable: false),
                    Team2W = table.Column<int>(type: "int", nullable: false),
                    GameTitlesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_GameTitles_GameTitlesId",
                        column: x => x.GameTitlesId,
                        principalTable: "GameTitles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Team_Team1Id",
                        column: x => x.Team1Id,
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Team_Team2Id",
                        column: x => x.Team2Id,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GametitleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournament_GameTitles_GametitleId",
                        column: x => x.GametitleId,
                        principalTable: "GameTitles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_GametitleId",
                table: "Team",
                column: "GametitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GameTitlesId",
                table: "Matches",
                column: "GameTitlesId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team1Id",
                table: "Matches",
                column: "Team1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team2Id",
                table: "Matches",
                column: "Team2Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGames_Team1Id",
                table: "MatchGames",
                column: "Team1Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGames_Team2Id",
                table: "MatchGames",
                column: "Team2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_GametitleId",
                table: "Tournament",
                column: "GametitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_GameTitles_GametitleId",
                table: "Team",
                column: "GametitleId",
                principalTable: "GameTitles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_GameTitles_GametitleId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "MatchGames");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropTable(
                name: "GameTitles");

            migrationBuilder.DropIndex(
                name: "IX_Team_GametitleId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "GametitleId",
                table: "Team");

            migrationBuilder.AddColumn<string>(
                name: "Game",
                table: "Team",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
