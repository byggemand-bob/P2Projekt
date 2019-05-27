using System;
using System.IO;
using System.Windows.Forms;

namespace Poker_Game.AI.Opponent {
    internal class DataReader {
        private readonly string _fileExtension;
        private readonly string _filePath;
        private readonly string _folderName;
        private readonly string _playerName;

        public DataReader(string playerName, string folderName, string fileExtension) {
            _playerName = playerName;
            _folderName = folderName;
            _fileExtension = fileExtension;
            _filePath = CreateFilePath(playerName);
        }

        private string CreateFilePath(string playerName) {
            return Application.StartupPath + _folderName + playerName + _fileExtension;
        }

        public bool HasExistingData() {
            return File.Exists(_filePath);
        }

        public OpponentData ReadData() {
            StreamReader sr = new StreamReader(_filePath);
            OpponentData result = new OpponentData(_playerName) {
                Wins =
                    int.Parse(sr.ReadLine() ?? throw new Exception("A problem occured while reading from datafile.")),
                Losses = int.Parse(sr.ReadLine() ??
                                   throw new Exception("A problem occured while reading from datafile.")),
                BigBlindHands = GetHandData(sr),
                SmallBlindHands = GetHandData(sr)
            };
            sr.Close();
            return result;
        }

        private HandData GetHandData(StreamReader sr) {
            return new HandData {
                Hands = int.Parse(
                    sr.ReadLine() ?? throw new Exception("A problem occured while reading from datafile.")),
                Folds = ParseToArray(sr.ReadLine()),
                Checks = ParseToArray(sr.ReadLine()),
                Calls = ParseToArray(sr.ReadLine()),
                Raises = ParseToArray(sr.ReadLine()),
                ReRaises = ParseToArray(sr.ReadLine())
            };
        }

        private int[] ParseToArray(string array) {
            string[] strArray = array.Split(',');
            int[] result = new int[4];
            for(int i = 0; i < strArray.Length; i++) result[i] = int.Parse(strArray[i]);

            return result;
        }
    }
}