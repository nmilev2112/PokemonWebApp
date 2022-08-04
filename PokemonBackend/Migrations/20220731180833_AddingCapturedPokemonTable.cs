using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonBackend.Migrations
{
    public partial class AddingCapturedPokemonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonTrainer");

            migrationBuilder.CreateTable(
                name: "CapturedPokemon",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PokemonID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaptureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapturedPokemon", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CapturedPokemon_Pokemon_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "Pokemon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapturedPokemon_Trainer_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "Trainer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapturedPokemon_PokemonID",
                table: "CapturedPokemon",
                column: "PokemonID");

            migrationBuilder.CreateIndex(
                name: "IX_CapturedPokemon_TrainerID",
                table: "CapturedPokemon",
                column: "TrainerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapturedPokemon");

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
    }
}
