using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("rec_Reaction")]
    public class Reaction
    {
        [Key]
        [Column("rec_ID")]
        public int Id { get; set; }

        [Required]
        [Column("rec_name")]
        public string Name { get; set; }

        [Column("rec_emoji")]
        public string Emoji { get; set; }
    }
}