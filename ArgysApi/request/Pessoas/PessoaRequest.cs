using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.request.Pessoas
{
    public class PessoaRequest
    {
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public InformacoesPessoaisRequest InformacoesPessoais { get; set; }
        public DocumentosRequest Documentos { get; set; }
        public TituloEleitorRequest TituloEleitor { get; set; }
        public CnhRequest? Cnh { get; set; }
        public CtpsRequest Ctps { get; set; }
        public PassaporteRequest? Passaporte { get; set; }
        public EmailRequest Email { get; set; } 
        public TelefoneRequest Telefone { get; set; }
        public EnderecoRequest Endereco { get; set; }
    }
}
