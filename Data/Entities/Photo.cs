using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("pho_Photos")]
    public class Photo
    {
        [Key]
        [Column("pho_ID")]
        public int Id { get; set; }

        [Required]
        [Column("pho_usrID")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        [Column("pho_path")]
        public string Path { get; set; }

        [Column("pho_description")]
        public string? Description { get; set; }

        [Required]
        [Column("pho_date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("pho_isProfilePicture")]
        public bool IsProfilePicture { get; set; }
    }
}