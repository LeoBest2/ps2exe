using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ps2exe
{
    public partial class Form1 : Form
    {
        private static readonly string donet3Compiler = string.Format(@"{0}\Windows\Microsoft.NET\Framework64\v3.5\MSBuild.exe", Environment.GetEnvironmentVariable("HOMEDRIVE"));
        private static readonly string donet4Compiler = string.Format(@"{0}\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe", Environment.GetEnvironmentVariable("HOMEDRIVE"));
        private static readonly string currentPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        private static readonly string configPath = string.Format(@"{0}\config\sample", currentPath);
        private string psSrcFileName = null;
        private string icoPath = null;
        private string psSrcCode = null;
        private string sampleContent = null;
        public Form1()
        {
            InitializeComponent();
            // 初始化环境检测
            radioBoxDoNet3_5.Enabled = File.Exists(donet3Compiler) ? true : false;
            radioBoxDoNet4_0.Enabled = File.Exists(donet4Compiler) ? true : false;
            if (!radioBoxDoNet3_5.Enabled && !radioBoxDoNet4_0.Enabled)
            {
                MessageBox.Show("没有找到doNet3.5 && doNet4.0, 程序无法继续!", "错误");
                Environment.Exit(1);
            }
            // 默认优先选择donet4
            if (radioBoxDoNet4_0.Enabled) { radioBoxDoNet4_0.Checked = true; }
            else { radioBoxDoNet3_5.Checked = true; }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = currentPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                psSrcFileName = openFileDialog1.FileName;
                textBoxFilePath.Text = psSrcFileName;
            }
        }

        private void btnIcon_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = currentPath;
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                icoPath = openFileDialog2.FileName;
                textBoxIco.Text = icoPath;
            }
        }

        private void DisableComponents()
        {
            btnOpenFile.Enabled = false;
            btnConvert.Enabled = false;
            checkBoxHidden.Enabled = false;
            checkBoxRunAsAdmin.Enabled = false;
            radioBoxDoNet3_5.Enabled = false;
            radioBoxDoNet4_0.Enabled = false;
        }

        private void EnableComponents()
        {
            btnOpenFile.Enabled = true;
            btnConvert.Enabled = true;
            checkBoxHidden.Enabled = true;
            checkBoxRunAsAdmin.Enabled = true;
            radioBoxDoNet3_5.Enabled = File.Exists(donet3Compiler) ? true : false;
            radioBoxDoNet4_0.Enabled = File.Exists(donet4Compiler) ? true : false;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DisableComponents();
            try { psSrcCode = File.ReadAllText(psSrcFileName); }
            catch { MessageBox.Show("打开文件: " + (psSrcFileName == null ? "<未选择输入文件>" : psSrcFileName) + " 失败!", "错误"); goto EndInvoke; }
            textBoxLog.Text = string.Format("****读入文件: {0} 内容成功****\r\n", Path.GetFileName(psSrcFileName));
            // 生成源代码
            string sampleFilePath = string.Format(@"{0}\program.sample.cs", configPath);
            try { sampleContent = File.ReadAllText(sampleFilePath); }
            catch { MessageBox.Show("打开文件: " + sampleFilePath + " 失败!", "错误"); goto EndInvoke; }
            textBoxLog.Text += string.Format("****读入模板文件: {0} 内容成功****\r\n", sampleFilePath);
            byte[] bytes = Encoding.Unicode.GetBytes(psSrcCode);
            string encodedCommand = Convert.ToBase64String(bytes);
            string hidden = checkBoxHidden.Checked ? "true" : "false";
            sampleContent = sampleContent.Replace("VAR_IS_NOWINDOW", hidden);
            sampleContent = sampleContent.Replace("VAR_ENCODE_COMMAND", encodedCommand);
            // 写入源代码到program.cs
            string dstFilePath = string.Format(@"{0}\program.cs", configPath);
            try { File.WriteAllText(dstFilePath, sampleContent); }
            catch { MessageBox.Show("打开文件: " + dstFilePath + " 失败!", "错误"); goto EndInvoke; }
            textBoxLog.Text += string.Format("****生成代码文件: {0} 成功****\r\n", dstFilePath);
            // 配置icon文件
            if (icoPath != null)
            {
                try
                {
                    bytes = File.ReadAllBytes(icoPath);
                    File.WriteAllBytes(string.Format(@"{0}\favicon.ico", configPath), bytes);
                }
                catch
                {
                    MessageBox.Show(string.Format(@"写入图标文件: {0}\favicon.ico 失败!", configPath), "错误");
                    goto EndInvoke;
                }
            }
            // 配置工程文件
            string projFile = null;
            try
            {
                if (radioBoxDoNet3_5.Checked)
                {
                    string app = File.ReadAllText(string.Format(@"{0}\App3.5.config", configPath));
                    File.WriteAllText(string.Format(@"{0}\App.config", configPath), app);
                }
                else
                {
                    string app = File.ReadAllText(string.Format(@"{0}\App4.0.config", configPath));
                    File.WriteAllText(string.Format(@"{0}\App.config", configPath), app);
                }
            }
            catch
            {
                MessageBox.Show(string.Format(@"写入图标文件: {0}\App.config 失败!", configPath), "错误");
                goto EndInvoke;
            }
            if (radioBoxDoNet3_5.Checked)
            {
                if (checkBoxRunAsAdmin.Checked)
                {
                    projFile = icoPath == null ? string.Format(@"{0}\sample3.5-admin.sample.csproj", configPath) : string.Format(@"{0}\sample3.5-admin-ico.sample.csproj", configPath);
                }
                else
                {
                    projFile = icoPath == null ? string.Format(@"{0}\sample3.5.sample.csproj", configPath) : string.Format(@"{0}\sample3.5-ico.sample.csproj", configPath);
                }
            }
            else
            {
                if (checkBoxRunAsAdmin.Checked)
                {
                    projFile = icoPath == null ? string.Format(@"{0}\sample4.0-admin.sample.csproj", configPath) : string.Format(@"{0}\sample4.0-admin-ico.sample.csproj", configPath);
                }
                else
                {
                    projFile = icoPath == null ? string.Format(@"{0}\sample4.0.sample.csproj", configPath) : string.Format(@"{0}\sample4.0-ico.sample.csproj", configPath);
                }
            }
            // 开始编译工程
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = radioBoxDoNet4_0.Checked ? donet4Compiler : donet3Compiler,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = currentPath,
                Arguments = string.Format("\"{0}\" /p:Configuration=Release", projFile),
            };
            textBoxLog.Text += string.Format("****正在编译项目文件:{0} ...... ****\r\n", startInfo.Arguments);
            Process process = new Process { StartInfo = startInfo };
            string output = null;
            process.ErrorDataReceived += new DataReceivedEventHandler((_s, _e) => { output += "\r\n" + _e.Data; });
            process.OutputDataReceived += new DataReceivedEventHandler((_s, _e) => { output += "\r\n" + _e.Data; });
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            textBoxLog.Text += "\r\n" + output;
            if (process.ExitCode == 0)
            {
                textBoxLog.Text += "\r\n编译成功!\r\n";
                try
                {
                    File.WriteAllBytes(string.Format(@"{0}.exe", psSrcFileName),
                        File.ReadAllBytes(string.Format(@"{0}\bin\Release\sample3.5.exe", configPath)));
                    MessageBox.Show("编译成功!", "成功");
                }
                catch
                {
                    MessageBox.Show(string.Format(@"拷贝生成的exe文件失败,请手动复制出来! {0}\bin\Release\sample3.5.exe", configPath), "警告");
                }
            }
            else
            {
                textBoxLog.Text += "\r\n编译失败,请查看错误信息!\r\n";
            }
        EndInvoke:
            EnableComponents();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog(this);
        }

        private void menuUsage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请查看readme文档!", "帮助");
        }
    }
}
