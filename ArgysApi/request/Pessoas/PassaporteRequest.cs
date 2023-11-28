using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.request.Pessoas
{
    public class PassaporteRequest
    {
        public string Numero { get; set; }
        public DateTime Validade { get; set; }
    }
}
