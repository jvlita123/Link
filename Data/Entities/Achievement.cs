using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("ach_Achievement")]
    public class Achievement
    {
        [Key]
        [Column("ach_ID")]
        public int Id { get; set; }

        [Required]
        [Column("ach_name")]
        public string Name { get; set; }
    }
}