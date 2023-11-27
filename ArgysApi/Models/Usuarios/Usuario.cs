using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Usuarios
{
    [Table("usuario", Schema = "dbo")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [Column("usuario")]
        [MaxLength(255)]
        public string UsuarioNome { get; set; }

        [Required]
        [Column("senha")]
        [MaxLength(255)]
        public string Senha { get; set; }

        [Required]
        [Column("cpf")]
        [MaxLength(14)]
        public string Cpf { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Column("celular")]
        [MaxLength(13)]
        public string? Celular { get; set; } // Permite valores nulos

        [Column("dt_inatividade")]
        public DateTime? DataInatividade { get; set; } // Permite valores nulos

        [Required]
        [Column("tipo_usuario")]
        [MaxLength(50)]
        public string TipoUsuario { get; set; }

        [Column("acesso_financeiro")]
        [MaxLength(3)]
        public string? AcessoFinanceiro { get; set; } // Permite valores nulos

        [Column("acesso_suporte")]
        [MaxLength(3)]
        public string? AcessoSuporte { get; set; } // Permite valores nulos
    }
}
