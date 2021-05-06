using Microsoft.EntityFrameworkCore.Migrations;

namespace Shows4AllMicaela.Migrations
{
    public partial class removeEpisodeIdactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Actors_IdActor",
                table: "Episodes");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_IdActor",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "IdActor",
                table: "Episodes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdActor",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
