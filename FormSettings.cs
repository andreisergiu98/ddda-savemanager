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
using System.Runtime.InteropServices;

namespace ddda_savemanager
{
    public partial class FormSettings : Form
    {
        private Form opener;

        private bool exitingOk = false;

        public FormSettings(Form parentForm)
        {
            InitializeComponent();
            opener = parentForm;
            status.Text = "";
        }
        public FormSettings(string path, int interval, int maxSaves)
        {
            InitializeComponent();
            status.Text = "";
            this.path.Text = path;
            exitingOk = true;
            this.interval.Value = interval;
            this.maxSaves.Value = maxSaves;
        }


        private void browsePath_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Select DDDA save file";
            dialog.FileName = "ddda*";
            dialog.Filter = "SAV file|*.sav";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path.Text = dialog.FileName;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if(!exitingOk)
               Environment.Exit(1);
            else
            {
                this.Close();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (File.Exists(path.Text.ToString()) && Path.GetFileName(path.Text.ToString()) == "ddda.sav")
            {
                StreamWriter file = new StreamWriter("settings.txt");
                file.WriteLine(Path.GetDirectoryName(path.Text.ToString()) + @"\");
                file.WriteLine(interval.Value);
                file.WriteLine(maxSaves.Value);
                exitingOk = true;
                file.Close();
                this.Close();
            }
            else
            {
                status.Text = "Save file not found!";
            }
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitingOk)
                Environment.Exit(1);
        }
    }
}
