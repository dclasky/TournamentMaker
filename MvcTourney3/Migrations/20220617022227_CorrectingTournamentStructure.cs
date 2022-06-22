using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcTourney3.Migrations
{
    public partial class CorrectingTournamentStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_GameTitles_GametitleId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_GameTitles_GametitleId",
                table: "Tournament");

            migrationBuilder.AlterColumn<int>(
                name: "GametitleId",
                table: "Tournament",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchesId",
                table: "Tournament",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GametitleId",
                table: "Team",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Player",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_MatchesId",
                table: "Tournament",
                column: "MatchesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_GameTitles_GametitleId",
                table: "Team",
                column: "GametitleId",
                principalTable: "GameTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_GameTitles_GametitleId",
                table: "Tournament",
                column: "GametitleId",
                principalTable: "GameTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_Matches_MatchesId",
                table: "Tournament",
                column: "MatchesId",
                principalTable: "Matches",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_GameTitles_GametitleId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_GameTitles_GametitleId",
                table: "Tournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_Matches_MatchesId",
                table: "Tournament");

            migrationBuilder.DropIndex(
                name: "IX_Tournament_MatchesId",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "MatchesId",
                table: "Tournament");

            migrationBuilder.AlterColumn<int>(
                name: "GametitleId",
                table: "Tournament",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GametitleId",
                table: "Team",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Player",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_GameTitles_GametitleId",
                table: "Team",
                column: "GametitleId",
                principalTable: "GameTitles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_GameTitles_GametitleId",
                table: "Tournament",
                column: "GametitleId",
                principalTable: "GameTitles",
                principalColumn: "Id");
        }
    }
}
