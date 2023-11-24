using System.ComponentModel.DataAnnotations;

namespace ArgysApi.request.Usuarios
{
    public class UsuarioRequest
    {

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(255)]
        public string UsuarioNome { get; set; }

        [Required]
        [MaxLength(255)]
        public string Senha { get; set; }

        [Required]
        [MaxLength(14)]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(13)]
        public string? Celular { get; set; }

        public DateTime? DataInatividade { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipoUsuario { get; set; }

        [MaxLength(3)]
        public string? AcessoFinanceiro { get; set; }

        [MaxLength(3)]
        public string? AcessoSuporte { get; set; }
    }
}
