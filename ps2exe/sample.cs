using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

namespace Ps2Exe
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                UseShellExecute = false,
                CreateNoWindow = VAR_IS_NOWINDOW,
                // WindowStyle=ProcessWindowStyle.Hidden,
                WorkingDirectory = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName),
                Arguments = "",
            };
            string encodeCommand = "VAR_ENCODE_COMMAND";
            byte[] bytes = Convert.FromBase64String(encodeCommand);
            string decodeCommand = Encoding.Unicode.GetString(bytes);
            List<string> argsQuote = new List<string>();
            foreach (string arg in args)
            {
                argsQuote.Add(string.Format("\"{0}\"", arg));
            }
            string commandWithArgs = string.Format("$args=@({0})\r\n{1}", string.Join(",", argsQuote.ToArray()), decodeCommand);
            // System.IO.File.WriteAllText("debug.ps1", commandWithArgs);
            bytes = Encoding.Unicode.GetBytes(commandWithArgs);
            string encodeCommandWithArgs = Convert.ToBase64String(bytes);
            startInfo.Arguments = string.Format("-encodedCommand {0}", encodeCommandWithArgs);
            Process process = new Process { StartInfo = startInfo };
            process.Start();
        }
    }
}


