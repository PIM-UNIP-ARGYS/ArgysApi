using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("ferias_historico", Schema = "dbo")]
    public class FeriasHistorico
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Column("ferias_id")]
        public long FeriasId { get; set; }

        [Required]
        [Column("dt_aquisitivo")]
        public DateTime DtAquisitivo { get; set; }

        [Required]
        [Column("dt_final")]
        public DateTime DtFinal { get; set; }

        [Required]
        [Column("dt_inicial_gozo")]
        public DateTime DtInicialGozo { get; set; }

        [Required]
        [Column("dias_gozo")]
        public int DiasGozo { get; set; }

        [Required]
        [Column("dt_pagamento")]
        public DateTime DtPagamento { get; set; }

        [ForeignKey("FeriasId")]
        public Ferias Ferias { get; set; }
    }
}
