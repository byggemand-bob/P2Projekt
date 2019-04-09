using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Poker_Game {
    class StatisticWriter {
        private StreamWriter _streamWriter;
        private string _folderPath;
        private string _fileName;

        public StatisticWriter(string playerName) {
            _folderPath = System.Windows.Forms.Application.StartupPath + "\\Statistics\\";
            EnsureDirectoryExists(_folderPath);
            _fileName = playerName + ".DeepPeer";
            _streamWriter = new StreamWriter(_folderPath + _fileName);
        }

        private void EnsureDirectoryExists(string filePath) {
            FileInfo fileInfo = new FileInfo(filePath);
            if(!fileInfo.Directory.Exists) {
                System.IO.Directory.CreateDirectory(fileInfo.DirectoryName);
            }
        }

        public void SaveHand(Hand hand) {

        }




    }
}
