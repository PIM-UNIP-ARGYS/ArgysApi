using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Empresas
{
    [Table("empresa", Schema = "dbo")]
    public class Empresa
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("codigo")]
        [MaxLength(10)]
        public string Codigo { get; set; }

        [Required]
        [Column("cnpj")]
        [MaxLength(14)]
        public string Cnpj { get; set; }

        [Required]
        [Column("razao_social")]
        [MaxLength(255)]
        public string RazaoSocial { get; set; }

        [Required]
        [Column("situacao_empresa")]
        [MaxLength(50)]
        public string SituacaoEmpresa { get; set; }

        [Required]
        [Column("nome_fantasia")]
        [MaxLength(255)]
        public string NomeFantasia { get; set; }

        [Column("cpf")]
        [MaxLength(11)]
        public string? Cpf { get; set; } // Permite valores nulos

        [Column("caepf")]
        [MaxLength(45)]
        public string? Caepf { get; set; } // Permite valores nulos

        [Column("tipo_caepf")]
        [MaxLength(45)]
        public string? TipoCaepf { get; set; } // Permite valores nulos

        [Column("cei_cno")]
        [MaxLength(12)]
        public string? CeiCno { get; set; } // Permite valores nulos

        [Column("ie")]
        [MaxLength(14)]
        public string? Ie { get; set; } // Permite valores nulos

        [Column("im")]
        [MaxLength(12)]
        public string? Im { get; set; } // Permite valores nulos

        [Column("site")]
        [MaxLength(255)]
        public string? Site { get; set; } // Permite valores nulos

        [Required]
        [Column("matriz_filial")]
        [MaxLength(10)]
        public string MatrizFilial { get; set; }

        [Column("centralizar")]
        [MaxLength(3)]
        public string? Centralizar { get; set; } // Permite valores nulos

        [Required]
        [Column("grupo_empresa_id")]
        public long GrupoEmpresaId { get; set; }


        [ForeignKey("grupo_empresa_id")]
        public GrupoEmpresa GrupoEmpresa { get; set; }
    }
}
