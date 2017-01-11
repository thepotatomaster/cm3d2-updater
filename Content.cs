using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CM3D2_Updater {
    public class Content {
        public String path;
        public String name;
        public List<UpdateItem> updatelst = new List<UpdateItem>{};
        public Boolean finishedReading = false;
        public Boolean verified = false;
        public Content(String dir) {
            path = dir;
            name = path.Split('/')[path.Split('/').Length - 1];
            readUpdateList();
        }
        public async void readUpdateList() {
            StringBuilder sb = new StringBuilder();
            using (FileStream sourceStream = new FileStream(path+"update.lst",
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true)) {
                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0) {
                    String str = Encoding.UTF8.GetString(buffer, 0, numRead);
                    sb.Append(str);
                }
                foreach (var file in sb.ToString().Split('\n')) {
                    if (new Regex("0,0,.*?,.*").IsMatch(file)) updatelst.Add(new UpdateItem(file, path));
                }
                finishedReading = true;
            }
        }
        public void install() {
            foreach (var update in updatelst) update.installItem(path);
        }
        public void verifyUpdates() { //TODO: Skip update check if already exists and is up to date
            Program.Log("Verifying " + name + "'s hash:");
            foreach (var item in updatelst) {
                Program.Log("Checking " + item.name);
                if (item.verifyIntegrity()) {
                    Program.Log(item.name + "'s hash matches");
                    verified = true;
                } else {
                    Program.Log(item.name + "'s hash was not verified! Please redownload this dlc and try again");
                    verified = false;
                    break;
                }
            }
        }
    }
}
