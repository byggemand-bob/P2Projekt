using System;
using System.Collections.Generic;
using Poker_Game.Game;

namespace Poker_Game.AI.Opponent {
    internal class DataController {
        private const string FolderName = "\\PlayerData\\";
        private const string FileExtension = ".dat";
        private readonly string _playerName;

        public DataController(string playerName) {
            _playerName = playerName;
            PlayerData = LoadData();
        }

        public OpponentData PlayerData { get; }

        private OpponentData LoadData() {
            DataReader dr = new DataReader(_playerName, FolderName, FileExtension);
            return dr.HasExistingData() ? dr.ReadData() : new OpponentData(_playerName);
        }

        public void SaveData() {
            DataWriter dw = new DataWriter(_playerName, FolderName, FileExtension);
            dw.WriteData(PlayerData);
        }

        public void UpdateData(Hand hand) {
            if(hand.Players[0].IsSmallBlind)
                PlayerData.SmallBlindHands = UpdateHandData(PlayerData.SmallBlindHands, hand);
            else
                PlayerData.BigBlindHands = UpdateHandData(PlayerData.BigBlindHands, hand);

            // if it is not a draw
            if(hand.Winner != null) {
                if(hand.Winner.Id == hand.Players[0].Id)
                    PlayerData.Wins++;
                else
                    PlayerData.Losses++;
            }
        }

        private HandData UpdateHandData(HandData currentData, Hand hand) {
            HandData result = currentData;
            result.Hands++;
            for(int roundNumber = 0; roundNumber < hand.Rounds.Count; roundNumber++) {
                int i = hand.Players[0].IsBigBlind ? 1 : 0;
                for(; i < hand.Rounds[roundNumber].Turns.Count; i++)
                    switch(hand.Rounds[roundNumber].Turns[i].Action) {
                        case PlayerAction.Call:
                            currentData.Calls[roundNumber]++;
                            break;
                        case PlayerAction.Check:
                            currentData.Checks[roundNumber]++;
                            break;
                        case PlayerAction.Fold:
                            currentData.Folds[roundNumber]++;
                            break;
                        case PlayerAction.Raise:
                            if(IsReRaise(hand.Rounds[roundNumber].Turns, i))
                                currentData.ReRaises[roundNumber]++;
                            else
                                currentData.Raises[roundNumber]++;
                            break;
                        default:
                            throw new Exception("An illegal playerAction has been made in round " + roundNumber + ".");
                    }
            }

            return result;
        }

        private bool IsReRaise(List<Turn> turns, int currentIndex) {
            if(currentIndex == 0) return false;

            return turns[currentIndex - 1].Action == PlayerAction.Raise;
        }

        public double ToPercent(int dataValue, bool smallBlind) {
            if(smallBlind) return (double) dataValue / PlayerData.SmallBlindHands.Hands;
            return (double) dataValue / PlayerData.BigBlindHands.Hands;
        }
    }
}