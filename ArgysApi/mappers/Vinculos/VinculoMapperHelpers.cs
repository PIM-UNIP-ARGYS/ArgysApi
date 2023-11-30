using ArgysApi.Data;
using ArgysApi.Models.Pessoas;
using ArgysApi.Models.Vinculos;
using Microsoft.EntityFrameworkCore;

internal static class VinculoMapperHelpers
{
    public static async Task<Pessoa> GetPessoa(long id, ArgysApiContext context)
    {
        var pessoa = await context.Pessoa.FirstOrDefaultAsync(x => x.Id == id);

        return pessoa;
    }

    public static async Task<Cbo> GetCbo(long id, ArgysApiContext context)
    {
        var cbo = await context.Cbo.FirstOrDefaultAsync(x => x.Id == id);

        return cbo;
    }
}