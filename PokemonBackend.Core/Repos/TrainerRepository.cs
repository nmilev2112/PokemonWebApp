using PokemonBackend.Core.Data.Context;
using PokemonBackend.Core.Interfaces;

namespace PokemonBackend.Core.Repos
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly PokemonContext _pokemonContext;

        public TrainerRepository(PokemonContext pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }
    }
}
