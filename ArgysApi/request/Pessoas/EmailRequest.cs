using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.request.Pessoas
{
    public class EmailRequest
    {
        public string Contato { get; set; }
        public string Email { get; set; }
    }
}
