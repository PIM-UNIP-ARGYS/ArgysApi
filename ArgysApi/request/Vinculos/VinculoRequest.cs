using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.request.Vinculos
{
    public class VinculoRequest
    {
        public string Pessoa { get; set; }
        public string Cbo { get; set; }
        public DateTime DtAdmissao { get; set; }
        public DateTime DtFgts { get; set; }
        public string Cargo { get; set; }
        public string Salario { get; set; } 
        public string TipoPagamento { get; set; }
    }
}
