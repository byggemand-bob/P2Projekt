using System.IO;

namespace Poker_Game.Game {

    // This class saves the information of the different hands played in the game
    public class StatisticsIO {
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;
        private readonly string _folderPath;
        private readonly string _fileName;
        private readonly string _filePath;

        private int _currentLineNumber;

        //File info
        private string _playerName;
        private int _numberOfGames;
        private int _numberOfHands;

        #region Initialization

        // Creates the path and path name and adding the players name for identification
        public StatisticsIO(string playerName) {
            _folderPath = System.Windows.Forms.Application.StartupPath + "\\Statistics\\";
            _fileName = playerName + ".stats";
            _filePath = _folderPath + _fileName;
            _currentLineNumber = GetCurrentLine(_filePath);

            EnsureDirectoryExists(_folderPath);
            EnsureFileExists(_folderPath + _fileName, playerName);
            GetInfoFromFile(_folderPath + _fileName);
        }

        // Finds the line where the StreamReader should read from in the code
        private int GetCurrentLine(string filePath) {
            _streamReader = new StreamReader(filePath);
            int lineCount = 0;
            while(_streamReader.ReadLine() != null) {
                lineCount++;
            }

            return lineCount;
        }

        //Checks if the FileInfo has been created
        private void EnsureDirectoryExists(string folderPath) {
            FileInfo fileInfo = new FileInfo(folderPath);
            if(!fileInfo.Directory.Exists) {
                System.IO.Directory.CreateDirectory(fileInfo.DirectoryName);
            }
        }

        // checks if the StreamWriter has the correct filePath to write to, and writes info to the file
        private void EnsureFileExists(string filePath, string playerName) {
            if(!File.Exists(filePath)) {
                _streamWriter = new StreamWriter(filePath);
                _streamWriter.WriteLine(playerName + ";" + _numberOfGames + ";" + _numberOfHands);
                _streamWriter.Close();
            }
        }

        // Work in progres - (Split into more methods) - retrieves needed info from a file path 
        private void GetInfoFromFile(string filePath) {
            string[] info = new string[2];
            _streamReader = new StreamReader(filePath);
            string buffer = _streamReader.ReadLine();
            if(buffer != null) {
                info = buffer.Split(';');
            } else { /* Error-handling */ }
            _streamReader.Close();

            _playerName = info[0];
            _numberOfGames = int.Parse(info[1]);
            _numberOfHands = int.Parse(info[2]);
        }
        #endregion

        #region Actions

        #region MyRegion

        // Work in progress

        public void SaveGame(PokerGame game) {

        }

        private void SaveHand(Hand hand) {

        }

        private void SaveRound(Round round) {

        }

        private void SaveTurn(Turn turn) {
            _streamWriter = new StreamWriter(_filePath);
            _streamWriter.WriteLine("");
        }

        #endregion

        #endregion



        // _streamWriter = new StreamWriter(_folderPath + _fileName);




    }
}
