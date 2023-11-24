using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Admin
{
    [Table("administradora", Schema = "dbo")]
    public class Administradora
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public Guid Uuid { get; set; }

        [Required]
        [Column("razao_social")]
        [MaxLength(255)]
        public string RazaoSocial { get; set; }

        [Required]
        [Column("nome_fantasia")]
        [MaxLength(255)]
        public string NomeFantasia { get; set; }

        [Column("site")]
        [MaxLength(255)]
        public string? Site { get; set; }

        [Column("cpf")]
        [MaxLength(11)]
        public string? Cpf { get; set; }

        [Column("cnpj")]
        [MaxLength(14)]
        public string? Cnpj { get; set; }

        [Column("cei")]
        [MaxLength(12)]
        public string? Cei { get; set; }

        [Column("ie")]
        [MaxLength(14)]
        public string? Ie { get; set; }

        [Column("im")]
        [MaxLength(12)]
        public string? Im { get; set; }
    }
}
