using System;
using System.Collections.Generic;
using System.Linq;
using Poker_Game.Game;

namespace Poker_Game.AI.Opponent {
    class RangeParser {

        private readonly List<Suit> _suits = new List<Suit> {
            Suit.Clubs,
            Suit.Diamonds,
            Suit.Hearts,
            Suit.Spades
        };

        public List<List<Card>> Parse(List<string> range) {
            List<List<Card>> result = new List<List<Card>>();

            foreach(string part in range) {
                result.AddRange(ParsePart(part));
            }

            return DeleteDuplicates(result);
        }

        private List<List<Card>> ParsePart(string part) {
            if(part[0] == part[1]) {
                return CreatePairs(CharToRank(part[0]));
            }

            List<List<Card>> result = new List<List<Card>>();
            bool suited = part.Contains('s'),
                 offsuit = part.Contains('o'),
                 allAbove = part.Contains('+');

            if(allAbove && suited) {
                result.AddRange(MakeAllSuited(CharToRank(part[0]), CharToRank(part[1])));
            } else if(allAbove && offsuit) {
                result.AddRange(MakeAllOffsuit(CharToRank(part[0]), CharToRank(part[1])));
            } else if(suited) {
                result.AddRange(MakeSuited(CharToRank(part[0]), CharToRank(part[1])));
            } else if(offsuit) {
                result.AddRange(MakeOffsuit(CharToRank(part[0]), CharToRank(part[1])));
            } else {
                throw new Exception("Something went wrong...");
            }

            return result;
        }

        private Rank CharToRank(char c) {
            if(Char.IsDigit(c)) {
                return (Rank)Int32.Parse((c.ToString()));
            }

            switch(c) {
                case 'T':
                    return (Rank)10;
                case 'J':
                    return Rank.Jack;
                case 'Q':
                    return Rank.Queen;
                case 'K':
                    return Rank.King;
                case 'A':
                    return Rank.Ace;
                default:
                    return 0;
            }
        }

        private List<List<Card>> CreatePairs(Rank lower) {
            List<List<Card>> result = new List<List<Card>>();

            for(Rank r = lower; r <= Rank.Ace; r++) {
                foreach(Suit suit in _suits) {
                    result.Add(MakeCardHand(r, r, suit));
                }
            }

            return result;
        }

        private List<List<Card>> MakeAllSuited(Rank lower1, Rank lower2) {
            List<List<Card>> result = new List<List<Card>>();

            for(Rank r1 = lower1; r1 <= Rank.Ace; r1++) {
                for(Rank r2 = lower2; r2 <= Rank.Ace; r2++) {
                    if(r1 != r2) {
                        result.AddRange(MakeSuited(r1, r2)); 
                    }
                }
            }

            return result;
        }

        private List<List<Card>> MakeSuited(Rank rank1, Rank rank2) {
            List<List<Card>> result = new List<List<Card>>();

            foreach(Suit suit in _suits) {
                result.Add(MakeCardHand(rank1, rank2, suit));
            }

            return result;
        }

        private List<List<Card>> MakeAllOffsuit(Rank lower1, Rank lower2) {
            List<List<Card>> result = new List<List<Card>>();

            for(Rank r1 = lower1; r1 <= Rank.Ace; r1++) {
                for(Rank r2 = lower2; r2 <= Rank.Ace; r2++) {
                    if(r1 != r2) {
                        result.AddRange(MakeOffsuit(r1, r2)); 
                    }
                }
            }

            return result;
        }

        private List<List<Card>> MakeOffsuit(Rank rank1, Rank rank2) {
            List<List<Card>> result = new List<List<Card>>();

            foreach(Suit s1 in _suits) {
                foreach(Suit s2 in _suits) {
                    if(s1 != s2) {
                        result.Add(MakeCardHand(rank1, rank2, s1, s2));
                    }
                }
            }

            return result;
        }

        private List<Card> MakeCardHand(Rank rank1, Rank rank2, Suit suit1, Suit suit2) {
            return new List<Card> {
                new Card(suit1, rank1),
                new Card(suit2, rank2)
            };
        }

        private List<Card> MakeCardHand(Rank rank1, Rank rank2, Suit suit) {
            return new List<Card> {
                new Card(suit, rank1),
                new Card(suit, rank2)
            };
        }

        private List<List<Card>> DeleteDuplicates(List<List<Card>> list) {
            List<List<Card>> result = new List<List<Card>>(list);

            for(int i = 0; i < result.Count; i++) {
                for(int j = i + 1; j < result.Count; j++) {
                    if(CompareCardhand(result[0], result[1])) {
                        result.RemoveAt(j);
                    }
                }
            }

            return result;
        }

        private bool CompareCardhand(List<Card> cards1, List<Card> cards2) {
            return cards1[0].Equals(cards2[0]) && cards1[1].Equals(cards2[1]);
        }

    }
}
