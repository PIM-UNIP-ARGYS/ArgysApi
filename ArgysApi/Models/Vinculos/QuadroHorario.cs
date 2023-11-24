using ArgysApi.Models.Empresas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("quadro_horario", Schema = "dbo")]
    public class QuadroHorario
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Column("empresa_id")]
        public long? EmpresaId { get; set; }

        [Column("codigo")]
        [MaxLength(45)]
        public string Codigo { get; set; }

        [Column("dt_inatividade")]
        public DateTime? DataInatividade { get; set; }

        [Column("descricao")]
        [MaxLength(255)]
        public string Descricao { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
    }
}
