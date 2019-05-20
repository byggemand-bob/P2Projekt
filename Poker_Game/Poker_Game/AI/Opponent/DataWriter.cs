using System;
using System.IO;

namespace Poker_Game.AI.Opponent {
    class DataWriter {
        private const string FolderName = "\\PlayerData\\";
        private const string FileExtension = ".dat";
        private readonly string _filePath;
        
        public DataWriter(string playerName) {
            _filePath = CreateFilePath(playerName);
            EnsureDirectoryExists(System.Windows.Forms.Application.StartupPath + FolderName);
        }

        private string CreateFilePath(string playerName) {
            return System.Windows.Forms.Application.StartupPath + FolderName + playerName + FileExtension;
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
