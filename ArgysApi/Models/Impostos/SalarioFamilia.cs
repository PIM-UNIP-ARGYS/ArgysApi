using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Impostos
{
    [Table("salario_familia", Schema = "dbo")]
    public class SalarioFamilia
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
        [Column("valor_sal_fam", TypeName = "decimal(10,0)")]
        public decimal ValorSalarioFamilia { get; set; }
    }
}
