using System;
using System.IO;
using DamienG.Security.Cryptography;

namespace CM3D2_Updater {
    public class UpdateItem {
        public String path;
        public String name;
        public String cPath;
        public String expectedHash;
        public int version;
        public Boolean install;
        public UpdateItem(String dir, String mainPath) {
            String[] args = dir.Split(',');
            cPath = mainPath;
            path = args[2];
            expectedHash = args[4];
            name = path.Split('\\')[path.Split('\\').Length - 1];
            version = Int32.Parse(args[args.Length - 1]);
        }
        public Boolean verifyIntegrity() {
            Crc32 crc32 = new Crc32();
            String hash = String.Empty;
            using (FileStream fs = File.Open(cPath + "data/" + path, FileMode.Open))
                foreach (byte b in crc32.ComputeHash(fs)) hash += b.ToString("x2").ToUpper();
            return hash == expectedHash; //TODO
        }
        public void installItem(String cPath) {
            if (install) {
                String tmp = Program.installDir + @"\" + path.Replace(@"\" + path.Split('\\')[path.Split('\\').Length - 1], "");
                Program.Log("Installing " + name); //TODO
                if (File.Exists(Program.installDir + @"\" + path)) {
                    File.Delete(Program.installDir + @"\" + path);
                } else if (path != name) {
                    if (!Directory.Exists(tmp)) Directory.CreateDirectory(tmp); Directory.CreateDirectory(tmp);
                }
                String[] args = tmp.Split('\\');
                Array.Resize(ref args, args.Length - 1);
                File.Copy(cPath + @"data\" + path, Program.installDir + @"\" + path); //Wont work if directory name is too long sadly, working on a fix
            }
        }
    }
}
