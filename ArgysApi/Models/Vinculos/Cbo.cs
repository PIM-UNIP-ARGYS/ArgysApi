using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("cbo", Schema = "pimdb")]
    public class Cbo
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("codigo")]
        [MaxLength(45)]
        public string Codigo { get; set; }

        [Required]
        [Column("descricao")]
        [MaxLength(45)]
        public string Descricao { get; set; }

        [Column("salario_aula")]
        [MaxLength(10)]
        public string? SalarioAula { get; set; } // Permite valores nulos

        [Column("motorista_profissional")]
        [MaxLength(10)]
        public string? MotoristaProfissional { get; set; } // Permite valores nulos
    }
}
