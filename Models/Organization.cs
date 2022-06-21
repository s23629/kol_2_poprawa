using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }

        public ICollection<Team> Team { get; set; }
        public ICollection<Member> Member { get; set; }
    }
}
