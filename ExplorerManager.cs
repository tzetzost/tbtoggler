using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBToggler
{
    class ExplorerManager
    {
        public static void RestartExplorer()
        {
            StopExplorer();
            StartExplorer();
        }

        private static void StartExplorer()
        {
            string explorerFile = string.Format("{0}\\{1}", Environment.GetEnvironmentVariable("WINDIR"), "explorer.exe");
            Process newProcess = new Process();
            newProcess.StartInfo.FileName = explorerFile;
            newProcess.StartInfo.UseShellExecute = true;
            newProcess.StartInfo.CreateNoWindow = true;
            newProcess.Start();
        }

        private static void StopExplorer()
        {
            var explorers = Process.GetProcessesByName("explorer");
            if (explorers.Length == 0)
            {
                Debug.WriteLine("No explorer processes found.");
            }

            foreach (Process process in explorers)
            {
                Debug.WriteLine($"Attempting to close explorer process with ID: {process.Id}");
                //if (!process.CloseMainWindow())
                //{
                    //Debug.WriteLine($"Failed to send close message to process {process.Id}, killing process.");
                    process.Kill();
                //}
                //else
                //{
                //    debug.writeline($"close message sent to process {process.id}");
                //}
            }
        }

    }
}
