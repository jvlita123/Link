using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("rel_Relation")]
    public class Relation
    {
        [Key]
        [Column("rel_ID")]
        public int Id { get; set; }

        [Required]
        [Column("rel_name")]
        public string Name { get; set; }
    }
}