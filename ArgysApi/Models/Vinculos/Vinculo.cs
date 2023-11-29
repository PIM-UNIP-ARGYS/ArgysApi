using ArgysApi.Models.Pessoas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("vinculo", Schema = "dbo")]
    public class Vinculo
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Column("matricula_esocial")]
        [MaxLength(255)]
        public string? MatriculaEsocial { get; set; } // Permite valores nulos

        [Required]
        [Column("matricula")]
        [MaxLength(255)]
        public string Matricula { get; set; }

        [Required]
        [Column("pessoa_id")]
        public long PessoaId { get; set; }

        [Required]
        [Column("cbo_id")]
        public long CboId { get; set; }

        [Required]
        [Column("dt_admissao")]
        public DateTime DtAdmissao { get; set; }

        [Required]
        [Column("dt_fgts")]
        public DateTime DtFgts { get; set; }

        [Column("rem_banco_id")]
        public long? RemBancoId { get; set; } // Permite valores nulos

        [Column("fgts_banco_id")]
        public long? FgtsBancoId { get; set; } // Permite valores nulos

    }
}
