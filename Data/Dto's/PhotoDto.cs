using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto_s
{
    internal class PhotoDto
    {
        public int Id { get; set; }

       
        public int userId { get; set; }
   
        public string Path { get; set; }
        public string Description { get; set; }
  
        public DateTime Date { get; set; }

        public bool IsProfile { get; set; }
    }
}
