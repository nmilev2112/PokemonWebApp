using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonBackend.Migrations
{
    public partial class FixingRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Trainer_TrainerID",
                table: "Pokemon");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_TrainerID",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "TrainerID",
                table: "Pokemon");

            migrationBuilder.CreateTable(
                name: "PokemonTrainer",
                columns: table => new
                {
                    PokemonID = table.Column<int>(type: "int", nullable: false),
                    TrainersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTrainer", x => new { x.PokemonID, x.TrainersID });
                    table.ForeignKey(
                        name: "FK_PokemonTrainer_Pokemon_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "Pokemon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonTrainer_Trainer_TrainersID",
                        column: x => x.TrainersID,
                        principalTable: "Trainer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTrainer_TrainersID",
                table: "PokemonTrainer",
                column: "TrainersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonTrainer");

            migrationBuilder.AddColumn<int>(
                name: "TrainerID",
                table: "Pokemon",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_TrainerID",
                table: "Pokemon",
                column: "TrainerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Trainer_TrainerID",
                table: "Pokemon",
                column: "TrainerID",
                principalTable: "Trainer",
                principalColumn: "ID");
        }
    }
}
