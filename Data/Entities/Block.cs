using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("blo_Block")]
    public class Block
    {
        [Key]
        [Column("blo_ID")]
        public int Id { get; set; }

        [Required]
        [Column("blo_userID")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        [Column("blo_userIDBlocked")]
        public int BlockedUserId { get; set; }

        [NotMapped]
        [ForeignKey("BlockedUserId")]
        public virtual User BlockedUser { get; set; }
    }
}