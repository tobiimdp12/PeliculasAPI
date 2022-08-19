using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculasAPI.Migrations
{
    public partial class dataFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovies_Characters_CharacterdId",
                table: "CharacterMovies");

            migrationBuilder.RenameColumn(
                name: "CharacterdId",
                table: "CharacterMovies",
                newName: "CharactersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovies_Characters_CharactersId",
                table: "CharacterMovies",
                column: "CharactersId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovies_Characters_CharactersId",
                table: "CharacterMovies");

            migrationBuilder.RenameColumn(
                name: "CharactersId",
                table: "CharacterMovies",
                newName: "CharacterdId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovies_Characters_CharacterdId",
                table: "CharacterMovies",
                column: "CharacterdId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
