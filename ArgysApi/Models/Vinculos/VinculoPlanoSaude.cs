using ArgysApi.Models.Impostos;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("vinculo_plan_saude", Schema = "pimdb")]
    public class VinculoPlanoSaude
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
        [Column("plano_saude_id")]
        public long PlanoSaudeId { get; set; }

        [Required]
        [Column("dt_inicial")]
        public DateTime DataInicial { get; set; }

        [Column("dt_final")]
        public DateTime? DataFinal { get; set; }

        [Required]
        [Column("val")]
        public decimal Valor { get; set; }

        [ForeignKey("VinculoId")]
        public Vinculo Vinculo { get; set; }

        [ForeignKey("PlanoSaudeId")]
        public PlanoSaude PlanoSaude { get; set; }
    }
}
