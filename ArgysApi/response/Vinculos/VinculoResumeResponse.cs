using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.response.Vinculos
{
    public class VinculoResumeResponse
    {
        public string Uuid { get; set; }
        public string Matricula { get; set; }
        public string Trabalhador { get; set; }
        public string DataAdmissão { get; set; }
        public string Cpf { get; set; }
    }
}
