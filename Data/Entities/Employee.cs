using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("emp_Employee")]
    public class Employee
    {
        [Key]
        [Column("emp_ID")]
        public int Id { get; set; }

        [Required]
        [Column("emp_accID")]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [Required]
        [Column("emp_fullName")]
        public string FullName { get; set; }
    }
}