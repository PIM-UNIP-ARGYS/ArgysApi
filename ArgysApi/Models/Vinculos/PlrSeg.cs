using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArgysApi.Models.Vinculos
{
    [Table("plr_seg", Schema = "pimdb")]
    public class PlrSeg
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("uuid")]
        [MaxLength(45)]
        public string Uuid { get; set; }

        [Required]
        [Column("plr_id")]
        public long PLRId { get; set; }

        [Required]
        [Column("lim_rend")]
        public decimal LimRend { get; set; }

        [Required]
        [Column("aliquota")]
        public decimal Aliquota { get; set; }

        [Required]
        [Column("vl_ded")]
        public decimal VlDed { get; set; }

        [ForeignKey("PLRId")]
        public Plr Plr { get; set; }
    }
}
