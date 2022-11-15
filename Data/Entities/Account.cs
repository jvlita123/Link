using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("acc_Account")]
    public class Account
    {
        [Key]
        [Column("acc_ID")]
        public int Id { get; set; }

        [Required]
        [Column("acc_email")]
        public string Email { get; set; }

        [Required]
        [Column("acc_password")]
        public string Password { get; set; }
    }
}