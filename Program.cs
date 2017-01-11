using System;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CM3D2_Updater {
    static class Program {
        public static String installDir;
        public static Boolean isInstalled = true;
        public static List<Content> allContent = new List<Content>();
        public static List<Content> selected = new List<Content>();
        public static List<UpdateItem> installedContent = new List<UpdateItem>();
        public static List<String> installed = new List<String>();
        public static RichTextBox console;
        public static Boolean hasVerified = false;
        public static void Log(String str) {
            console.AppendText(str+"\n");
        }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try {
                installDir = Registry.CurrentUser.OpenSubKey(@"Software\KISS\カスタムメイド3D2").GetValue("InstallPath").ToString();
#pragma warning disable CS0168 // Variable is declared but never used
            } catch (Exception e) {
#pragma warning restore CS0168 // Variable is declared but never used
                isInstalled = false;
            }
            console = new System.Windows.Forms.RichTextBox();
            Application.Run(new GUI());
        }
    }
}
