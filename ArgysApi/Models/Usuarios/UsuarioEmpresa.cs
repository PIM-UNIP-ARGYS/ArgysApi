using ArgysApi.Models.Empresas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Usuarios
{
    [Table("usuario_empresa", Schema = "pimdb")]
    public class UsuarioEmpresa
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("usuario_id")]
        public long UsuarioId { get; set; }

        [Column("empresa_id")]
        public long? EmpresaId { get; set; } // Permite valores nulos

        [Required]
        [Column("tipo_acesso")]
        [MaxLength(45)]
        public string TipoAcesso { get; set; }

        [ForeignKey("usuario_id")]
        public Usuario Usuario { get; set; }

        [ForeignKey("empresa_id")]
        public Empresa? Empresa { get; set; }
    }
}
