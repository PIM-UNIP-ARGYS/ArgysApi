using ArgysApi.Models.Pessoas;
using ArgysApi.Models.Usuarios;
using ArgysApi.request.Pessoas;
using ArgysApi.request.Usuarios;
using ArgysApi.response.Pessoas;
using ArgysApi.response.Usuarios;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using Humanizer;

namespace ArgysApi.mappers.Pessoas
{
    public static class PessoaMapper
    {
        public static Pessoa ToPessoaEntity(this PessoaRequest request)
        {
            return new Pessoa
            {
                Uuid = Guid.NewGuid().ToString(),
                Nome = request.Nome,
                NomeSocial = request.NomeSocial,
                Genero = request.InformacoesPessoais.Sexo,
                Raca = request.InformacoesPessoais.Raca,
                EstadoCivil = request.InformacoesPessoais.EstadoCivil,
                DataNascimento = request.InformacoesPessoais.DataNascimento,
                GrauInstrucao = request.InformacoesPessoais.GrauInstituicao,
                Deficiencia = request.InformacoesPessoais.Deficiencia,
                Nacionalidade = request.InformacoesPessoais.Nacionalidade,
                CotaDeficiencia = request.InformacoesPessoais?.CotaDeficiencia == true ? "SIM" : "NAO",
                Proprietario = request.InformacoesPessoais?.Proprietario == true ? "SIM" : "NAO",
                NomeMae = request.InformacoesPessoais.Mae,
                NomePai = request.InformacoesPessoais.Pai ?? null,
                CPF = request.Documentos.Cpf,
                PIS_NIS = request.Documentos.PisNis,
                RG = request.Documentos.Rg + " - " + request.Documentos.RgDigito,
                RG_UF = request.Documentos.UfRg,
                RG_DataEmissao = request.Documentos.DataEmissaoRg,
                RgOrgaoExpedidor = request.Documentos.OrgaoExpedidor,
                TituloEleitor = request.TituloEleitor.TituloEleitor,
                TituloEleitorSecao = request.TituloEleitor.Secao,
                TituloEleitorZona = request.TituloEleitor.ZonaEleitoral,
                CnhNumero = null,
                CnhCategoria = null,
                CnhDataExpedicao = null,
                CnhDataPrimeiraHabilitacao = null,
                CnhDataValidade = null,
                CnhExpedicaoUF = null,
                CtpsNumero = request.Ctps.Numero,
                CtpsDataEmissao = request.Ctps.Expedicao,
                CtpsSerie = request.Ctps.Serie,
                CtpsUf = request.Ctps.Uf,
                PassaporteNumero = null,
                PassaporteDataValidade = null
            };
        }
    }
}
