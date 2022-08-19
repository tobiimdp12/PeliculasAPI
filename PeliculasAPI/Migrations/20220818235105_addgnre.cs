using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculasAPI.Migrations
{
    public partial class addgnre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genre_genreId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_genreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "genreId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GeneroId",
                table: "Movies",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genre_GeneroId",
                table: "Movies",
                column: "GeneroId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genre_GeneroId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GeneroId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "genreId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_genreId",
                table: "Movies",
                column: "genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genre_genreId",
                table: "Movies",
                column: "genreId",
                principalTable: "Genre",
                principalColumn: "Id");
        }
    }
}
