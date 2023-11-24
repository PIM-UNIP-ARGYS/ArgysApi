using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("vinculo_salario", Schema = "dbo")]
    public class VinculoSalario
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("vinculo_id")]
        public long VinculoId { get; set; }

        [Required]
        [Column("tp_pag")]
        [MaxLength(45)]
        public string TipoPagamento { get; set; }

        [Required]
        [Column("vl_sal")]
        public decimal ValorSalario { get; set; }

        [Required]
        [Column("reajustar_sal")]
        public decimal ReajustarSalario { get; set; }

        [Required]
        [Column("n_horas_mensais")]
        public int NumeroHorasMensais { get; set; }

        [Required]
        [Column("reajustar_horas")]
        public decimal ReajustarHoras { get; set; }

        [Required]
        [Column("dt_inc_sal")]
        public DateTime DataInclusaoSalario { get; set; }

        [Required]
        [Column("porct_comis_vendas")]
        public decimal PorcentagemComissaoVendas { get; set; }

        [Column("motivo")]
        [MaxLength(255)]
        public string Motivo { get; set; }

        [ForeignKey("VinculoId")]
        public Vinculo Vinculo { get; set; }
    }
}
