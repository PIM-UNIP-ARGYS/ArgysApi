using ArgysApi.Models.Empresas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Impostos
{
    [Table("plano_saude", Schema = "pimdb")]
    public class PlanoSaude
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("empresa_id")]
        public long EmpresaId { get; set; }

        [Required]
        [Column("codigo")]
        [MaxLength(10)]
        public string Codigo { get; set; }

        [Required]
        [Column("cnpj")]
        [MaxLength(14)]
        public string Cnpj { get; set; }

        [Required]
        [Column("registro_ans")]
        [MaxLength(45)]
        public string RegistroAns { get; set; }

        [Required]
        [Column("razao_social")]
        [MaxLength(255)]
        public string RazaoSocial { get; set; }

        [ForeignKey("empresa_id")]
        public Empresa Empresa { get; set; }
    }
}
