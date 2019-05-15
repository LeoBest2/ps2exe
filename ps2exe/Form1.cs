using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ps2exe
{
    public partial class Form1 : Form
    {
        private string command;
        private string encodedCommand;
        private string currentPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        private string sampleContent;
        private string fileName;
        public Form1()
        {
            try
            {
                sampleContent = File.ReadAllText(currentPath + @"\sample.cs");
            }
            catch(IOException)
            {
                MessageBox.Show("打开sample.cs错误!", "错误");
                Environment.Exit(0);
            }
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = currentPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                textBox1.Text = fileName;                
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                command = File.ReadAllText(fileName);
            }
            catch
            {
                MessageBox.Show("打开文件: " + fileName + " 失败!", "错误");
                return;
            }
            byte[] bytes = Encoding.Unicode.GetBytes(command);
            encodedCommand = Convert.ToBase64String(bytes);

            string tmpfile = currentPath + @"\tmp\tmp.cs";
            btnOpenFile.Enabled = false;
            btnConvert.Enabled = false;
            checkBoxHidden.Enabled = false;
            label1.Text = "正在生成临时文件: tmp.cs";
            string hidden = checkBoxHidden.Checked ? "true" : "false";
            sampleContent = sampleContent.Replace("VAR_IS_NOWINDOW", hidden);
            sampleContent = sampleContent.Replace("VAR_ENCODE_COMMAND", encodedCommand);
            File.WriteAllText(tmpfile, sampleContent);
            label1.Text = "正在编译文件为exe: tmp.cs";

            string cscPath = @"C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe";
            if (!File.Exists(cscPath))
            {
                MessageBox.Show("没有检测到donet3.5\n" + cscPath, "错误");
                label1.Text = "请安装donet3.5到C盘!";
                return;
            }
            string outfile = string.Format("{0}\\{1}.exe", currentPath, Path.GetFileName(fileName));
            ProcessStartInfo startInfo = new ProcessStartInfo { 
                FileName = cscPath,
                UseShellExecute = false,
                WorkingDirectory=currentPath,
                Arguments = string.Format("/target:winexe /out:\"{0}\" \"{1}\"", outfile, tmpfile)
            };

            File.WriteAllText(currentPath + @"\debug.cmd", startInfo.FileName + " " + startInfo.Arguments);

            Process process = new Process { StartInfo = startInfo };
            process.Start();
            process.WaitForExit();
            if (process.ExitCode == 0) { label1.Text = "编译完成!"; }
            else { label1.Text = "编译失败, 请手动运行debug.cmd查看错误!"; }
            btnOpenFile.Enabled = true;
            btnConvert.Enabled = true;
            checkBoxHidden.Enabled = true;

        }

        private void checkBoxHidden_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
