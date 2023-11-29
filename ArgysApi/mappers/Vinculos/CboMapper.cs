using ArgysApi.Models.Vinculos;
using ArgysApi.request.Vinculos;

namespace ArgysApi.mappers.Vinculos
{
    public static class CboMapper
    {
        public static Cbo ToCboEntity(this CboRequest request)
        {
            return new Cbo
            {
                Uuid = Guid.NewGuid().ToString(),
                Descricao = request.Descricao,
                MotoristaProfissional = request.MotoristaProfissional == true ? "SIM" : "NAO",
                SalarioAula = request.SalarioAula == true ? "SIM" : "NAO"
            };
        }
    }
}
