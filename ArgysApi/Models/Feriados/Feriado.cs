using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Feriados
{
    [Table("feriado", Schema = "dbo")]
    public class Feriado
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("descricao")]
        [MaxLength(255)]
        public string Descricao { get; set; }

        [Required]
        [Column("dia")]
        [MaxLength(2)]
        public string Dia { get; set; }

        [Required]
        [Column("mes")]
        [MaxLength(2)]
        public string Mes { get; set; }

        [Required]
        [Column("ano")]
        [MaxLength(4)]
        public string Ano { get; set; }

        [Column("uf")]
        [MaxLength(45)]
        public string? Uf { get; set; } // Permite valores nulos
    }
}
