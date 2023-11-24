using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("ferias", Schema = "dbo")]
    public class Ferias
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Column("vinculo_id")]
        public long? VinculoId { get; set; }

        [ForeignKey("VinculoId")]
        public Vinculo Vinculo { get; set; }
    }
}
