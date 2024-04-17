using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1102065_Final_v2
{
    public partial class Config : Form
    {
        string settingInJsonPath = "./Setting/settings.json";
        JObject settings;
        Form1 f1;
        public Config(Form1 f1)
        {
            this.f1 = f1;
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            string jsonContent = File.ReadAllText(settingInJsonPath);
            settings = JObject.Parse(jsonContent);
            JArray ReferersInJson = (JArray)settings["M3U8"]["Referers"];

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Website";
            dataGridView1.Columns[1].Name = "Referer";
            dataGridView1.RowHeadersWidth = 30;
            dataGridView1.Columns[0].Width = dataGridView1.Width / 2 - 16;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 2 - 16;

            foreach (JObject referer in ReferersInJson)
            {
                string[] row = { referer["Website"].ToString(), referer["Referer"].ToString() };
                dataGridView1.Rows.Add(row);
            };
                
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText(settingInJsonPath);
            JObject jsonObj = JsonConvert.DeserializeObject<JObject>(json);
            JArray referers = (JArray)jsonObj["M3U8"]["Referers"];
            referers.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                JObject newItem = new JObject();
                if(row.Cells[0].Value != null && row.Cells[1].Value!= null)
                {
                    newItem["Website"] = (string)row.Cells[0].Value;
                    newItem["Referer"] = (string)row.Cells[1].Value;
                    referers.Add(newItem);
                }
            }

            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(settingInJsonPath, output);
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
