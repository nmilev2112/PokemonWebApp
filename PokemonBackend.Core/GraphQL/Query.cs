using System.Linq;
using HotChocolate;
using PokemonBackend.Core.Data.Context;
using PokemonBackend.Core.Models;

namespace PokemonBackend.Core.GraphQLs
{
    [GraphQLDescription("Represents the queries available.")]
    public class Query
    {
        /// <summary>
        /// Gets the queryable <see cref="Pokemon"/>.
        /// </summary>
        /// <param name="context">The <see cref="PokemonContext"/>.</param>
        /// <returns>The queryable <see cref="Pokemon"/>.</returns>
        [GraphQLDescription("Gets the queryable pokemon.")]
        public IQueryable<Pokemon> GetPokemon([Service] PokemonContext context)
        {
            return context.Pokemon;
        }

        /// <summary>
        /// Gets the queryable <see cref="Trainer"/>.
        /// </summary>
        /// <param name="context">The <see cref="PokemonContext"/>.</param>
        /// <returns>The queryable <see cref="Trainer"/>.</returns>
        [GraphQLDescription("Gets the queryable trainer.")]
        public IQueryable<Trainer> GetTrainers([Service] PokemonContext context)
        {
            return context.Trainers;
        }
    }
}
