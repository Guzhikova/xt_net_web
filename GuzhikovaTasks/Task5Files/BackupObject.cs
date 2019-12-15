using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    abstract class BackupObject
    {
        public string Name { get; set; }        
        public string Path { get; set; }
        public DateTime CreationDate { get; }
    }
}
