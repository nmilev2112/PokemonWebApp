using Microsoft.EntityFrameworkCore;
using PokemonBackend.Core.Models;

namespace PokemonBackend.Core.Data.Context
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<CapturedPokemon> CapturedPokemon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                
        }
    }
}
