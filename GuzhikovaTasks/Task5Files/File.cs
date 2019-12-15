using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Files
{
    class File : BackupObject
    {
        public string Type { get; set; }
        List <DateTime> ChangesDates { get;}
        public string Content { get; set; }
    }
}
