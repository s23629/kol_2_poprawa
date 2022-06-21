using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Team
    {
        public int IdTeam { get; set; }
        public int IdOrganization { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }

        public virtual Organization Organization { get; set; }
        public ICollection<Membership> Membership { get; set; }
        public ICollection<File> File { get; set; }
    }
}
