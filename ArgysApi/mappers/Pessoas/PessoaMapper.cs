using ArgysApi.Models.Pessoas;
using ArgysApi.Models.Usuarios;
using ArgysApi.request.Pessoas;
using ArgysApi.request.Usuarios;
using ArgysApi.response.Pessoas;
using ArgysApi.response.Usuarios;

namespace ArgysApi.mappers.Pessoas
{
    public static class PessoaMapper
    {
        public static PessoaResponse ToPessoaResponse(
            this Pessoa pessoa, PessoaEmail pessoaEmail, 
            PessoaEndereco pessoaEndereco, PessoaTelefone pessoaTelefone)
        {
            return new PessoaResponse
            {
                Uuid = pessoa.Uuid,
                Codigo = pessoa.Codigo,
                Nome = pessoa.Nome,
                NomeSocial = pessoa.NomeSocial,
                InformacoesPessoais =
                {
                    Sexo = pessoa.Genero,
                    Raca = pessoa.Raca,
                    EstadoCivil = pessoa.EstadoCivil,
                    DataNascimento = pessoa.DataNascimento,
                    GrauInstituicao = pessoa.GrauInstrucao,
                    Deficiencia = pessoa.Deficiencia,
                    Nacionalidade = pessoa.Nacionalidade,
                    Mae = pessoa.NomeMae,
                    Pai = pessoa.NomePai,
                    CotaDeficiencia = pessoa.CotaDeficiencia,
                    Proprietario = pessoa.Proprietario
                },
                Documentos =
                {
                    Cpf = pessoa.CPF,
                    PisNis = pessoa.PIS_NIS,
                    Rg = pessoa.RG,
                    UfRg = pessoa.RG_UF,
                    DataEmissaoRg = pessoa.RG_DataEmissao,
                    OrgaoExpedidor = pessoa.RgOrgaoExpedidor,
                    RgDigito = null,
                },
                TituloEleitor =
                {
                    TituloEleitor = pessoa.TituloEleitor,
                    Secao = pessoa.TituloEleitorSecao,
                    ZonaEleitoral = pessoa.TituloEleitorZona
                },
                Cnh =
                {
                    Numero = pessoa.CnhNumero,
                    Uf = pessoa.CnhExpedicaoUF,
                    Categoria = pessoa.CnhCategoria,
                    Expedicao = (DateTime)(pessoa.CnhDataExpedicao ?? null),
                    DataValidade = (DateTime)(pessoa.CnhDataValidade ?? null),
                    DataPrimeiraCnh = (DateTime)(pessoa.CnhDataPrimeiraHabilitacao ?? null),
                },
                Passaporte =
                {
                    Numero = pessoa.PassaporteNumero,
                    Validade= (DateTime)(pessoa.PassaporteDataValidade ?? null)
                },
                Ctps =
                {
                    Numero = pessoa.CtpsNumero,
                    Expedicao = pessoa.CtpsDataEmissao,
                    Serie = pessoa.CtpsSerie,
                    Uf = pessoa.CtpsUf
                },
                Endereco =
                {
                    Bairro = pessoaEndereco.Bairro,
                    Cep = pessoaEndereco.Cep,
                    Cidade = pessoaEndereco.Cidade,
                    Numero = pessoaEndereco.Numero,
                    Complemento = pessoaEndereco.Complemento,
                    Logradouro = pessoaEndereco.Logradouro,
                    Tipo = pessoaEndereco.TipoEndereco,
                    Uf = null
                },
                Email =
                {
                    Contato = pessoaEmail.Contato,
                    Email = pessoaEmail.Email
                },
                Telefone=
                {
                    Contato = pessoaTelefone.Contato,
                    Telefone = pessoaTelefone.Telefone,
                    Tipo = pessoaTelefone.Tipo
                }
            };
        }

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
                CotaDeficiencia = request.InformacoesPessoais?.CotaDeficiencia,
                Proprietario = request.InformacoesPessoais?.Proprietario,
                NomeMae = request.InformacoesPessoais.Mae,
                NomePai = request.InformacoesPessoais.Pai,
                CPF = request.Documentos.Cpf,
                PIS_NIS = request.Documentos.PisNis,
                RG = request.Documentos.Rg + " - " + request.Documentos.RgDigito,
                RG_UF = request.Documentos.UfRg,
                RG_DataEmissao = request.Documentos.DataEmissaoRg,
                RgOrgaoExpedidor = request.Documentos.OrgaoExpedidor,
                TituloEleitor = request.TituloEleitor.TituloEleitor,
                TituloEleitorSecao = request.TituloEleitor.Secao,
                TituloEleitorZona = request.TituloEleitor.ZonaEleitoral,
                CnhNumero = request.Cnh.Numero,
                CnhCategoria = request.Cnh.Categoria,
                CnhDataExpedicao = request.Cnh.Expedicao,
                CnhDataPrimeiraHabilitacao = request.Cnh.DataPrimeiraCnh,
                CnhDataValidade = request.Cnh.DataValidade,
                CnhExpedicaoUF = request.Cnh.Uf,
                CtpsNumero = request.Ctps.Numero,
                CtpsDataEmissao = request.Ctps.Expedicao,
                CtpsSerie = request.Ctps.Serie,
                CtpsUf = request.Ctps.Uf,
                PassaporteNumero = request.Passaporte.Numero,
                PassaporteDataValidade = request.Passaporte.Validade
            };
        }
    }
}
