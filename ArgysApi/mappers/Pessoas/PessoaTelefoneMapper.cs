using ArgysApi.Models.Pessoas;
using ArgysApi.Models.Usuarios;
using ArgysApi.request.Pessoas;
using ArgysApi.request.Usuarios;
using ArgysApi.response.Pessoas;
using ArgysApi.response.Usuarios;

namespace ArgysApi.mappers.Pessoas
{
    public static class PessoaTelefoneMapper
    {
        public static PessoaTelefone ToPessoaEntity(this PessoaRequest request, long PessoaId)
        {
            return new PessoaTelefone
            {
                Uuid = Guid.NewGuid().ToString(),
                Contato = request.Telefone.Contato,
                Telefone = request.Telefone.Telefone,
                Tipo = request.Telefone.Tipo,
                PessoaId = PessoaId
            };
        }
    }
}
