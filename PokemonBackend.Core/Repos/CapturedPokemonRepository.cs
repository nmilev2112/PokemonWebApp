using PokemonBackend.Core.Data.Context;
using PokemonBackend.Core.Interfaces;

namespace PokemonBackend.Core.Repos
{
    public class CapturedPokemonRepository : ICapturedPokemonRepository
    {
        private readonly PokemonContext _pokemonContext;

        public CapturedPokemonRepository(PokemonContext pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }
    }
}
