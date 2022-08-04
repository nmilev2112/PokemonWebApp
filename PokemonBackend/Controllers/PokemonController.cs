using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonBackend.Core.Data.Context;
using PokemonBackend.Core.Models;

namespace PokemonBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonContext _pokemonContext;

        public PokemonController(PokemonContext pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }

        [HttpGet]
        public async Task<List<Pokemon>> GetAllPokemonAsync()
        {
            var test = await _pokemonContext.Pokemon.OrderBy(x => x.ID).ToListAsync();
            return test;
        }

        [HttpGet("{id}")]
        public async Task<Pokemon> GetPokemonByIDAsync(int id)
        {
            var test = await _pokemonContext.Pokemon.FirstOrDefaultAsync(x => x.ID == id);
            return test;
        }

        [HttpDelete("{id}")]
        public async Task<Unit> DeletePokemonByID(int id)
        {
            var toDelete = await _pokemonContext.Pokemon.FirstOrDefaultAsync(x => x.ID == id);
            if(toDelete != null)
            {
                _pokemonContext.Pokemon.Remove(toDelete);
                await _pokemonContext.SaveChangesAsync();
            }
            return Unit.Value;
        }

        [HttpPost]
        public async Task<Unit> AddPokemonAsync(Pokemon pokemon)
        {
            await _pokemonContext.AddAsync(pokemon);
            await _pokemonContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
