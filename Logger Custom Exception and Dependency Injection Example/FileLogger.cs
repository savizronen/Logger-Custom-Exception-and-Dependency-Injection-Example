using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger_Custom_Exception_and_Dependency_Injection_Example
{
    class FileLogger : ILogger
    {
        public void Log(string message)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"logfile.txt", true))
            {
                file.WriteLine($"[{DateTime.Now}] {message}");
            }
        }
    }
}