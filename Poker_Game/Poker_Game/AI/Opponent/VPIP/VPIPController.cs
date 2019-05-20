using System;
using System.Collections.Generic;
using Poker_Game.Game;

namespace Poker_Game.AI.Opponent.VPIP {
    class VPIPController {
        public double PFR { get; private set; }
        private VPIPData _playerData;
        private double _vpip;

        private const int VPIPThreshold = 10;
        private const int VPIPStandard = 25;
        private const int PFRStandard = 25;

        public VPIPController(string playerName) {
            GetOpponent(playerName);
            PFR = PFRStandard;
            _vpip = VPIPStandard;
        }

        public void SaveData() {
            VPIPWriter writer = new VPIPWriter(_playerData.PlayerName);
            writer.WriteData(_playerData);
        }

        private void GetOpponent(string playerName) {
            DataReader reader = new DataReader(playerName);
            if(reader.HasExistingData()) {
                ExistingOpponent(reader);
            } else {
                NewOpponent(playerName);
            }
        }

        private void ExistingOpponent(DataReader reader) {
            _playerData = reader.ReadData();
            _vpip = CalculateVPIP(_playerData.NumberOfHands, _playerData.NumberCalls, _playerData.NumberRaises);
            PFR = CalculatePFR(_playerData.NumberOfHands, _playerData.NumberRaises);
        }

        private void NewOpponent(string playerName) {
            _playerData = new VPIPData(playerName, 0, 0, 0);
        }
        
        private double CalculateVPIP(int hands, int calls, int raises) {
            return ((double)hands / (calls + raises)) * 100;
        }

        private double CalculatePFR(int hands, int raises) {
            return ((double) hands / raises) * 100;
        }

        public void UpdateStats(List<Turn> turns) {
            _playerData.NumberCalls += GetNumberOf(PlayerAction.Call, turns);
            _playerData.NumberRaises += GetNumberOf(PlayerAction.Raise, turns);
            _playerData.NumberOfHands += 1;
            CalculateVPIP(_playerData.NumberOfHands, _playerData.NumberCalls, _playerData.NumberRaises);
            CalculatePFR(_playerData.NumberOfHands, _playerData.NumberRaises);
        }

        public List<string> GetRange() {
            // Should these be arrays?
            if(_playerData.NumberOfHands < VPIPThreshold) {
                return new List<string>() { "66+", "A2s+", "K6s+", "Q8s+", "J8s+", "T8s+", "A7o+", "K9o+", "QTo+", "JTo" };
            } else if(_vpip >= 75) {
                return new List<string>() { "22+", "A2s+", "K2s+", "Q2s+", "J2s+", "T2s+", "92s+", "83s+", "73s+", "63s+", "52s+", "43s", "A2o+", "K2o+", "Q2o+", "J4o+", "T6o+", "96o+", " 86o+", "75o+", "65o" };
            } else if(_vpip >= 50) {
                return new List<string>() { "33+", "A2s+", "K2s+", "Q2s+", "J4s+", "T6s+", "96s+", "86s+", "76s", "65s", "A2o+", "K5o+", "Q7o+", "J7o+", "T8o+", "98o" };
            } else if(_vpip >= 35) {
                return new List<string>() { "55+", "A2s+", "K3s+", "Q6s+", "J7s+", "T7s+", "97s+", "87s", "A4o+", "K8o+", "Q9o+", "J9o+", "T9o" };
            } else if(_vpip >= 25) {
                return new List<string>() { "66+", "A2s+", "K6s+", "Q8s+", "J8s+", "T8s+", "A7o+", "K9o+", "QTo+", "JTo" };
            } else if(_vpip >= 20) {
                return new List<string>() { "66+", "A4s+", "K8s+", "Q9s+", "J9s+", "T9s", "A9o+", "KTo+", "QTo+", "JTo" };
            } else if(_vpip >= 15) {
                return new List<string>() { "77+", "A7s+", "K9s+", "QTs+", "JTs", "ATo+", "KTo+", "QJo" };
            } else if(_vpip >= 10) {
                return new List<string>() { "88+", "A9s+", "KTs+", "QTs+", "AJo+", "KQo" };
            } else {
                return new List<string>() { "99+", "AJs+", "KQs", "AKo" };
            }
        }

        private int GetNumberOf(PlayerAction action, List<Turn> turns) {
            if(action != PlayerAction.Call && action != PlayerAction.Raise) {
                throw new ArgumentException("The action argument only supports 'PlayerAction.Call' and 'PlayerAction.Raise'.");
            }
            for(int i = turns[0].Id; i < turns.Count; i += 2) {
                if(turns[i].Action == action) {
                    return 1;
                }
            }
            return 0;
        }
    }
}
