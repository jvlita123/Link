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

        [Column("usr_phoneNumber")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Column("usr_isPremium")]
        public bool IsPremium { get; set; }

        [Required]
        [Column("usr_lastLogin")]
        public DateTime LastLogin { get; set; }

        [Required]
        [Column("usr_accID")]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account? Account { get; set; }

        [Column("usr_description")]
        public string? Description { get; set; }

        [Required]
        [Column("usr_localization")]
        public string? Localization { get; set; }

        [Column("usr_height")]
        public decimal? Height { get; set; }

        [Required]
        [Column("usr_isBlocked")]
        public bool IsBlock { get; set; }

        public virtual ICollection<Photo>? Photos { get; set; }

        public virtual ICollection<Block> Blocks { get; set; }

        //public virtual ICollection<Message> Messages { get; set; }

        //public virtual ICollection<Match> Matches { get; set; }

        //public virtual ICollection<MatchHistory> MatchHistories { get; set; }

        //public virtual ICollection<RelationUser> UserRelations { get; set; }
    }
}