using ArgysApi.Models.Usuarios;
using ArgysApi.request.Usuarios;
using ArgysApi.response.Usuarios;

namespace ArgysApi.mappers.Usuarios
{
    public static class UsuarioMapper
    {
        public static UsuarioResponse ToUsuarioResponse(this Usuario usuario)
        {
            return new UsuarioResponse
            {
                Uuid = usuario.Uuid,
                Nome = usuario.Nome,
                UsuarioNome = usuario.UsuarioNome,
                Senha = usuario.Senha,
                Cpf = usuario.Cpf,
                Email = usuario.Email,
                Celular = usuario.Celular ?? null,
                DataInatividade = usuario.DataInatividade ?? null,
                TipoUsuario = usuario.TipoUsuario,
                AcessoFinanceiro = usuario.AcessoFinanceiro ?? null,
                AcessoSuporte = usuario.AcessoSuporte ?? null
            };
        }

        public static Usuario ToUsuarioEntity(this UsuarioRequest usuarioRequest)
        {
            return new Usuario
            {
                Uuid = Guid.NewGuid(),
                Nome = usuarioRequest.Nome,
                UsuarioNome = usuarioRequest.UsuarioNome,
                Senha = usuarioRequest.Senha,
                Cpf = usuarioRequest.Cpf,
                Email = usuarioRequest.Email,
                Celular = usuarioRequest.Celular,
                DataInatividade = usuarioRequest.DataInatividade,
                TipoUsuario = usuarioRequest.TipoUsuario,
                AcessoFinanceiro = usuarioRequest.AcessoFinanceiro,
                AcessoSuporte = usuarioRequest.AcessoSuporte
            };
        }
    }
}
