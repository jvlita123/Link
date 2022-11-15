using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("usr_User")]
    public class User
    {
        [Key]
        [Column("usr_ID")]
        public int Id { get; set; }

        [Required]
        [Column("usr_name")]
        public string Name { get; set; }

        [Required]
        [Column("usr_gender")]
        public bool Gender { get; set; }

        [Required]
        [Column("usr_phoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column("usr_isPremium")]
        public bool IsPremium { get; set; }

        [Required]
        [Column("usr_lastLogin")]
        public DateTime LastLogin { get; set; }

        [Required]
        [Column("user_accID")]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}