using System;
using System.IO;
using System.Windows.Forms;

namespace CM3D2_Updater { //TODO: Allow installing multiple files (DO THIS!!!)
    public partial class Installer : Form
    {
        public Installer()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            scanning = true;
            foreach (var item in Program.selected) { //TODO: find a better way... too many loops
                foreach (var file in item.updatelst) {
                    Boolean install = false;
                    int currentVersion = 0;
                    foreach (var installed in Program.installedContent) {
                        if (installed.name == file.name && installed.path.Split('\\')[0] == file.path.Split('\\')[0]) {
                            if (installed.version == file.version) {
                                install = false;
                                currentVersion = installed.version;
                            } else if (installed.version < file.version) {
                                install = true;
                                currentVersion = installed.version;
                            }
                            break;
                        }
                    }
                    if (!install && currentVersion == 0 || install) installButton.Enabled = file.install = install = true;
                    selectedContent.Items.Add(file.name + " " + file.version + " -> " + currentVersion, install);
                }
            }
            scanning = false;
        }
        private void cancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void selectedContent_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (!scanning) e.NewValue = e.CurrentValue;
        }

        private void installButton_Click(object sender, EventArgs e) {
            foreach (var content in Program.selected) {
                if (!content.verified && !Program.hasVerified || content.verified) {
                    content.install();
                } else {
                    Program.Log(content.name + " wasn't verified, skipping");
                }
            }
            this.Close();
            Program.Log("Updating CM3D2 Update.lst"); //TODO
            foreach (var content in Program.selected) {
                if (!content.verified && !Program.hasVerified || content.verified) {
                    foreach (var item in content.updatelst) {
                        if (item.install) {
                            Program.Log("Setting " + item.name + " installed version to " + item.version);
                            int installedIndex = -1;
                            foreach (var installed in Program.installed) {
                                if (installed.Contains(item.name)) {
                                    installedIndex = Program.installed.IndexOf(installed);
                                    break;
                                }
                            }
                            if (installedIndex != -1) {
                                Program.installed[installedIndex] = item.path+","+item.version;
                            } else {
                                Program.installed.Add(item.path+","+item.version);
                            }
                        }
                    }
                }
            }
            Program.Log("Writing to file");
            File.WriteAllText(Program.installDir + @"\Update.lst", String.Join("\n", Program.installed));
        }
    }
}
