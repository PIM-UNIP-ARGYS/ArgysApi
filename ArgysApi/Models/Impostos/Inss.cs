using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Impostos
{
    [Table("inss", Schema = "pimdb")]
    public class Inss
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("limite_rend", TypeName = "decimal(10,0)")]
        public decimal LimiteRenda { get; set; }

        [Required]
        [Column("aliquota", TypeName = "decimal(10,0)")]
        public decimal Aliquota { get; set; }
    }
}
