﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Team
    {
        public int TeamID { get; set; }

       // public int PersonID { get; set; }

        public string Name { get; set; } 
         
        public string Title { get; set; }

        public string ImageUrl { get; set; }
        public string FacebookUrl { get; set; }

        public string WebSiteUrl { get; set; }

        public string XUrl { get; set; }


    }
}
