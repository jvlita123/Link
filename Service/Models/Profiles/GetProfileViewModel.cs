using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.Profiles
{
    public class GetProfileViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
