using Microsoft.EntityFrameworkCore;
using PokemonBackend.Core.Data.Context;
using PokemonBackend.Core.GraphQL;
using PokemonBackend.Core.Interfaces;
using PokemonBackend.Core.Repos;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PokemonConnectionString");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddGraphQL().AddQueryType<Query>();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PokemonContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<ICapturedPokemonRepository, CapturedPokemonRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGraphQL("/graphql");

app.UseWebSockets();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var servicescope = app.Services.CreateScope();

app.Run();

