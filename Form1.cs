using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace ddda_savemanager
{
    public partial class Form1 : Form
    {
        private string saveLocation;
        private SaveFile mainSave;
        private string lastChecksum;
        private List<SaveFile> saveFiles = new List<SaveFile>();
        private Timer check = new Timer();
        private Timer msgTimer = new Timer();
        private int maxSaves;

        public Form1()
        {
            InitializeComponent();
            InitSettingsMenu();

            if (!File.Exists("settings.txt"))
            {
                FormSettings f2 = new FormSettings(this);
                f2.ShowDialog(this);
            }

            LoadSettings();

            mainSave = new SaveFile(saveLocation + "ddda.sav");
            lastChecksum = mainSave.GetChecksum();

            currentSave.Text = mainSave.GetLastChangedDate() + "         " + mainSave.GetChecksum();
            status.Text = "";

            msgTimer.Interval = 3000;
            check.Tick += new EventHandler(timerTick);
            msgTimer.Tick += new EventHandler(hideMsg);
            check.Start();

            InitList();
        }

        private void InitList()
        {
            saveFiles.Clear();
            saveList.Clear();
            saveList.View = View.Details;
            saveList.MultiSelect = false;
            saveList.FullRowSelect = true;
            saveList.LabelEdit = true;
            saveList.Columns.Add("Name", 130, HorizontalAlignment.Left);
            saveList.Columns.Add("Date", 130, HorizontalAlignment.Left);
            saveList.Columns.Add("Checksum", 210, HorizontalAlignment.Left);
            saveList.Columns.Add("Size", 50, HorizontalAlignment.Left);

            string[] files = System.IO.Directory.GetFiles(saveLocation);

            for (int i = 0; i < files.Length; i++)
            {
                SaveFile save = new SaveFile(files[i]);

                if (Path.GetFileName(files[i]) != "ddda.sav")
                {
                    saveFiles.Add(save);
                }
            }

            saveFiles.Sort((x, y) => y.GetTimeStamp().CompareTo(x.GetTimeStamp()));

            for (int i = 0; i < saveFiles.Count(); i++)
            {
                saveList.Items.Add(ToListRow(saveFiles[i]));
            }

            while(saveFiles.Count() > maxSaves)
            {
                DeleteOldestSave();
            }
        }

        void timerTick(object sender, EventArgs e)
        {
            if (lastChecksum != mainSave.GetChecksum())
            {
                Backup();
                lastChecksum = mainSave.GetChecksum();
                currentSave.Text = mainSave.GetLastChangedDate() + "         " + mainSave.GetChecksum();
            }
        }

        void hideMsg(object sender, EventArgs e)
        {
            status.Text = "";
            msgTimer.Stop();
        }

        private void setSave_Click(object sender, EventArgs e)
        {   if (saveList.SelectedItems.Count > 0)
            {
                SaveFile file = saveFiles[saveList.SelectedIndices[0]];
                File.Copy(file.location, saveLocation + "ddda.sav", true);

                lastChecksum = mainSave.GetChecksum();
                currentSave.Text = mainSave.GetLastChangedDate() + "         " + mainSave.GetChecksum();
                ShowMsg("Save loaded!");
            }
            else
                ShowMsg("Select a save file first!");
        }

        private void Backup()
        {
            mainSave.Reload();
            string bk = saveLocation + mainSave.GetTimeCode() + ".sav";
            File.Copy(mainSave.location, bk, true);

            SaveFile bakSave = new SaveFile(bk);
            bakSave.SetTimeStamp(mainSave.GetTimeStamp());

            if (!saveFiles.Any(saveFiles => saveFiles.GetChecksum() == bakSave.GetChecksum()))
            {
                saveFiles.Insert(0, bakSave);
                saveList.Items.Insert(0, ToListRow(bakSave));
                ShowMsg("Backup done!");
            }

            if (saveFiles.Count() > maxSaves)
                DeleteOldestSave();
        }

        private ListViewItem ToListRow(SaveFile file)
        {
            ListViewItem item = new ListViewItem(new[] { file.name, file.GetLastChangedDate(), file.GetChecksum(), file.GetFileSize() });
            return item;
        }

        private void ShowMsg(string msg)
        {
            status.Text = msg;
            msgTimer.Start();
        }

        private void DeleteOldestSave()
        {
            if (saveFiles.Count() > 0)
            {
                File.Delete(saveFiles[saveFiles.Count() - 1].location);
                saveFiles.RemoveAt(saveFiles.Count() - 1);
                saveList.Items.RemoveAt(saveFiles.Count());
            }
        }

        private void saveList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {   
            if(e.Label == null)
            {
                e.CancelEdit = true;
                return;
            }

            if (e.Label.ToString().ToLower() == "ddda")
            {
                e.CancelEdit = true;
                ShowMsg("This is the default one!");
                return;
            }

            Regex r = new Regex(@"^[a-zA-Z0-9_$ ]+$");
            if (!r.IsMatch(e.Label.ToString()))
            {
                e.CancelEdit = true;
                ShowMsg("Illegal characters!");
                return;
            }

            if(saveFiles.Any(x => x.name == e.Label.ToString()))
            {
                e.CancelEdit = true;
                ShowMsg("Name already exists!");
                return;
            }

            SaveFile file = saveFiles[saveList.SelectedIndices[0]];
            string rn = saveLocation + e.Label.ToString() + ".sav";
            File.Move(file.location, rn);
            file.Load(rn);
            ShowMsg("Name changed!");
        }

        private void saveList_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.ToString() == "F2")
            {
                saveList.SelectedItems[0].BeginEdit();
            }
        }

        private void LoadSettings()
        {   
            check.Interval = 5000;
            maxSaves = 100;
            StreamReader file = new StreamReader("settings.txt");
            saveLocation = file.ReadLine();
            check.Interval = (int) (float.Parse(file.ReadLine()) * 1000);
            maxSaves = int.Parse(file.ReadLine());
            file.Close();

            if(!File.Exists(saveLocation + @"\ddda.sav"))
            {
                MessageBox.Show("Save file not found! Please select the save file!");
                FormSettings f2 = new FormSettings(this);
                f2.ShowDialog(this);
            }
        }

        // Settings context menu

        private void InitSettingsMenu()
        {
            IntPtr hMenu = GetSystemMenu(Handle, false);
            if (hMenu != IntPtr.Zero)
            {
                var menuInfo = new MENUITEMINFO
                {
                    cbSize = (uint)Marshal.SizeOf(typeof(MENUITEMINFO)),
                    cch = 255,
                    dwTypeData = "Settings",
                    fMask = 0x1 | 0x2 | 0x10,
                    fState = 0,
                    wID = 0x1,
                    fType = 0x0
                };

                InsertMenuItem(hMenu, 0, true, ref menuInfo);
                DrawMenuBar(Handle);
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool InsertMenuItem(IntPtr hMenu, uint uItem,
                          bool fByPosition, [In] ref MENUITEMINFO lpmii);


        [StructLayout(LayoutKind.Sequential)]
        public struct MENUITEMINFO
        {
            public uint cbSize;
            public uint fMask;
            public uint fType;
            public uint fState;
            public uint wID;
            public IntPtr hSubMenu;
            public IntPtr hbmpChecked;
            public IntPtr hbmpUnchecked;
            public IntPtr dwItemData;
            public string dwTypeData;
            public uint cch;
            public IntPtr hbmpItem;
        }

        // Add ID for the Menu
        private const int WM_SYSCOMMAND = 0x112;
        // Event method for the Menu
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //m.WParam = the wID you gave the Menu Item
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == 0x1))
            {
                FormSettings f2 = new FormSettings(saveLocation + "ddda.sav", check.Interval / 1000, maxSaves);
                f2.ShowDialog();
                LoadSettings();
            }

        }
    }
}
