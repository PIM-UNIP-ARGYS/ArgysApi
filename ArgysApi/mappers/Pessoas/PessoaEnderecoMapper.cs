using ArgysApi.Models.Pessoas;
using ArgysApi.Models.Usuarios;
using ArgysApi.request.Pessoas;
using ArgysApi.request.Usuarios;
using ArgysApi.response.Pessoas;
using ArgysApi.response.Usuarios;

namespace ArgysApi.mappers.Pessoas
{
    public static class PessoaEnderecoMapper
    {
        public static PessoaEndereco ToPessoaEntity(this PessoaRequest request, long PessoaId)
        {
            return new PessoaEndereco
            {
                Uuid = Guid.NewGuid().ToString(),
                Logradouro = request.Endereco.Logradouro,
                Cep = request.Endereco.Cep,
                Bairro = request.Endereco.Bairro,
                Cidade = request.Endereco.Cidade,   
                Numero = request.Endereco.Numero,
                Complemento = request.Endereco.Complemento,
                Pais = "Brasil",
                TipoEndereco = request.Endereco.Tipo,
                PessoaId = PessoaId
                
            };
        }
    }
}
