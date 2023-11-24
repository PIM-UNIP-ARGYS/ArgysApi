using ArgysApi.Models.Empresas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Feriados
{
    [Table("feriado_empresa", Schema = "dbo")]
    public class FeriadoEmpresa
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
        [Column("feriado_id")]
        public long FeriadoId { get; set; }

        [ForeignKey("empresa_id")]
        public Empresa Empresa { get; set; }

        [ForeignKey("feriado_id")]
        public Feriado Feriado { get; set; }
    }
}
