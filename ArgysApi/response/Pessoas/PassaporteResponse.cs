using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.response.Pessoas
{
    public class PassaporteResponse
    {
        public string Numero { get; set; }
        public DateTime Validade { get; set; }
    }
}
