using ArgysApi.Data;
using ArgysApi.Models.Vinculos;
using ArgysApi.request.Vinculos;
using ArgysApi.response.Vinculos;

namespace ArgysApi.mappers.Vinculos
{
    public static class CboMapper
    {
        public static CboResumeResponse ToResumeResponse(this Cbo model)
        {
            return new CboResumeResponse
            {
                Uuid = model.Uuid,
                Codigo = model.Codigo,
                Descricao = model.Descricao,
                MotoristaProfissional = model.MotoristaProfissional == "SIM" ? "Sim" : "Não",
                SalarioAula = model.SalarioAula == "SIM" ? "Sim" : "Não"
            };
        }

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
