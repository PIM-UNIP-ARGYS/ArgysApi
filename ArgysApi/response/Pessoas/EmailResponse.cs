using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.response.Pessoas
{
    public class EmailResponse
    {
        public string Contato { get; set; }
        public string Email { get; set; }
    }
}
