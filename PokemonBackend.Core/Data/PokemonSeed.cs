using Microsoft.EntityFrameworkCore;
using PokemonBackend.Core.Data.Context;
using PokemonBackend.Core.Models;

namespace PokemonBackend.Core
{
    public static class PokemonSeed
    {
        public async static void Seed(this PokemonContext dbContext)
        {
            if (!dbContext.Trainers.Any())
            {
                List<int> randomPokemon = new List<int>() { 1, 5, 11, 24, 65, 89, 95 };
                var pokemonToAdd = await dbContext.Pokemon.Where(x => randomPokemon.Contains(x.ID)).ToListAsync();
                dbContext.Trainers.Add(new Trainer
                {
                    FirstName = "Nick",
                    LastName = "Milev",
                    Age = 25,
                    Height = 178
                });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
