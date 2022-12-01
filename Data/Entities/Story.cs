using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("sto_Story")]
    public class Story
    {
        [Key]
        [Column("sto_ID")]
        public int Id { get; set; }

        [Required]
        [Column("sto_phoID")]
        public int PhotoId { get; set; }

        [ForeignKey("PhotoId")]
        public virtual Photo Photo { get; set; }

        [Required]
        [Column("sto_duration")]
        public int Duration { get; set; }
    }
}