using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        public string ProcessStatus { get; set; }
        public string UpgradeStatus { get; set; }
        public DateTime? OfflineTime { get; set; }
        public int RemoteRegistryEnableCount { get; set; }





        public Computer(string name)
        {
            PCName = name;
            TimeStamp = "N/A";
            LogResult = "N/A";
            UpgradeStatus = "N/A";
        }

        //TODO: Add some error handling
        public void getProcessStatus()
        {
            try
            {
                Process[] setupProcess = Process.GetProcessesByName("setup", PCName);
                Process[] setupHostProcess = Process.GetProcessesByName("setuphost", PCName);
                Process[] setupPrepProcess = Process.GetProcessesByName("setupprep", PCName);

                if (setupProcess.Length > 0 || setupHostProcess.Length > 0 || setupPrepProcess.Length > 0)
                {
                    ProcessStatus = "Running";
                }
                else
                {
                    ProcessStatus = "Not Running";
                }
            }
            catch
            {
                ProcessStatus = "Unable to get process status";
            }

        }

        //todo: might need error handling here for when pc goes offline
        public string getLogLocation()
        {
            string windowsBTLog = "\\\\" + PCName + "\\c$\\$windows.~BT\\sources\\panther\\setupact.log";
            string windowsLog = "\\\\" + PCName + "\\c$\\windows\\panther\\setupact.log";

            if (File.Exists(windowsBTLog))
            {
                return windowsBTLog;
            }
            else if (File.Exists(windowsLog))
            {
                return windowsLog;
            }
            return windowsBTLog; //might need to do something about this
        }
        //check if upgrade is hung, using last write time of log file

        //TODO: add error handling for when pc goes offline
        public void getStuckStatus()
        {
            try
            {
                var lastWriteTime = File.GetLastWriteTime(getLogLocation());
                DateTime currentTime = DateTime.Now;
                 

                TimeSpan elapsedTime = currentTime - lastWriteTime;

                if (elapsedTime.TotalMinutes > 15 && elapsedTime.TotalMinutes < 45)
                {
                    this.UpgradeStatus = "Upgrade Stuck, will cancel in 45 min from " + lastWriteTime;
                }
                else if (elapsedTime.TotalMinutes > 45)
                {
                    this.UpgradeStatus = "Upgrade stuck";
                }
                else
                {
                    this.UpgradeStatus = "In Progress";
                }
            }
            catch
            {
                UpgradeStatus = "Unable to get stuck staus";
            }


        }

        public void getTimeStamp()
        {
            DateTime currentTime = DateTime.Now;
            TimeStamp = currentTime.ToString();
        }

        //this seems like a terrible method and is probably extremely slow on a large log
        //TODO: error handling for when pc goes offline
        public void getLogStatus()
        {
            string currentLine;
            string split = "MOUPG";
            string formattedLine = "Unable to get log info";
            try
            {
                if (getLogLocation() == "\\\\" + PCName + "\\c$\\windows\\panther\\setupact.log")
                {
                    LogResult = "Finalizing";
                }
                else
                {
                    using (FileStream logFileStream = new FileStream("\\\\" + PCName + "\\c$\\$windows.~BT\\sources\\panther\\setupact.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader logFileReader = new StreamReader(logFileStream))
                        {
                            while ((currentLine = logFileReader.ReadLine()) != null)
                            {
                                if (currentLine.Contains("Overall progress: "))
                                {

                                    // logList.Add(currentLine);
                                    formattedLine = currentLine.Substring(currentLine.IndexOf(split) + split.Length);
                                    LogResult = formattedLine;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                LogResult = "Unable to get log status";
            }
          
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
                case "6.1.7601":
                    CurrentVersion = "Windows 7 - SP1";
                    break;
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
            if(!(FreeSpace == "WMI Failed"))
            {
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

                    decimal tempSpaceCast = Int64.Parse(tempSpace);
                    decimal freespace = tempSpaceCast / 1073741824;
                    var freespaceRounded = Math.Round(freespace, 2);
                    this.FreeSpace = freespaceRounded.ToString() + "GB";
                }
                catch
                {
                    this.FreeSpace = "WMI Failed";
                }
            }
           

         

        }
        public bool killSetup()
        {
            var processName = "setupHost.exe";

            string wmiPath = "\\\\" + PCName + "\\root\\cimv2";

            ConnectionOptions options = new ConnectionOptions();
            ManagementScope scope = new ManagementScope(wmiPath, options);

            try
            {
                var query = new SelectQuery("select * from Win32_process where name = '" + processName + "'");

                using (var searcher = new ManagementObjectSearcher(scope, query))
                {
                    foreach (ManagementObject process in searcher.Get())
                    {
                        process.InvokeMethod("Terminate", null);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}
