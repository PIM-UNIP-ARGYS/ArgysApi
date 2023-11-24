using ArgysApi.Models.Admin;
using ArgysApi.request.Admin;

namespace ArgysApi.mappers.Admin
{
    public class AdministradoraMapper
    {
        public AdministradoraResponse MapToResponse(Administradora administradora)
        {
            if (administradora == null)
            {
                return null;
            }

            return new AdministradoraResponse
            {
                Uuid = administradora.Uuid,
                RazaoSocial = administradora.RazaoSocial,
                NomeFantasia = administradora.NomeFantasia,
                Site = administradora.Site ?? null,
                Cpf = administradora.Cpf ?? null,
                Cnpj = administradora.Cnpj ?? null,
                Cei = administradora.Cei ?? null,
                Ie = administradora.Ie ?? null,
                Im = administradora.Im ?? null
            };
        }

        public Administradora MapToEntity(AdministradoraRequest request)
        {
            if (request == null)
            {
                return null;
            }

            return new Administradora
            {
                Uuid = Guid.NewGuid(),
                RazaoSocial = request.RazaoSocial,
                NomeFantasia = request.NomeFantasia,
                Site = request.Site,
                Cpf = request.Cpf,
                Cnpj = request.Cnpj,
                Cei = request.Cei,
                Ie = request.Ie,
                Im = request.Im
            };
        }
    }
}
