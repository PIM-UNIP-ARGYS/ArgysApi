using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.response.Pessoas
{
    public class CtpsResponse
    {
        public string Numero { get; set; }
        public string Serie { get; set; }
        public DateTime Expedicao { get; set; }
        public string Uf { get; set; }
    }
}
