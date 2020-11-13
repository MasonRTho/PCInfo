using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PCInfo
{
    public class Computer
    {
        public string PCName { get; set; }
        public string OnlineStatus { get; set; }
        public string CurrentVersion { get; set; }
        public string TimeStamp { get; set; }
        public string LogResult { get; set; }

        

        public Computer(string name)
        {
            PCName = name;
        }

 
        //gets online status via ping reply. could probably combine this with object creation. freezes a bit on offline pcs
        public void getOnlineStatus()
        {
            Ping ping = new Ping();
            try
            {
                PingReply pingReply = ping.Send(PCName);
                OnlineStatus = "Online";
            }
            catch
            {
                OnlineStatus = "Offline";
            }

        }

        // gets current version via WMI. nearly instant. only run on online PCs
        public void getCurrentVersion()
        {
            string wmiPath = "\\\\" + PCName + "\\root\\cimv2";
            string tempVersion = "N/A";

            ConnectionOptions options = new ConnectionOptions();
            ManagementScope scope = new ManagementScope(wmiPath, options);
            scope.Connect();
            // selects everything from the win32_operatingsystem DB, could probably rewrite to only select version.
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            ManagementObjectCollection queryCollection = searcher.Get();

            foreach (ManagementObject m in queryCollection)
            {
                tempVersion = (m["version"]).ToString();

            }

            switch (tempVersion)
            {
                case "10.0.15063":
                    CurrentVersion = "1703";
                    break;
                case "10.0.16299":
                    CurrentVersion = "1709";
                    break;
                case "10.0.17134":
                    CurrentVersion = "1803";
                    break;
                case "10.0.17763":
                    CurrentVersion = "1809";
                    break;
                case "10.0.18362":
                    CurrentVersion = "1903";
                    break;
                case "10.0.18363":
                    CurrentVersion = "1909";
                    break;
                case "10.0.19041":
                    CurrentVersion = "2004";
                    break;
                case "10.0.19042":
                    CurrentVersion = "20H2";
                    break;
            }

        }


    }
}
