using ArgysApi.Data;
using ArgysApi.Models.Pessoas;
using Microsoft.EntityFrameworkCore;

internal static class VinculoMapperHelpers
{

    public static async Task<Pessoa> GetPessoa(long id, ArgysApiContext context)
    {
        var pessoa = await context.Pessoa.FirstOrDefaultAsync(x => x.Id == id);

        return pessoa;
    }
}