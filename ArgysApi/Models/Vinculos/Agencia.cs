using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("agencia", Schema = "dbo")]
    public class Agencia
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("banco_id")]
        public long BancoId { get; set; }

        [Required]
        [Column("nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [Column("numero")]
        [MaxLength(45)]
        public string Numero { get; set; }

        [Column("dg_verif")]
        [MaxLength(45)]
        public string? DgVerif { get; set; } // Permite valores nulos


        [Column("observacao")]
        [MaxLength(255)]
        public string? Observacao { get; set; } // Permite valores nulos

        [ForeignKey("BancoId")]
        public Banco Banco { get; set; }

    }
}
