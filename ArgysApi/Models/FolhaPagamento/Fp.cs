using ArgysApi.Models.Pessoas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.FolhaPagamento
{
    [Table("historico_fp", Schema = "dbo")]
    public class Fp
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("vinculo_id")]
        public long VinculoId { get; set; }

        [Required]
        [Column("nome_arquivo")]
        [MaxLength(45)]
        public string NomeArquivo { get; set; }

        [Required]
        [Column("fp")]
        public byte[] FolhaPagamento { get; set; }

    }
}
