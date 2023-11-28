using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.response.Pessoas
{
    public class TituloEleitorResponse
    {
        public string TituloEleitor { get; set; }
        public string Secao { get; set; }
        public string ZonaEleitoral { get; set; }
    }
}
