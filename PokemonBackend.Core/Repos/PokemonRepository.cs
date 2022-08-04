using PokemonBackend.Core.Data.Context;
using PokemonBackend.Core.Interfaces;

namespace PokemonBackend.Core.Repos
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonContext _pokemonContext;

        public PokemonRepository(PokemonContext pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }
    }
}
