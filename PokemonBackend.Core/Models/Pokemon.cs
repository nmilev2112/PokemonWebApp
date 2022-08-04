using HotChocolate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonBackend.Core.Models
{
    [Table("Pokemon")]
    public class Pokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [GraphQLNonNullType]
        public string NameEnglish { get; set; }

        public string NameJapanese { get; set; }

        public string NameChinese { get; set; }

        public string NameFrench { get; set; }

        [GraphQLNonNullType]
        public string Type0 { get; set; }

        public string Type1 { get; set; }

        [GraphQLNonNullType]
        public int BaseHP { get; set; }

        [GraphQLNonNullType]
        public int BaseAttack { get; set; }

        [GraphQLNonNullType]
        public int BaseDefense { get; set; }

        [GraphQLNonNullType]
        public int BaseSP_Attack { get; set; }

        [GraphQLNonNullType]
        public int BaseSP_Defense { get; set; }

        [GraphQLNonNullType]
        public int BaseSpeed { get; set; }
    }
}
