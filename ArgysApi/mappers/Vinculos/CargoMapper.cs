using ArgysApi.Models.Vinculos;
using ArgysApi.request.Vinculos;

namespace ArgysApi.mappers.Vinculos
{
    public static class CargoMapper
    {
        public static Cargo ToCargoEntity(this CargoRequest request)
        {
            return new Cargo
            {
                Uuid = Guid.NewGuid().ToString(),
                EmpresaId = 1L, //Empresa Default
                Descricao = request.Descricao,
            };
        }
    }
}
