using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("vinculo_transp", Schema = "dbo")]
    public class VinculoTransporte
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
        [Column("vale_transporte")]
        [MaxLength(45)]
        public string ValeTransporte { get; set; }

        [Required]
        [Column("tipo_calculo")]
        [MaxLength(45)]
        public string TipoCalculo { get; set; }

        [Required]
        [Column("quant_dia")]
        public int QuantidadeDias { get; set; }

        [Required]
        [Column("val_unit")]
        public decimal ValorUnitario { get; set; }

        [ForeignKey("VinculoId")]
        public Vinculo Vinculo { get; set; }
    }
}
