using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("ps2exe")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("donet3.5")]
[assembly: AssemblyCompany("WuHan IT Team")]
[assembly: AssemblyProduct("由ps2exe生成")]
[assembly: AssemblyCopyright("Copyright © WuHan IT Team 2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace sample3._5
{
    class program
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
