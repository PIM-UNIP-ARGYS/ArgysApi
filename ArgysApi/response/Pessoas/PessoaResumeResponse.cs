using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.response.Pessoas
{
    public class PessoaResumeResponse
    {
        public string Uuid { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Ctps { get; set; }
        public string Cpf { get; set; }
        public string PisNis { get; set; }
        public string TituloEleitor { get; set; }
        public string DataNascimento { get; set; }
    }
}
