using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class TeamGet
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Organization { get; set; }

        public List<Members> Members { get; set; }

    }
    public class Members {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime membershipDate { get; set; }
    }
}
