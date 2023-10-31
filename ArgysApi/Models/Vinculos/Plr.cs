using ArgysApi.Models.Empresas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("plr", Schema = "pimdb")]
    public class Plr
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
        [Column("referencia_inicial")]
        [MaxLength(45)]
        public string ReferenciaInicial { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }

    }
}
