using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.Game {
    class VPIPWriter {
        private readonly string _filePath;
        
        public VPIPWriter(string playerName) {
            _filePath = CreateFilePath(playerName);
            EnsureDirectoryExists(System.Windows.Forms.Application.StartupPath + "\\VPIPData\\");
        }

        private string CreateFilePath(string playerName) {
            return System.Windows.Forms.Application.StartupPath + "\\VPIPData\\" + playerName + ".vpip";
        }


        private void EnsureDirectoryExists(string folderPath) {
            FileInfo fileInfo = new FileInfo(folderPath);
            if(fileInfo.Directory != null && !fileInfo.Directory.Exists) {
                System.IO.Directory.CreateDirectory(fileInfo.DirectoryName);
            }
        }

        public void WriteData(VPIPData data) {
            StreamWriter sw = new StreamWriter(_filePath);
            sw.WriteLine(data.PlayerName);
            sw.WriteLine(data.NumberCalls);
            sw.WriteLine(data.NumberOfHands);
            sw.WriteLine(data.NumberRaises);
            sw.Close();
        }




    }
}
