using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("rus_RelationUser")]
    public class RelationUser
    {
        [Key]
        [Column("rus_ID")]
        public int Id { get; set; }

        [Required]
        [Column("rus_usrID")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        [Column("rus_relID")]
        public int RelationId { get; set; }

        [ForeignKey("RelationId")]
        public virtual Relation Relation { get; set; }

        [Required]
        [Column("rus_preID")]
        public int PreferenceId { get; set; }

        [ForeignKey("PreferenceId")]
        public virtual Preference Preference { get; set; }
    }
}