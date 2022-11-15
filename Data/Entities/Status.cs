using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("sta_Status")]
    public class Status
    {
        [Key]
        [Column("sta_ID")]
        public int Id { get; set; }

        [Required]
        [Column("sta_name")]
        public string Name { get; set; }
    }
}