using HotChocolate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonBackend.Core.Models
{
    [Table("CapturedPokemon")]
    public class CapturedPokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [GraphQLNonNullType]
        public Pokemon Pokemon { get; set; }

        public string Name { get; set; }

        [GraphQLNonNullType]
        public DateTime CaptureDate { get; set; }
    }
}
