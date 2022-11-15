using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("mah_MatchHistory")]
    public class MatchHistory
    {
        [Key]
        [Column("mah_ID")]
        public int Id { get; set; }

        [Required]
        [Column("mah_matID")]
        public int MatchId { get; set; }

        [ForeignKey("MatchId")]
        public virtual Match Match { get; set; }

        [Required]
        [Column("mah_usrID")]
        public int FirstUserId { get; set; }

        [ForeignKey("FirstUserId")]
        public virtual User FirstUser { get; set; }

        [Required]
        [Column("mah_usrID2")]
        public int SecondUserId { get; set; }

        [ForeignKey("SecondUserId")]
        public virtual User SecondUser { get; set; }

        [Required]
        [Column("mah_rate")]
        public int Rate { get; set; }

        [Column("mah_description")]
        public string Description { get; set; }
    }
}