using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PCInfo
{
    class Computer
    {
        public string pcName { get; set; }
        public string onlineStatus;
        public string currentVersion;
        public string timeStamp;
        public string logResult;

        

        public Computer(string name)
        {
            pcName = name;
        }

        public void getOnlineStatus()
        {
            Ping ping = new Ping();
            try
            {
                PingReply pingReply = ping.Send(pcName);
                onlineStatus = "Online";
            }
            catch
            {
                onlineStatus = "Offline";
            }

        }

        public void getCurrentVersion()
        {
            string wmiPath = "\\\\" + pcName + "\\root\\cimv2";
            string tempVersion = "N/A";

            ConnectionOptions options = new ConnectionOptions();
            ManagementScope scope = new ManagementScope(wmiPath, options);
            scope.Connect();

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
                    currentVersion = "1703";
                    break;
                case "10.0.16299":
                    currentVersion = "1709";
                    break;
                case "10.0.17134":
                    currentVersion = "1803";
                    break;
                case "10.0.17763":
                    currentVersion = "1809";
                    break;
                case "10.0.18362":
                    currentVersion = "1903";
                    break;
                case "10.0.18363":
                    currentVersion = "1909";
                    break;
                case "10.0.19041":
                    currentVersion = "2004";
                    break;
                case "10.0.19042":
                    currentVersion = "20H2";
                    break;
            }

        }


    }
}
