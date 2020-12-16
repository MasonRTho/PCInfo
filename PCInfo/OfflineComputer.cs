using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCInfo
{
   public class OfflineComputer
    {
        public string PCName { get; set; }

        public string Reason { get; set; }

        public string LastLogResult { get; set; }

        public OfflineComputer(string name)
        {
            this.PCName = name;
        }
        public OfflineComputer(string name, string reason)
        {
            this.PCName = name;
            this.Reason = reason;
        }
        public OfflineComputer(string name, string reason, string lastLogResult)
        {
            this.PCName = name;
            this.Reason = reason;
            this.LastLogResult = lastLogResult;
        }
    }


   
}
