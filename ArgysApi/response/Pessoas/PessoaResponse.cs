using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.response.Pessoas
{
    public class PessoaResponse
    {
        public string Uuid { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public InformacoesPessoaisResponse InformacoesPessoais { get; set; }
        public DocumentosResponse Documentos { get; set; }
        public TituloEleitorResponse TituloEleitor { get; set; }
        public CnhResponse Cnh { get; set; }
        public CtpsResponse Ctps { get; set; }
        public PassaporteResponse Passaporte { get; set; }
        public EmailResponse Email { get; set; } 
        public TelefoneResponse Telefone { get; set; }
        public EnderecoResponse Endereco { get; set; }
    }
}
