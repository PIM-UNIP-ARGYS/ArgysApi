using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("agencia_email", Schema = "pimdb")]
    public class AgenciaEmail
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("agencia_id")]
        public long AgenciaId { get; set; }

        [Required]
        [Column("contato")]
        [MaxLength(255)]
        public string Contato { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(255)]
        public string Email { get; set; }

        [ForeignKey("AgenciaId")]
        public Agencia Agencia { get; set; }
    }
}
