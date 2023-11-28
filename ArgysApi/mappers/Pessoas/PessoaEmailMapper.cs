using ArgysApi.Models.Pessoas;
using ArgysApi.Models.Usuarios;
using ArgysApi.request.Pessoas;
using ArgysApi.request.Usuarios;
using ArgysApi.response.Pessoas;
using ArgysApi.response.Usuarios;

namespace ArgysApi.mappers.Pessoas
{
    public static class PessoaEmailMapper
    {
        public static PessoaEmail ToPessoaEntity(this PessoaRequest request, long PessoaId)
        {
            return new PessoaEmail
            {
                Uuid = Guid.NewGuid().ToString(),
                Contato = request.Email.Contato,
                Email = request.Email.Email,
                PessoaId = PessoaId,
            };
        }
    }
}
