using ArgysApi.Data;
using ArgysApi.Models.Pessoas;
using ArgysApi.Models.Vinculos;
using ArgysApi.request.Vinculos;
using ArgysApi.response.Pessoas;
using ArgysApi.response.Vinculos;
using Microsoft.EntityFrameworkCore;

namespace ArgysApi.mappers.Vinculos
{
    public static class VinculoMapper
    {
        public static VinculoResumeResponse ToResumeResponse(this Vinculo model, ArgysApiContext context)
        {
            var pessoa = VinculoMapperHelpers.GetPessoa(model.PessoaId, context);

            return new VinculoResumeResponse
            {
                Uuid = model.Uuid,
                Matricula = model.Matricula,
                Trabalhador = pessoa.Result.Nome,
                DataAdmissão = model.DtAdmissao.ToString("dd/MM/yyyy"),
                Cpf = pessoa.Result.CPF
            };
        }

        public static Vinculo ToVinculoEntity(this VinculoRequest request)
        {
            return new Vinculo
            {
                Uuid = Guid.NewGuid().ToString(),
                DtAdmissao = request.DtAdmissao,
                DtFgts = request.DtFgts,
                FgtsBancoId = null,
                RemBancoId = null,
            };
        }
    }
}
