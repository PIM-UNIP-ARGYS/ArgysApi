using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Empresas
{
    [Table("grupo_empresa", Schema = "dbo")]
    public class GrupoEmpresa
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("codigo")]
        [MaxLength(45)]
        public string Codigo { get; set; }

        [Required]
        [Column("descricao")]
        [MaxLength(255)]
        public string Descricao { get; set; }
    }
}
