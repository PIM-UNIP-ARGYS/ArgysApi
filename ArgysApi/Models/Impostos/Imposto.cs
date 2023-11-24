using ArgysApi.Models.Empresas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Impostos
{
    [Table("impostos", Schema = "dbo")]
    public class Imposto
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("empresa_id")]
        public long EmpresaId { get; set; }

        [Required]
        [Column("referencia")]
        [MaxLength(8)]
        public string Referencia { get; set; }

        [Required]
        [Column("aliq_fundo_garantia", TypeName = "decimal(10,0)")]
        public decimal AliquotaFundoGarantia { get; set; }

        [Required]
        [Column("aliq_desc_vale_transp", TypeName = "decimal(10,0)")]
        public decimal AliquotaDescontoValeTransporte { get; set; }

        [Required]
        [Column("salario_minimo", TypeName = "decimal(10,0)")]
        public decimal SalarioMinimo { get; set; }

        [Required]
        [Column("teto_inss", TypeName = "decimal(10,0)")]
        public decimal TetoINSS { get; set; }

        [Required]
        [Column("ded_dep_irrf", TypeName = "decimal(10,0)")]
        public decimal DeducaoDependenteIRRF { get; set; }

        [Required]
        [Column("disp_ret_irrf", TypeName = "decimal(10,0)")]
        public decimal DispensaRetencaoIRRF { get; set; }

        [Required]
        [Column("aliq_inss_socio_diretor", TypeName = "decimal(10,0)")]
        public decimal AliquotaINSSSocioDiretor { get; set; }

        [Required]
        [Column("aliq_inss_aut", TypeName = "decimal(10,0)")]
        public decimal AliquotaINSSAutonomo { get; set; }

        [Required]
        [Column("valor_min_gps", TypeName = "decimal(10,0)")]
        public decimal ValorMinimoGPS { get; set; }

        [Required]
        [Column("porc_max_comp_gps", TypeName = "decimal(10,0)")]
        public decimal PorcentagemMaximaComplementoGPS { get; set; }

        [Required]
        [Column("base_irrf", TypeName = "decimal(10,0)")]
        public decimal BaseIRRF { get; set; }

        [Required]
        [Column("base_inss", TypeName = "decimal(10,0)")]
        public decimal BaseINSS { get; set; }

        [Required]
        [Column("transp_passageiros", TypeName = "decimal(10,0)")]
        public decimal TransportePassageiros { get; set; }

        [Required]
        [Column("inss_id")]
        public long InssId { get; set; }

        [Required]
        [Column("irrf_id")]
        public long IrrfId { get; set; }

        [Required]
        [Column("salario_familia_id")]
        public long SalarioFamiliaId { get; set; }

        [ForeignKey("empresa_id")]
        public Empresa Empresa { get; set; }

        [ForeignKey("inss_id")]
        public Inss Inss { get; set; }

        [ForeignKey("irrf_id")]
        public Irrf Irrf { get; set; }

        [ForeignKey("salario_familia_id")]
        public SalarioFamilia SalarioFamilia { get; set; }
    }
}
