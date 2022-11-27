using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("gac_GetAchievement")]
    public class UserAchievement
    {
        [Key]
        [Column("gac_ID")]
        public int Id { get; set; }

        [Required]
        [Column("gac_achID")]
        public int AchievementId { get; set; }

        [ForeignKey("AchievementId")]
        public virtual Achievement Achievement { get; set; }

        [Required]
        [Column("gac_usrID")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        [Column("gac_date")]
        public DateTime AddDate { get; set; }
    }
}