using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Pessoas
{
    [Table("pessoa_telefone", Schema = "pimdb")]
    public class PessoaTelefone
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
        [Column("contato")]
        [MaxLength(255)]
        public string Contato { get; set; }

        [Required]
        [Column("telefone")]
        [MaxLength(45)]
        public string Telefone { get; set; }

        [Required]
        [Column("tipo")]
        [MaxLength(45)]
        public string Tipo { get; set; }

        [ForeignKey("pessoa_id")]
        public Pessoa Pessoa { get; set; }
    }
}
