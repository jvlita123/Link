using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("mat_Match")]
    public class Match
    {
        [Key]
        [Column("mat_ID")]
        public int Id { get; set; }

        [Required]
        [Column("mat_usrID")]
        public int FirstUserId { get; set; }

        [NotMapped]
        [ForeignKey("FirstUserId")]
        public virtual User FirstUser { get; set; }

        [Required]
        [Column("mat_usrID2")]
        public int SecondUserId { get; set; }

        [ForeignKey("SecondUserId")]
        public virtual User SecondUser { get; set; }

        [Required]
        [Column("mat_relID")]
        public int RelationId { get; set; }

        [ForeignKey("RelationId")]
        public virtual Relation Relation { get; set; }

        [Required]
        [Column("mat_staID")]
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        [Required]
        [Column("mat_date")]
        public DateTime Date { get; set; }
    }
}