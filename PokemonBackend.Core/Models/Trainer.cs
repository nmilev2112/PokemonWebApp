using HotChocolate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonBackend.Core.Models
{
    [Table("Trainer")]
    public class Trainer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [GraphQLNonNullType]
        public string FirstName { get; set; }

        [GraphQLNonNullType]
        public string LastName { get; set; }

        [GraphQLNonNullType]
        public int Age { get; set; }

        [GraphQLNonNullType]
        public int Height { get; set; }

        public ICollection<CapturedPokemon> CapturedPokemon { get; set; }
    }
}
