using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("agencia_telefone", Schema = "pimdb")]
    public class AgenciaTelefone
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
        [Column("telefone")]
        [MaxLength(45)]
        public string Telefone { get; set; }

        [Required]
        [Column("tipo")]
        [MaxLength(45)]
        public string Tipo { get; set; }

        [ForeignKey("AgenciaId")]
        public Agencia Agencia { get; set; }
    }
}
