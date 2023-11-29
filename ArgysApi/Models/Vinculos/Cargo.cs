using ArgysApi.Models.Empresas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("cargo", Schema = "dbo")]
    public class Cargo
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
        [Column("cbo_id")]
        public long CboId { get; set; }

        [Required]
        [Column("codigo")]
        [MaxLength(45)]
        public string Codigo { get; set; }

        [Required]
        [Column("descricao")]
        [MaxLength(45)]
        public string Descricao { get; set; }
    }
}
