using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TableMerger
{

    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            textBox1.Text = config.AppSettings.Settings.CurrentConfiguration.AppSettings.Settings["EssenPath"].Value;
            textBox2.Text = config.AppSettings.Settings.CurrentConfiguration.AppSettings.Settings["RathausPath"].Value;
            textBox3.Text = config.AppSettings.Settings.CurrentConfiguration.AppSettings.Settings["SchwarzwaldPath"].Value;
            textBox4.Text = config.AppSettings.Settings.CurrentConfiguration.AppSettings.Settings["FinalPath"].Value;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseDialog = new OpenFileDialog();
            BrowseDialog.Filter = "CSV-Tabellen|*.csv";
            BrowseDialog.FilterIndex = 1;
            if (BrowseDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = BrowseDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseDialog = new OpenFileDialog();
            BrowseDialog.Filter = "CSV-Tabellen|*.csv";
            BrowseDialog.FilterIndex = 1;
            if (BrowseDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = BrowseDialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseDialog = new OpenFileDialog();
            BrowseDialog.Filter = "CSV-Tabellen|*.csv";
            BrowseDialog.FilterIndex = 1;
            if (BrowseDialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = BrowseDialog.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog OutputFile = new SaveFileDialog();
            OutputFile.Filter = "CSV-Tabellen|*.csv";
            OutputFile.FilterIndex = 1;
            if (OutputFile.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = OutputFile.FileName;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var execute = new Reader();
            execute.TableCompiler(textBox1.Text, 1);
            execute.TableCompiler(textBox2.Text, 2);
            execute.TableCompiler(textBox3.Text, 3);
            execute.SortList();
            execute.CreateHeader();
            execute.FileWriter(textBox4.Text);
            AutoClosingMessageBox.Show("Erfolgreich!", "Done", 5000);
            Environment.Exit(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.CurrentConfiguration.AppSettings.Settings["EssenPath"].Value = textBox1.Text;
            config.AppSettings.Settings.CurrentConfiguration.AppSettings.Settings["RathausPath"].Value = textBox2.Text;
            config.AppSettings.Settings.CurrentConfiguration.AppSettings.Settings["SchwarzwaldPath"].Value = textBox3.Text;
            config.AppSettings.Settings.CurrentConfiguration.AppSettings.Settings["FinalPath"].Value = textBox4.Text;
            
          /*  config.AppSettings.Settings["EssenPath"].Value = textBox1.Text;
            config.AppSettings.Settings["RathausPath"].Value = textBox2.Text;
            config.AppSettings.Settings["SchwarzwaldPath"].Value = textBox3.Text;
            config.AppSettings.Settings["FinalPath"].Value = textBox4.Text;*/
            /*config.AppSettings.Settings.Remove("EssenPath");
            config.AppSettings.Settings.Remove("RathausPath");
            config.AppSettings.Settings.Remove("SchwarzwaldPath");
            config.AppSettings.Settings.Remove("FinalPath");
           config.AppSettings.Settings.Add("EssenPath", textBox1.Text);
            config.AppSettings.Settings.Add("RathausPath", textBox2.Text);
            config.AppSettings.Settings.Add("SchwarzwaldPath", textBox3.Text);
            config.AppSettings.Settings.Add("FinalPath", textBox4.Text);*/
            
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
