using System;
using System.IO;

namespace Poker_Game.AI.Opponent {
    class DataWriter {
        private readonly string _folderName;
        private readonly string _fileExtension;
        private readonly string _filePath;
        
        public DataWriter(string playerName, string folderName, string fileExtension) {
            _folderName = folderName;
            _fileExtension = fileExtension;
            _filePath = CreateFilePath(playerName);
            EnsureDirectoryExists(System.Windows.Forms.Application.StartupPath + _folderName);
        }

        private string CreateFilePath(string playerName) {
            return System.Windows.Forms.Application.StartupPath + _folderName + playerName + _fileExtension;
        }


        private void EnsureDirectoryExists(string folderPath) {
            FileInfo fileInfo = new FileInfo(folderPath);
            if(fileInfo.Directory != null && !fileInfo.Directory.Exists) {
                Directory.CreateDirectory(fileInfo.DirectoryName ?? throw new Exception("A problem occured while creating directory."));
            }
        }

        public void WriteData(OpponentData data) {
            StreamWriter sw = new StreamWriter(_filePath);
            sw.Write(data.ToString());
            sw.Close();
        }

    }
}
