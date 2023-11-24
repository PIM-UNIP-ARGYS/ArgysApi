using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Empresas
{
    [Table("endereco_empresa", Schema = "dbo")]
    public class EnderecoEmpresa
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
        [Column("logradouro")]
        [MaxLength(255)]
        public string Logradouro { get; set; }

        [Required]
        [Column("cep")]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Required]
        [Column("complemento")]
        [MaxLength(45)]
        public string Complemento { get; set; }

        [Required]
        [Column("bairro")]
        [MaxLength(255)]
        public string Bairro { get; set; }

        [Required]
        [Column("cidade")]
        [MaxLength(255)]
        public string Cidade { get; set; }

        [Required]
        [Column("pais")]
        [MaxLength(255)]
        public string Pais { get; set; }

        [ForeignKey("empresa_id")]
        public Empresa Empresa { get; set; }
    }
}
