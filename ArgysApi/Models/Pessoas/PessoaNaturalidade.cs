using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Pessoas
{
    [Table("pessoa_naturalidade", Schema = "pimdb")]
    public class PessoaNaturalidade
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("pessoa_id")]
        public long PessoaId { get; set; }

        [Required]
        [Column("uf")]
        [MaxLength(45)]
        public string UF { get; set; }

        [Required]
        [Column("cidade")]
        [MaxLength(255)]
        public string Cidade { get; set; }

        [ForeignKey("pessoa_id")]
        public Pessoa Pessoa { get; set; }
    }
}
