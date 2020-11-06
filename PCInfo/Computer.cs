using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCInfo
{
    class Computer
    {
        public string pcName { get; set; }
        public string onlineStatus;
        public int currentVersion;
        public string timeStamp;
        public string logResult;

        public Computer(string name)
        {
            pcName = name;
        }



    }
}
