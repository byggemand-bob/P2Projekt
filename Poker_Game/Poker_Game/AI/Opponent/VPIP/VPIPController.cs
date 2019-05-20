using System.Collections.Generic;
using Poker_Game.Game;

namespace Poker_Game.AI.Opponent.VPIP {
    class VPIPController {
        private double _pfr;
        private double _vpip;
        private OpponentData _playerData;

        private const int VPIPThreshold = 10;
        private const int VPIPStandard = 25;
        private const int PFRStandard = 25;

        public VPIPController(OpponentData playerData) {
            _playerData = playerData;
            _pfr = PFRStandard;
            _vpip = VPIPStandard;
        }

        private double CalculateVPIP(int hands, int preFlopRCalls, int preFlopRaises) {
            return ((double)hands / (preFlopRCalls + preFlopRaises)) * 100;
        }

        private double CalculatePFR(int hands, int preFlopRaises) {
            return ((double) hands / preFlopRaises) * 100;
        }

        private void Update() {
            int raises = _playerData.BigBlindHands.Raises[0] + _playerData.SmallBlindHands.Raises[0];
            int calls = _playerData.BigBlindHands.Calls[0] + _playerData.SmallBlindHands.Calls[0];

            _pfr = CalculatePFR(_playerData.Hands, raises);
            _vpip = CalculateVPIP(_playerData.Hands, calls, raises);
        }

        public List<List<Card>> GetRange() {
            RangeParser rp = new RangeParser();
            return rp.Parse(FindRange());
        }

        private List<string> FindRange() {
            // Should these be arrays?
            if(_playerData.Hands >= VPIPThreshold) {
                Update();
            }
            if(_vpip >= 75) {
                return new List<string> { "22+", "A2s+", "K2s+", "Q2s+", "J2s+", "T2s+", "92s+", "83s+", "73s+", "63s+", "52s+", "43s", "A2o+", "K2o+", "Q2o+", "J4o+", "T6o+", "96o+", " 86o+", "75o+", "65o" };
            }
            if(_vpip >= 50) {
                return new List<string> { "33+", "A2s+", "K2s+", "Q2s+", "J4s+", "T6s+", "96s+", "86s+", "76s", "65s", "A2o+", "K5o+", "Q7o+", "J7o+", "T8o+", "98o" };
            }
            if(_vpip >= 35) {
                return new List<string> { "55+", "A2s+", "K3s+", "Q6s+", "J7s+", "T7s+", "97s+", "87s", "A4o+", "K8o+", "Q9o+", "J9o+", "T9o" };
            }
            if(_vpip >= 25) {
                return new List<string> { "66+", "A2s+", "K6s+", "Q8s+", "J8s+", "T8s+", "A7o+", "K9o+", "QTo+", "JTo" };
            }
            if(_vpip >= 20) {
                return new List<string> { "66+", "A4s+", "K8s+", "Q9s+", "J9s+", "T9s", "A9o+", "KTo+", "QTo+", "JTo" };
            }
            if(_vpip >= 15) {
                return new List<string> { "77+", "A7s+", "K9s+", "QTs+", "JTs", "ATo+", "KTo+", "QJo" };
            }
            if(_vpip >= 10) {
                return new List<string> { "88+", "A9s+", "KTs+", "QTs+", "AJo+", "KQo" };
            }
            return new List<string> { "99+", "AJs+", "KQs", "AKo" };
        }

       
    }
}
