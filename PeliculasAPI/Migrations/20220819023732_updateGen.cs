using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculasAPI.Migrations
{
    public partial class updateGen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genre_GeneroId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "GeneroId",
                table: "Movies",
                newName: "genreId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_GeneroId",
                table: "Movies",
                newName: "IX_Movies_genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genre_genreId",
                table: "Movies",
                column: "genreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genre_genreId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "Movies",
                newName: "GeneroId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_genreId",
                table: "Movies",
                newName: "IX_Movies_GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genre_GeneroId",
                table: "Movies",
                column: "GeneroId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
