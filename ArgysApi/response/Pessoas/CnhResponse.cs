﻿using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace ArgysApi.response.Pessoas
{
    public class CnhResponse
    {
        public string Numero { get; set; }
        public string Categoria { get; set; }
        public DateTime DataPrimeiraCnh { get; set; }
        public string Uf { get; set; }
        public DateTime Expedicao { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
