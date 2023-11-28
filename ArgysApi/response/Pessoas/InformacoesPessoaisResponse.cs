using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.response.Pessoas
{
    public class InformacoesPessoaisResponse
    {
        public string Sexo { get; set; }
        public string Raca { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
        public string GrauInstituicao { get; set; }
        public string Deficiencia { get; set; }
        public string Nacionalidade { get; set; }
        public string CotaDeficiencia { get; set; }
        public string Proprietario { get; set; }
        public string Mae { get; set; }
        public string Pai { get; set; }
    }
}
