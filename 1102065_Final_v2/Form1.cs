using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _1102065_Final_v2
{
    public partial class Form1 : Form
    {
        static string settingInJsonPath = "./Setting/settings.json";
        static string LogSavePath = "./Log";
        internal string URL { get { return M3U8_txt.Text; } }
        internal string Format { get { return Format_cmb.Text; } }
        internal string SavePath { get { return SavePath_txt.Text; } }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialComponent();
        }

        private void InitialComponent()
        {
            string jsonContent = File.ReadAllText(settingInJsonPath);
            JObject settings = JObject.Parse(jsonContent);
            JArray FormatsInJson = (JArray)settings["Form1"]["Formats"];
            foreach (string f in FormatsInJson)
            {
                Format_cmb.Items.Add(f);
            }
            Format_cmb.Text = FormatsInJson[0].ToString();
            Format_cmb.SelectedValue = FormatsInJson[0].ToString();

            SavePath_txt.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        }

        private void DisplayLog_mns_Click(object sender, EventArgs e)
        {
            if (DisplayLog_mns.Checked || DisplayLog_cms.Checked)
            {
                DisplayLog_mns.Checked = false;
                DisplayLog_cms.Checked = false;
                this.Width = 440;
            }
            else
            {
                DisplayLog_mns.Checked = true;
                DisplayLog_cms.Checked = true;
                this.Width = 1000;
            }
        }

        private void Exit_mns_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SavePath_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                SavePath_txt.Text = folder.SelectedPath;
            }
        }

        private void Config_mns_Click(object sender, EventArgs e)
        {
            Config config = new Config(this);
            config.ShowDialog();
        }

        private async void Start_btn_Click(object sender, EventArgs e)
        {
            Log_rtx.Clear();

            try
            {
                if (M3U8_txt.Text == string.Empty)
                {
                    throw new Exception("M3U8 URL can't be empty");
                }
                if (!Directory.Exists(SavePath_txt.Text))
                {
                    throw new Exception("The save path is invalid");
                }
                DateTime StartTime = DateTime.Now;
                Start_btn.Enabled = false;
                await new M3U8(this, StartTime).RunAsync();
                saveLog(StartTime);
                Start_btn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Input Error");
            }
        }

        internal void Add_Log_rtx(string text)
        {
            if (Log_rtx.InvokeRequired)
            {
                Action safeWrite = delegate { Add_Log_rtx(text); };
                Log_rtx.Invoke(safeWrite);
            }
            else
            {
                Log_rtx.AppendText(String.Format("{0}: {1}\n", DateTime.Now.ToString(), text));
            }
                

        }

        internal void setProgressBar(int Value, int Maximum)
        {
            if (Log_rtx.InvokeRequired)
            {
                Action safeWrite = delegate { setProgressBar(Value, Maximum); };
                Log_rtx.Invoke(safeWrite);
            }
            else
            {
                progressBar.Maximum = Maximum;
                progressBar.Value = Value;
            }
        }

        internal void setStatus_lbl(string text, Color color)
        {
            if (Log_rtx.InvokeRequired)
            {
                Action safeWrite = delegate { setStatus_lbl(text, color); };
                Log_rtx.Invoke(safeWrite);
            }
            else
            {
                Status_lbl.Text = text;
                Status_lbl.ForeColor = color;
            }
                

        }

        private void saveLog(DateTime StartTime)
        {
            if (!Directory.Exists(LogSavePath))
            {
                Directory.CreateDirectory(LogSavePath);
            }
            string SavePath = String.Format("{0}/{1}.log", LogSavePath, StartTime.ToString("yyyyMMdd_HHmmss"));
            Add_Log_rtx("Saving Log to " + SavePath);
            FileStream fsStream = new FileStream(SavePath, FileMode.Create);
            string[] LogText = Log_rtx.Text.Split('\n');
            StreamWriter sw = new StreamWriter(fsStream);
            foreach (string line in LogText)
            {
                sw.WriteLine(line);
            }
            sw.Close();
            fsStream.Close();
        }

        private void Log_rtx_TextChanged(object sender, EventArgs e)
        {
            Log_rtx.SelectionStart = Log_rtx.Text.Length;
            Log_rtx.ScrollToCaret();
        }
    }
}
