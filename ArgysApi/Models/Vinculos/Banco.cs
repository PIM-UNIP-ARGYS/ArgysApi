using ArgysApi.Models.Empresas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("banco", Schema = "pimdb")]
    public class Banco
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
        [Column("codigo")]
        [MaxLength(45)]
        public string Codigo { get; set; }

        [Column("dg_verif")]
        [MaxLength(45)]
        public string? DgVerif { get; set; } // Permite valores nulos

        [Required]
        [Column("nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Column("site")]
        [MaxLength(255)]
        public string? Site { get; set; } // Permite valores nulos

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
    }
}
