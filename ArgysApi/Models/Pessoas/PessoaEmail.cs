using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Pessoas
{
    [Table("pessoa_email", Schema = "dbo")]
    public class PessoaEmail
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
        [Column("email")]
        [MaxLength(255)]
        public string Email { get; set; }

        [ForeignKey("pessoa_id")]
        public Pessoa Pessoa { get; set; }
    }
}
