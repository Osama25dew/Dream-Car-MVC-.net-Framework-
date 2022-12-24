using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADDreamCarProject.Models
{
    public class DisplayHomePage
    {
        public List<Company> HomeComp { get; set; }
        public List<CarModel> HomeCarMod { get; set; }
        public List<Admin> HomeAdm { get; set; }
    }
}