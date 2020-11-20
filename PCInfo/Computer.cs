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
        public string FreeSpace { get; set; }
        public string TimeStamp { get; set; }
        public string LogResult { get; set; }




        public Computer(string name)
        {
            PCName = name;
            TimeStamp = "N/A";
            LogResult = "N/A";
        }

 
        //gets online status via ping sender. sends name timeout (3s) buffer and a dont fragment option. only accepts success. prevents destination host unreachables from sneaking in
        public void getOnlineStatus()
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;

            //create buffer of 32 bytes of data to transmit
            string pingData = "are you there?";
            byte[] buffer = Encoding.ASCII.GetBytes(pingData);
            int timeout = 3000;
            try
            {
                PingReply reply = pingSender.Send(PCName, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    OnlineStatus = "Online";
                }
                else
                {
                    OnlineStatus = "Offline";
                }
                
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

            try
            {
                scope.Connect();
            }
            catch
            {
                //not sure about this, hard to test. had a random error where an offline PC passed the ping
                this.CurrentVersion = "WMI Failed";
            }
            try
            {
                // selects everything from the win32_operatingsystem DB, could probably rewrite to only select version.
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();

                foreach (ManagementObject m in queryCollection)
                {
                    tempVersion = (m["version"]).ToString();

                }
            }
            catch
            {
                this.CurrentVersion = "WMI Failed";
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

        public void getFreeSpace()
        {
            string wmiPath = "\\\\" + PCName + "\\root\\cimv2";
            string tempSpace = "N/A";

            ConnectionOptions options = new ConnectionOptions();
            ManagementScope scope = new ManagementScope(wmiPath, options);

            try
            {
                scope.Connect();
            }
            catch
            {
                //not sure about this, hard to test. had a random error where an offline PC passed the ping
                this.FreeSpace = "WMI Failed";
            }
            try
            {
                // selects everything from the win32_operatingsystem DB, could probably rewrite to only select version.
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_LogicalDisk where deviceid='C:'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();

                foreach (ManagementObject m in queryCollection)
                {
                    tempSpace = (m["freespace"]).ToString();

                }
            }
            catch
            {
                this.FreeSpace = "WMI Failed";
            }

            decimal tempSpaceCast = Int64.Parse(tempSpace);
            decimal freespace = tempSpaceCast / 1073741824;
            var freespaceRounded = Math.Round(freespace, 2);
            this.FreeSpace = freespaceRounded.ToString() + "GB";

        }

    }
}
