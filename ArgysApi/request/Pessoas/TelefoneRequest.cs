using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.request.Pessoas
{
    public class TelefoneRequest
    {
        public string Contato { get; set; }
        public string Telefone { get; set; }
        public string Tipo { get; set; }    
    }
}
