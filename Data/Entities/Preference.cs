using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("pre_Preferences")]
    public class Preference
    {
        [Key]
        [Column("pre_ID")]
        public int Id { get; set; }

        [Required]
        [Column("pre_type")]
        public string Type { get; set; }

        [Required]
        [Column("pre_value")]
        public string Value { get; set; }
    }
}