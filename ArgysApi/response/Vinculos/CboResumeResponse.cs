using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.response.Vinculos
{
    public class CboResumeResponse
    {
        public string Uuid { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string SalarioAula { get; set; }
        public string MotoristaProfissional { get; set; }
    }
}
