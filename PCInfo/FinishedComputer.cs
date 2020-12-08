using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCInfo
{
    public class FinishedComputer
    {
        public string PCName { get; set; }
        public string CurrentVersion { get; set; }
        public string FreeSpace { get; set; }

        public FinishedComputer(string name)
        {
            PCName = name;
            CurrentVersion = "N/A";
            FreeSpace = "N/A";

        }
    }
}
