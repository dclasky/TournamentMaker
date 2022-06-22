using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcTourney3.Migrations
{
    public partial class NullabilityAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchGames_Team_Team1Id",
                table: "MatchGames");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchGames_Team_Team2Id",
                table: "MatchGames");

            migrationBuilder.AlterColumn<int>(
                name: "Team2Id",
                table: "MatchGames",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Team1Id",
                table: "MatchGames",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchGames_Team_Team1Id",
                table: "MatchGames",
                column: "Team1Id",
                principalTable: "Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchGames_Team_Team2Id",
                table: "MatchGames",
                column: "Team2Id",
                principalTable: "Team",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchGames_Team_Team1Id",
                table: "MatchGames");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchGames_Team_Team2Id",
                table: "MatchGames");

            migrationBuilder.AlterColumn<int>(
                name: "Team2Id",
                table: "MatchGames",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Team1Id",
                table: "MatchGames",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchGames_Team_Team1Id",
                table: "MatchGames",
                column: "Team1Id",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchGames_Team_Team2Id",
                table: "MatchGames",
                column: "Team2Id",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
