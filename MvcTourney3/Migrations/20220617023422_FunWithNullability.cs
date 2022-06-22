using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcTourney3.Migrations
{
    public partial class FunWithNullability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_GameTitles_GametitleId",
                table: "Tournament");

            migrationBuilder.AlterColumn<int>(
                name: "GametitleId",
                table: "Tournament",
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
                name: "FK_Tournament_GameTitles_GametitleId",
                table: "Tournament",
                column: "GametitleId",
                principalTable: "GameTitles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_GameTitles_GametitleId",
                table: "Tournament");

            migrationBuilder.AlterColumn<int>(
                name: "GametitleId",
                table: "Tournament",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_GameTitles_GametitleId",
                table: "Tournament",
                column: "GametitleId",
                principalTable: "GameTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
