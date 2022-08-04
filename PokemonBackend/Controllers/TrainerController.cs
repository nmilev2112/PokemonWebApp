using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonBackend.Core.Data.Context;
using PokemonBackend.Core.Models;

namespace PokemonBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly PokemonContext _pokemonContext;

        public TrainerController(PokemonContext pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }

        [HttpGet]
        public async Task<List<Trainer>> GetAllTrainersAsync()
        {
            return await _pokemonContext.Trainers
                .Include(x => x.CapturedPokemon)
                .ThenInclude(x => x.Pokemon)
                .AsSplitQuery()
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Trainer> GetTrainerByID(int id)
        {
            return await _pokemonContext.Trainers
                .Include(x => x.CapturedPokemon)
                .ThenInclude(x => x.Pokemon)
                .AsSingleQuery()
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        [HttpPost]
        [Route("AddPokemon")]
        public async Task<Unit> AddPokemonToTrainer(List<int> ids, int trainerID, string name = null)
        {
            var pokemon = await _pokemonContext.Pokemon.Where(x => ids.Contains(x.ID)).ToListAsync();
            List<CapturedPokemon> pokemonToAdd = new();
            foreach(var poke in pokemon)
            {
                pokemonToAdd.Add(new CapturedPokemon
                {
                    Name = name,
                    Pokemon = poke
                });
            };
            var trainer = await _pokemonContext.Trainers.FirstOrDefaultAsync(x => x.ID == trainerID);
            if(trainer is not null)
            {
                trainer.CapturedPokemon = pokemonToAdd;
                _pokemonContext.Trainers.Update(trainer);
                await _pokemonContext.SaveChangesAsync();
            }
            return Unit.Value;
        }

        [HttpPost]
        public async Task<Unit> AddTrainer(Trainer trainer)
        {
            _pokemonContext.Trainers.Add(trainer);
            await _pokemonContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
