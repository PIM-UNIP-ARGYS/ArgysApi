using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Impostos
{
    [Table("irrf", Schema = "dbo")]
    public class Irrf
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("limite_rend", TypeName = "decimal(10,0)")]
        public decimal LimiteRenda { get; set; }

        [Required]
        [Column("aliquota", TypeName = "decimal(10,0)")]
        public decimal Aliquota { get; set; }

        [Required]
        [Column("valor_deducao", TypeName = "decimal(10,0)")]
        public decimal ValorDeducao { get; set; }
    }
}
