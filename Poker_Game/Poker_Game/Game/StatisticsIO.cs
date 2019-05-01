using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

/*
 * Potsize, player bets(preflop, flop, turn, river), player action, cards, player stack, om spiller sidder small eller big
 * 
 */


namespace Poker_Game.Game {

    // This class saves the information of the different hands played in the game
    class StatisticsIO {
        private readonly string _fileName;
        private readonly string _filePath;

        private int _currentLineNumber;

        // File info
        private string _playerName;
        private int _numberOfGames;
        private int _numberOfHands;

        // Information separators
        private const char RankSuitSeparator = '-';
        private const char CardSeparator = '|';
        private const char DataSeparator = ',';

        // 
        private List<string> doucment;


        #region Initialization

        // Creates the path and path name and adding the players name for identification
        public StatisticsIO(PokerGame game) {
            string folderPath = System.Windows.Forms.Application.StartupPath + "\\Statistics\\";
            _fileName = game.Settings.PlayerName + ".stats";
            _filePath = folderPath + _fileName;
            _numberOfHands = 0;
            _numberOfHands = 0;
            
            EnsureDirectoryExists(folderPath);
            EnsureFileExists(folderPath + _fileName, game.Settings.PlayerName);
            GetInfoFromFile(folderPath + _fileName);
            _currentLineNumber = GetCurrentLine(_filePath);
        }

        // Finds the line where the StreamReader should read from in the code
        private int GetCurrentLine(string filePath) {
            StreamReader sr = new StreamReader(filePath);
            int lineCount = 0;
            while(sr.ReadLine() != null) {
                lineCount++;
            }
            sr.Close();

            return lineCount;
        }

        //Checks if the FileInfo has been created
        private void EnsureDirectoryExists(string folderPath) {
            FileInfo fileInfo = new FileInfo(folderPath);
            if(fileInfo.Directory != null && !fileInfo.Directory.Exists) {
                System.IO.Directory.CreateDirectory(fileInfo.DirectoryName);
            }
        }

        // checks if the StreamWriter has the correct filePath to write to, and writes info to the file
        private void EnsureFileExists(string filePath, string playerName) {
            if(!File.Exists(filePath)) {
                StreamWriter sw = new StreamWriter(filePath);
                sw.WriteLine(playerName + DataSeparator + 
                                        _numberOfGames + DataSeparator + 
                                        _numberOfHands);
                sw.Close();
            }
        }

        // Work in progress - (Split into more methods) - retrieves needed info from a file path 
        private void GetInfoFromFile(string filePath) {
            StreamReader sr = new StreamReader(filePath);

            string buffer = sr.ReadLine();
            if(buffer != null) {
                string[] info = buffer.Split(DataSeparator);
                _playerName = info[0];
                _numberOfGames = int.Parse(info[1]);
                _numberOfHands = int.Parse(info[2]);
            } else { /* Error-handling */ }
            sr.Close();
        }
        #endregion

        #region Saving

        // Work in progress

        public void SaveGame(PokerGame game) {
            foreach(Hand hand in game.Hands) {
                SaveHand(hand);
            }
        }

        private void SaveHand(Hand hand) {

            foreach(Round round in hand.Rounds) {
                SaveRound(round);
            }

        }

        private void SaveRound(Round round) {

            foreach(Turn turn in round.Turns) {
                SaveTurn(turn);
            }

        }

        private string SaveCardHand(List<Card> cardHand) {
            return SaveCard(cardHand[0]) + CardSeparator + SaveCard(cardHand[1]);
        }

        private string SaveCard(Card card) {
            return ((int) card.Rank).ToString() + RankSuitSeparator + ((int) card.Suit).ToString();
        }

        public void SaveTurn(Turn turn) {
            StreamWriter sw = new StreamWriter(_filePath);
            /* StringBuilder? */
            ;
            sw.WriteLine(((int)turn.Action).ToString() + DataSeparator + 
                                    turn.Bet + DataSeparator + 
                                    turn.Id + DataSeparator + 
                                    turn.PotSize + DataSeparator +
                                    turn.Stack);
            sw.Close();
        }

        #endregion


        // _streamWriter = new StreamWriter(_folderPath + _fileName);




    }
}
