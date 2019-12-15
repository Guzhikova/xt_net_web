using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    class File
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public DateTime CreationDate { get; }
        List <DateTime> ChangesDates { get;}
        public string Content { get; set; }
    }
}
