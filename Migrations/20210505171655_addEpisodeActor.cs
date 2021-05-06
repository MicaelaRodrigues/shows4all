using Microsoft.EntityFrameworkCore.Migrations;

namespace Shows4AllMicaela.Migrations
{
    public partial class addEpisodeActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EpisodeActors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdActor = table.Column<int>(type: "int", nullable: false),
                    IdEpisode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeActors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EpisodeActors_Actors_IdActor",
                        column: x => x.IdActor,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeActors_Episodes_IdEpisode",
                        column: x => x.IdEpisode,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeActors_IdActor",
                table: "EpisodeActors",
                column: "IdActor");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeActors_IdEpisode",
                table: "EpisodeActors",
                column: "IdEpisode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeActors");
        }
    }
}
