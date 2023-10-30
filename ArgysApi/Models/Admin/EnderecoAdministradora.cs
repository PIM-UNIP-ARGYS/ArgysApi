using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Admin
{
    [Table("endereco_administradora", Schema = "pimdb")]
    public class EnderecoAdministradora
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("administradora_id")]
        public long AdministradoraId { get; set; }

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

        [ForeignKey("administradora_id")]
        public Administradora Administradora { get; set; }
    }
}
