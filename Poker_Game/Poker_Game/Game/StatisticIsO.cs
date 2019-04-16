using System.IO;

namespace Poker_Game.Game {
    class StatisticsIO {
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;
        private readonly string _folderPath;
        private readonly string _fileName;

        //File info
        private string _playerName;
        private int _numberOfGames;
        private int _numberOfHands;

        #region Initialization
        public StatisticsIO(string playerName) {
            _folderPath = System.Windows.Forms.Application.StartupPath + "\\Statistics\\";
            _fileName = playerName + ".stats";

            EnsureDirectoryExists(_folderPath);
            EnsureFileExists(_folderPath + _fileName, playerName);
            GetInfoFromFile(_folderPath + _fileName);
        }

        private void EnsureDirectoryExists(string folderPath) {
            FileInfo fileInfo = new FileInfo(folderPath);
            if(!fileInfo.Directory.Exists) {
                System.IO.Directory.CreateDirectory(fileInfo.DirectoryName);
            }
        }

        private void EnsureFileExists(string filePath, string playerName) {
            if(!File.Exists(filePath)) {
                _streamWriter = new StreamWriter(filePath);
                _streamWriter.WriteLine(playerName + ";" + _numberOfGames + ";" + _numberOfHands);
                _streamWriter.Dispose();
            }
        }

        // Split into more methods
        private void GetInfoFromFile(string filePath) {
            string[] info = new string[2];
            _streamReader = new StreamReader(filePath);
            string buffer = _streamReader.ReadLine();
            if(buffer != null) {
                info = buffer.Split(';');
            } else { /* Error-handling */ }
            _streamReader.Dispose();

            _playerName = info[0];
            _numberOfGames = int.Parse(info[1]);
            _numberOfHands = int.Parse(info[2]);
        } 
        #endregion

        #region Actions

        public void SaveHand(Hand hand) {
           
        }

        private void SaveRound(Round round) {

        }

        private void SaveTurn(Turn turn) {
            
        }

        #endregion



        // _streamWriter = new StreamWriter(_folderPath + _fileName);




    }
}
