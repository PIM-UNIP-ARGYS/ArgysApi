using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("vinculo_cargo", Schema = "dbo")]
    public class VinculoCargo
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
        [Column("cargo_id")]
        public long CargoId { get; set; }

        [ForeignKey("VinculoId")]
        public Vinculo Vinculo { get; set; }

        [ForeignKey("CargoId")]
        public Cargo Cargo { get; set; }
    }
}
