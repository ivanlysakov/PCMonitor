using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace PCMonitorService
{
    public partial class Service1 : ServiceBase
    {
        protected PerformanceCounter cpuCounter;
        protected PerformanceCounter ramCounter;
        
        Timer timer = new Timer();
               
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 1000; //number in milisecinds  
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            StringBuilder hostInfo  = new StringBuilder("Service is recall at " + DateTime.Now);
            hostInfo.Append("\nPC name: " + Environment.MachineName);
            hostInfo.Append("\nUser name: " + Environment.GetEnvironmentVariable("UserName"));
            hostInfo.Append("\n" + GetManufacturer());
            hostInfo.Append("\n" + GetCpuLoad());
            hostInfo.Append("\n" + GetRamLoad());

            WriteToFile(hostInfo.ToString());
            
        }
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }


        public string GetManufacturer(){
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            //collection to store all management objects
            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count != 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    StringBuilder manufacturer = new StringBuilder("Machine Make: ");
                    manufacturer.Append(mo["Manufacturer"].ToString());
                    manufacturer.Append("\n");
                    return manufacturer.ToString();
                }
           
            }
            return null;

        }

        public string GetCpuLoad() 
        {
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            cpuCounter.NextValue();
            System.Threading.Thread.Sleep(500);
            return cpuCounter.NextValue().ToString() + "%"; 
        }

        public string GetRamLoad()
        {
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            return ramCounter.NextValue() + "Mb";
        }
    }
}
