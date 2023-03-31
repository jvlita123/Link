using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.Photos
{
    internal class Photo
    {
        public int Id { get; set; }

        [Required]
        public int userId { get; set; }
        [Required]
        public string Path { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool IsProfile { get; set; }
    }
}
