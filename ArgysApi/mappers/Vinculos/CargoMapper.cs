using ArgysApi.Data;
using ArgysApi.Models.Vinculos;
using ArgysApi.request.Vinculos;
using ArgysApi.response.Vinculos;

namespace ArgysApi.mappers.Vinculos
{
    public static class CargoMapper
    {
        public static CargoResumeResponse ToResumeResponse(this Cargo model, ArgysApiContext context)
        {
            var cbo = VinculoMapperHelpers.GetCbo(model.CboId, context);

            return new CargoResumeResponse
            {
                Uuid = model.Uuid,
                Codigo = model.Codigo,
                CodigoCbo = cbo.Result.Codigo,
                Descricao = model.Descricao,
            };
        }

        public static Cargo ToCargoEntity(this CargoRequest request)
        {
            return new Cargo
            {
                Uuid = Guid.NewGuid().ToString(),
                EmpresaId = 4L, //Empresa Default
                Descricao = request.Descricao,
            };
        }
    }
}
