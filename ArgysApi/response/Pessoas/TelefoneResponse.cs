using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.response.Pessoas
{
    public class TelefoneResponse
    {
        public string Contato { get; set; }
        public string Telefone { get; set; }
        public string Tipo { get; set; }    
    }
}
