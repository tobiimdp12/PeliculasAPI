using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculasAPI.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovies_Movies_CharactersId",
                table: "CharacterMovies");

            migrationBuilder.RenameColumn(
                name: "CharactersId",
                table: "CharacterMovies",
                newName: "MoviesId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterMovies_CharactersId",
                table: "CharacterMovies",
                newName: "IX_CharacterMovies_MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovies_Movies_MoviesId",
                table: "CharacterMovies",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovies_Movies_MoviesId",
                table: "CharacterMovies");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "CharacterMovies",
                newName: "CharactersId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterMovies_MoviesId",
                table: "CharacterMovies",
                newName: "IX_CharacterMovies_CharactersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovies_Movies_CharactersId",
                table: "CharacterMovies",
                column: "CharactersId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
