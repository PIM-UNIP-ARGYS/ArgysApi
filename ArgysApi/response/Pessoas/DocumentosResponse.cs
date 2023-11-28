using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.response.Pessoas
{
    public class DocumentosResponse
    {
        public string Cpf { get; set; }
        public string PisNis { get; set; }
        public string Rg { get; set; }
        public string RgDigito { get; set; }
        public string UfRg { get; set; }
        public DateTime DataEmissaoRg { get; set; }
        public string OrgaoExpedidor { get; set; }
    }
}
