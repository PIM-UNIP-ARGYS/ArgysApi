using ArgysApi.Models.Vinculos;
using ArgysApi.request.Vinculos;

namespace ArgysApi.mappers.Vinculos
{
    public static class VinculoSalarioMapper
    {
        public static VinculoSalario ToEntity(this VinculoRequest request, long vinculoId)
        {
            return new VinculoSalario
            {
                Uuid = Guid.NewGuid().ToString(),
                VinculoId = vinculoId,
                ValorSalario = decimal.Parse(request.Salario),
                DataInclusaoSalario = new DateTime(),
                Motivo = "default",
                NumeroHorasMensais = 220,
                PorcentagemComissaoVendas = decimal.Zero,
                ReajustarHoras = decimal.Zero,
                ReajustarSalario = decimal.Zero,
                TipoPagamento = request.TipoPagamento
            };
        }
    }
}
