using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Member
    {
        public int IdMember { get; set; }
        public int IdOrganization { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NickName { get; set; }

        public ICollection<Membership> Membership { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
