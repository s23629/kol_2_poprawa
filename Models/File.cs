using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class File
    {
        public int IdFile { get; set; }
        public int IdTeam { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int FileSize { get; set; }

        public virtual Team Team { get; set; }
    }
}
