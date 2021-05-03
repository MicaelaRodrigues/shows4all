using Microsoft.EntityFrameworkCore.Migrations;

namespace Shows4AllMicaela.Migrations
{
    public partial class AddFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Series",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Seasons",
                newName: "NumberOfSeason");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Seasons",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Episodes",
                newName: "NumberOfEpisode");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Episodes",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "IdEpisode",
                table: "Seasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSerie",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSerie",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdActor",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_IdEpisode",
                table: "Seasons",
                column: "IdEpisode");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_IdSerie",
                table: "Rentals",
                column: "IdSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_IdUser",
                table: "Rentals",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_IdSerie",
                table: "Ratings",
                column: "IdSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_IdUser",
                table: "Ratings",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_IdActor",
                table: "Episodes",
                column: "IdActor");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Actors_IdActor",
                table: "Episodes",
                column: "IdActor",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Series_IdSerie",
                table: "Ratings",
                column: "IdSerie",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_IdUser",
                table: "Ratings",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Series_IdSerie",
                table: "Rentals",
                column: "IdSerie",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Users_IdUser",
                table: "Rentals",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Episodes_IdEpisode",
                table: "Seasons",
                column: "IdEpisode",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Actors_IdActor",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Series_IdSerie",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_IdUser",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Series_IdSerie",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Users_IdUser",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Episodes_IdEpisode",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_IdEpisode",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_IdSerie",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_IdUser",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_IdSerie",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_IdUser",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_IdActor",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "IdEpisode",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "IdSerie",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "IdSerie",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "IdActor",
                table: "Episodes");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Series",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Seasons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NumberOfSeason",
                table: "Seasons",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Episodes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NumberOfEpisode",
                table: "Episodes",
                newName: "Number");
        }
    }
}
