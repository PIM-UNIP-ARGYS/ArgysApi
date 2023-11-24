using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Pessoas
{
    [Table("pessoa", Schema = "dbo")]
    public class Pessoa
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
        [Column("nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Column("nome_social")]
        [MaxLength(255)]
        public string? NomeSocial { get; set; } // Permite valores nulos

        [Required]
        [Column("genero")]
        [MaxLength(45)]
        public string Genero { get; set; }

        [Required]
        [Column("raca")]
        [MaxLength(45)]
        public string Raca { get; set; }

        [Required]
        [Column("estado_civil")]
        [MaxLength(45)]
        public string EstadoCivil { get; set; }

        [Required]
        [Column("dt_nasc")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Column("grau_instrucao")]
        [MaxLength(45)]
        public string GrauInstrucao { get; set; }

        [Column("deficiencia")]
        [MaxLength(45)]
        public string? Deficiencia { get; set; } // Permite valores nulos

        [Required]
        [Column("nacionalidade")]
        [MaxLength(100)]
        public string Nacionalidade { get; set; }

        [Required]
        [Column("nome_mae")]
        [MaxLength(255)]
        public string NomeMae { get; set; }

        [Column("nome_pai")]
        [MaxLength(255)]
        public string? NomePai { get; set; } // Permite valores nulos

        [Column("cota_deficiencia")]
        [MaxLength(5)]
        public string? CotaDeficiencia { get; set; } // Permite valores nulos

        [Column("proprietario")]
        [MaxLength(5)]
        public string? Proprietario { get; set; } // Permite valores nulos

        [Required]
        [Column("cpf")]
        [MaxLength(45)]
        public string CPF { get; set; }

        [Required]
        [Column("pis_nis")]
        [MaxLength(45)]
        public string PIS_NIS { get; set; }

        [Required]
        [Column("rg")]
        [MaxLength(45)]
        public string RG { get; set; }

        [Required]
        [Column("rg_uf")]
        [MaxLength(45)]
        public string RG_UF { get; set; }

        [Required]
        [Column("rg_dt_emis")]
        public DateTime RG_DataEmissao { get; set; }

        [Required]
        [Column("rg_org_exp")]
        [MaxLength(45)]
        public string RgOrgaoExpedidor { get; set; }

        [Required]
        [Column("tit_eleitor")]
        [MaxLength(45)]
        public string TituloEleitor { get; set; }

        [Required]
        [Column("tit_secao")]
        [MaxLength(45)]
        public string TituloEleitorSecao { get; set; }

        [Required]
        [Column("tit_zon_eleit")]
        [MaxLength(45)]
        public string TituloEleitorZona { get; set; }

        [Column("cnh_num")]
        [MaxLength(45)]
        public string? CnhNumero { get; set; } // Permite valores nulos

        [Column("cnh_cat")]
        [MaxLength(45)]
        public string? CnhCategoria { get; set; } // Permite valores nulos

        [Column("cnh_dt_prim_hab")]
        public DateTime? CnhDataPrimeiraHabilitacao { get; set; } // Permite valores nulos

        [Column("cnh_exp_uf")]
        [MaxLength(45)]
        public string? CnhExpedicaoUF { get; set; } // Permite valores nulos

        [Column("cnh_dt_exp")]
        public DateTime? CnhDataExpedicao { get; set; } // Permite valores nulos

        [Column("cnh_dt_val")]
        public DateTime? CnhDataValidade { get; set; } // Permite valores nulos

        [Required]
        [Column("ctps_num")]
        [MaxLength(45)]
        public string CtpsNumero { get; set; }

        [Required]
        [Column("ctps_serie")]
        [MaxLength(45)]
        public string CtpsSerie { get; set; }

        [Required]
        [Column("ctps_dt_emis")]
        public DateTime CtpsDataEmissao { get; set; }

        [Required]
        [Column("ctps_uf")]
        [MaxLength(45)]
        public string CtpsUf { get; set; }

        [Column("pass_num")]
        [MaxLength(45)]
        public string? PassaporteNumero { get; set; } // Permite valores nulos

        [Column("pass_dt_val")]
        public DateTime? PassaporteDataValidade { get; set; } // Permite valores nulos
    }
}
