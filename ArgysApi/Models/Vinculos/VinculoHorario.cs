using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("vinculo_horario", Schema = "dbo")]
    public class VinculoHorario
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
        [Column("quadro_horario_id")]
        public long QuadroHorarioId { get; set; }

        [ForeignKey("VinculoId")]
        public Vinculo Vinculo { get; set; }

        [ForeignKey("QuadroHorarioId")]
        public QuadroHorario QuadroHorario { get; set; }
    }
}
