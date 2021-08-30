using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Controllers.Models
{
    public class TeamStats
    {

        public string Team { get; set; }

        public int MP { get; set; }
        public int W { get; set; }
        public int L { get; set; }
        public int D { get; set; }

        public int GF { get; set; }
        public int GA { get; set; }

        public int GD { get; set; }
        public int P { get; set; }
    }
}
