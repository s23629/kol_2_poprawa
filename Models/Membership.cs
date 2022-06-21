using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Membership
    {
        public int IdMember { get; set; }
        public int IdTeam { get; set; }
        public DateTime MembershipDate { get; set; }

        public virtual Team Team { get; set; }
        public virtual Member Member { get; set; }
    }
}
