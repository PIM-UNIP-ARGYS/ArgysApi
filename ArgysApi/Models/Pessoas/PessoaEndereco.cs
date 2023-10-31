using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Pessoas
{
    [Table("pessoa_endereco", Schema = "pimdb")]
    public class PessoaEndereco
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
        [Column("logradouro")]
        [MaxLength(255)]
        public string Logradouro { get; set; }

        [Required]
        [Column("bairro")]
        [MaxLength(255)]
        public string Bairro { get; set; }

        [Required]
        [Column("cep")]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Required]
        [Column("cidade")]
        [MaxLength(255)]
        public string Cidade { get; set; }

        [Required]
        [Column("pais")]
        [MaxLength(255)]
        public string Pais { get; set; }

        [Required]
        [Column("numero")]
        [MaxLength(45)]
        public string Numero { get; set; }

        [Column("complemento")]
        [MaxLength(45)]
        public string? Complemento { get; set; } // Permite valores nulos

        [Required]
        [Column("tipo_endereco")]
        [MaxLength(45)]
        public string TipoEndereco { get; set; }

        [ForeignKey("pessoa_id")]
        public Pessoa Pessoa { get; set; }
    }
}
