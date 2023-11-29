using ArgysApi.Models.Vinculos;
using ArgysApi.request.Vinculos;

namespace ArgysApi.mappers.Vinculos
{
    public static class VinculoMapper
    {
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
