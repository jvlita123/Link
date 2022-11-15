using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("mes_Message")]
    public class Message
    {
        [Key]
        [Column("mes_ID")]
        public int Id { get; set; }

        [Required]
        [Column("mes_text")]
        public string Text { get; set; }

        [Required]
        [Column("mes_usrID")]
        public int FirstUserId { get; set; }

        [ForeignKey("FirstUserId")]
        public virtual User FirstUser { get; set; }

        [Required]
        [Column("mes_usrID2")]
        public int SecondUserId { get; set; }

        [ForeignKey("SecondUserId")]
        public virtual User SecondUser { get; set; }

        [Required]
        [Column("mes_recID")]
        public int ReactionId { get; set; }

        [ForeignKey("ReactionId")]
        public virtual Reaction Reaction { get; set; }
    }
}