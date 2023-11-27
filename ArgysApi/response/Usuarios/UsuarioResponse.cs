namespace ArgysApi.response.Usuarios
{
    public class UsuarioResponse
    {
        public string Uuid { get; set; }
        public string Nome { get; set; }
        public string UsuarioNome { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string? Celular { get; set; }
        public DateTime? DataInatividade { get; set; }
        public string TipoUsuario { get; set; }
        public string? AcessoFinanceiro { get; set; }
        public string? AcessoSuporte { get; set; }
    }
}
