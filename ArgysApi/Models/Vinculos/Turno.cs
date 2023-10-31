using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("turno", Schema = "pimdb")]
    public class Turno
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("quadro_horario_id")]
        public long QuadroHorarioId { get; set; }

        [Required]
        [Column("dias")]
        [MaxLength(255)]
        public string Dias { get; set; }

        [Required]
        [Column("turno")]
        [MaxLength(45)]
        public string NomeTurno { get; set; }

        [Required]
        [Column("horario_entrada")]
        public TimeSpan HorarioEntrada { get; set; }

        [Required]
        [Column("horario_saida")]
        public TimeSpan HorarioSaida { get; set; }

        [ForeignKey("QuadroHorarioId")]
        public QuadroHorario QuadroHorario { get; set; }
    }
}
