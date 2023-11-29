using ArgysApi.Models.Vinculos;
using ArgysApi.request.Vinculos;

namespace ArgysApi.mappers.Vinculos
{
    public static class VinculoCargoMapper
    {
        public static VinculoCargo ToVinculoCargoEntity(this long vinculoId, long cargoId)
        {
            return new VinculoCargo
            {
                Uuid = Guid.NewGuid().ToString(),
                CargoId = cargoId,
                VinculoId = vinculoId
            };
        }
    }
}
