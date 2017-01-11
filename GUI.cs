using System;
using System.IO;
using System.Windows.Forms;

namespace CM3D2_Updater {
    public partial class GUI : Form {
        public GUI() {
            if (!Program.isInstalled) {
                MessageBox.Show("Custom Maid 3D 2 Is not installed!", "Could not find your CM3D2 install directory (TODO: Add registry fix option)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (!File.Exists(Program.installDir + @"\Update.lst")) File.Create(Program.installDir + @"\Update.lst");
            string line;
            StreamReader file = new StreamReader(Program.installDir + @"\Update.lst");
            while ((line = file.ReadLine()) != null) {
                Program.installed.Add(line);
                Program.installedContent.Add(new UpdateItem("0,0," + line.Split(',')[0] + ",x,x," + line.Split(',')[1], Program.installDir));
            }
            file.Close();
            Program.console.BackColor = consolePlaceholder.BackColor; //workaround for making console logging global with VS Form designer
            Program.console.HideSelection = false;
            Program.console.Location = consolePlaceholder.Location;
            Program.console.Name = "console";
            Program.console.ReadOnly = true;
            Program.console.Size = consolePlaceholder.Size;
            Program.console.TabIndex = 2;
            Program.console.Text = "";
            Program.console.WordWrap = consolePlaceholder.WordWrap;
            Controls.Add(Program.console);
        }
        public int currentItem = -1;
        public void checkDir(String path) {
            path = path + "/";
            String[] dirs = Directory.GetDirectories(path);
            Program.Log("Scanning " + path);
            foreach (var dir in dirs) {
                if (dir.Substring(dir.Length - 4) == "data" && path != "./") {
                    if (Array.IndexOf(Directory.GetFiles(path), path+"update.lst") != -1) {
                        Program.Log("Found installable content!");
                        contentSelector.Items.Add(path.Split('/')[path.Split('/').Length - 2].ToString());
                        Program.allContent.Add(new Content(path));
                    }
                } else {
                    checkDir(dir);
                }
            }
        }

        public void contentSelector_SelectedIndexChanged(object sender, EventArgs e) {
            Program.selected.Clear();
            Program.hasVerified = false;
            if (currentItem == contentSelector.SelectedIndex) return; //Not sure why I programmed it like this when I knew I'd support installing multiple updates eventually
            currentItem = contentSelector.SelectedIndex;
            foreach (var index in contentSelector.SelectedIndices) {
                Program.selected.Add(Program.allContent[Int32.Parse(index.ToString())]);
            }
        }

        public void scanButt_Click(object sender, EventArgs e) {
            contentSelector.Items.Clear();
            Program.selected.Clear();
            Program.allContent.Clear();
            currentItem = -1;
            Program.console.ResetText();
            Program.Log("Scanning all directories...");
            checkDir(".");
        }

        public void installButton_Click(object sender, EventArgs e) {
            Program.Log("Installing content...");
            if (currentItem == -1) {
                MessageBox.Show("No installable content selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Program.Log("Warning: No installable content selected");
                return;
            }
            string line;
            StreamReader file = new StreamReader(Program.installDir + @"\Update.lst");
            while ((line = file.ReadLine()) != null) {
                Program.installed.Add(line);
                Program.installedContent.Add(new UpdateItem("0,0," + line.Split(',')[0] + ",x,x," + line.Split(',')[1], Program.installDir));
            }
            file.Close();
            Form installDialog = new Installer();
            installDialog.ShowDialog();
        }

        private void verifyButt_Click(object sender, EventArgs e) {
            Program.hasVerified = true;
            foreach (var content in Program.selected) content.verifyUpdates();
        }
    }
}
