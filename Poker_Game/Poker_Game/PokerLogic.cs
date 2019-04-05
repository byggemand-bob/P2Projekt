using System;
using System.Text;

enum Suit { None, Diamonds, Hearts, Clubs, Spades }
enum Rank {
    None, Ace, Two, Three, Four, Five, Six, Seven, Eight,
    Nine, Ten, Jack, Queen, King
}
enum Pokerscore {
    None, JacksOrBetter, TwoPair, ThreeOfAKind,
    Straight, Flush, FullHouse, FourOfAKind, StraightFlush,
    RoyalFlush
}

class Card : IComparable {
    private Rank _rank;
    private Suit _suit;

    // IComparable interface method
    public int CompareTo(object o) {
        if(o is Card) {
            Card c = (Card)o;
            if(_rank < c.Rank)
                return -1;
            else if(_rank > c.Rank)
                return 1;
            return 0;
        }
        throw new ArgumentException("Object is not a Card");
    }

    public Card(Rank rank, Suit suit) {
        this._rank = rank;
        this._suit = suit;
    }
    public Card() : this(Rank.None, Suit.None) {
    }

    public override string ToString() {
        return this._rank + " " + this._suit;
    }

    public Rank Rank {
        get { return _rank; }
    }

    public Suit Suit {
        get { return _suit; }
    }

    public bool IsJacksOrBetter() {
        if(_rank == Rank.Ace)
            return true;
        if(_rank >= Rank.Jack)
            return true;
        return false;
    }
}

class Deck {
    // array of Card of object (the real deck)
    private Card[] _d;
    // current card index
    private int _cc = 0;
    // shuffle variable
    private Random _rand = new Random();

    public Deck() {
        Init();
    }

    private void Init() {
        _cc = 0;
        _d = new Card[52];
        int counter = 0;
        // nice way to initialize the Deck, using
        // builtin functionality of Enum
        foreach(Suit s in Enum.GetValues(typeof(Suit)))
            foreach(Rank r in Enum.GetValues(typeof(Rank)))
                if(r != Rank.None && s != Suit.None)
                    _d[counter++] = new Card(r, s);
    }

    public Card PullCard() {
        return _d[_cc++];
    }

    public Card PeekCard() {
        return _d[_cc];
    }

    private void SwapCards(int i, int j) {
        Card tmp = _d[i];
        _d[i] = _d[j];
        _d[j] = tmp;
    }

    /*
	 * shuffle the deck and reset the current card
	 * index to the beginning
	 */
    public void Shuffle(int count) {
        _cc = 0;
        for(int i = 0; i < count; ++i) {
            for(int j = 0; j < 52; ++j) {
                int idx = _rand.Next(52);
                SwapCards(j, idx);
            }
        }
    }

    /*
	 * 10 is overkill, 8 should be enough
	 */
    public void Shuffle() {
        this.Shuffle(10);
    }

    public void Print() {
        foreach(Card c in _d)
            Console.WriteLine(c);
    }
}

class PokerHand {
    private Deck _deck;
    private Card[] _hand;

    public PokerHand(Deck deck) {
        this._deck = deck;
        this._hand = new Card[5];
    }

    public void PullCards() {
        for(int i = 0; i < 5; ++i)
            _hand[i] = _deck.PullCard();
    }

    public override string ToString() {
        StringBuilder sb = new StringBuilder();
        foreach(Card c in _hand) {
            sb.Append(c);
            sb.Append(", ");
        }
        return sb.ToString();
    }

    public Card this[int index] {
        get {
            return _hand[index];
        }
    }
    public void Sort() {
        Array.Sort(_hand);
    }
}

class PokerLogic {
    // flush is when all of the suits are the same
    private static bool IsFlush(PokerHand h) {
        if(h[0].Suit == h[1].Suit &&
            h[1].Suit == h[2].Suit &&
            h[2].Suit == h[3].Suit &&
            h[3].Suit == h[4].Suit)
            return true;
        return false;
    }

    // make sure the rank differs by one
    // we can do this since the Hand is 
    // sorted by this point
    private static bool IsStraight(PokerHand h) {
        if(h[0].Rank == h[1].Rank - 1 &&
            h[1].Rank == h[2].Rank - 1 &&
            h[2].Rank == h[3].Rank - 1 &&
            h[3].Rank == h[4].Rank - 1)
            return true;
        // special case cause ace ranks lower
        // than 10 or higher
        if(h[1].Rank == Rank.Ten &&
            h[2].Rank == Rank.Jack &&
            h[3].Rank == Rank.Queen &&
            h[4].Rank == Rank.King &&
            h[0].Rank == Rank.Ace)
            return true;
        return false;
    }

    // must be flush and straight and
    // be certain cards. No wonder I have
    private static bool IsRoyalFlush(PokerHand h) {
        if(IsStraight(h) && IsFlush(h) &&
              h[0].Rank == Rank.Ace &&
              h[1].Rank == Rank.Ten &&
              h[2].Rank == Rank.Jack &&
              h[3].Rank == Rank.Queen &&
              h[4].Rank == Rank.King)
            return true;
        return false;
    }

    private static bool IsStraightFlush(PokerHand h) {
        if(IsStraight(h) && IsFlush(h))
            return true;
        return false;
    }

    /*
	 * Two choices here, the first four cards
	 * must match in rank, or the second four
	 * must match in rank. Only because the hand
	 * is sorted
	 */
    private static bool IsFourOfAKind(PokerHand h) {
        if(h[0].Rank == h[1].Rank &&
            h[1].Rank == h[2].Rank &&
            h[2].Rank == h[3].Rank)
            return true;
        if(h[1].Rank == h[2].Rank &&
            h[2].Rank == h[3].Rank &&
            h[3].Rank == h[4].Rank)
            return true;
        return false;
    }

    /*
	 * two choices here, the pair is in the
	 * front of the hand or in the back of the
	 * hand, because it is sorted
	 */
    private static bool IsFullHouse(PokerHand h) {
        if(h[0].Rank == h[1].Rank &&
            h[2].Rank == h[3].Rank &&
            h[3].Rank == h[4].Rank)
            return true;
        if(h[0].Rank == h[1].Rank &&
            h[1].Rank == h[2].Rank &&
            h[3].Rank == h[4].Rank)
            return true;
        return false;
    }

    /*
	 * three choices here, first three cards match
	 * middle three cards match or last three cards
	 * match
	 */
    private static bool IsThreeOfAKind(PokerHand h) {
        if(h[0].Rank == h[1].Rank &&
            h[1].Rank == h[2].Rank)
            return true;
        if(h[1].Rank == h[2].Rank &&
            h[2].Rank == h[3].Rank)
            return true;
        if(h[2].Rank == h[3].Rank &&
            h[3].Rank == h[4].Rank)
            return true;
        return false;
    }

    /*
	 * three choices, two pair in the front,
	 * separated by a single card or
	 * two pair in the back
	 */
    private static bool IsTwoPair(PokerHand h) {
        if(h[0].Rank == h[1].Rank &&
            h[2].Rank == h[3].Rank)
            return true;
        if(h[0].Rank == h[1].Rank &&
            h[3].Rank == h[4].Rank)
            return true;
        if(h[1].Rank == h[2].Rank &&
            h[3].Rank == h[4].Rank)
            return true;
        return false;
    }

    /*
	 * 4 choices here
	 */
    private static bool IsJacksOrBetter(PokerHand h) {
        if(h[0].Rank == h[1].Rank &&
            h[0].IsJacksOrBetter())
            return true;
        if(h[1].Rank == h[2].Rank &&
            h[1].IsJacksOrBetter())
            return true;
        if(h[2].Rank == h[3].Rank &&
            h[2].IsJacksOrBetter())
            return true;
        if(h[3].Rank == h[4].Rank &&
            h[3].IsJacksOrBetter())
            return true;
        return false;
    }

    // must be in order of hands and must be
    // mutually exclusive choices
    public static Pokerscore Score(PokerHand h) {
        if(IsRoyalFlush(h))
            return Pokerscore.RoyalFlush;
        else if(IsStraightFlush(h))
            return Pokerscore.StraightFlush;
        else if(IsFourOfAKind(h))
            return Pokerscore.FourOfAKind;
        else if(IsFullHouse(h))
            return Pokerscore.FullHouse;
        else if(IsFlush(h))
            return Pokerscore.Flush;
        else if(IsStraight(h))
            return Pokerscore.Straight;
        else if(IsThreeOfAKind(h))
            return Pokerscore.ThreeOfAKind;
        else if(IsTwoPair(h))
            return Pokerscore.TwoPair;
        else if(IsJacksOrBetter(h))
            return Pokerscore.JacksOrBetter;
        else
            return Pokerscore.None;
    }
}

class Stats {
    private int _simCount;

    private int[] _counts = new int[Enum.GetValues(typeof(Pokerscore)).Length];

    public void Report() {
        Console.WriteLine("{0,10}\t{1,10}\t{2,10}",
                "Hand", "Count", "Percent");
        for(int i = 0; i < _counts.Length; ++i) {
            Console.WriteLine("{0,-10}\t{1,10}\t{2,10:p4}",
                    Enum.GetName(typeof(Pokerscore), i),
                    _counts[i],
                    _counts[i] / (double)_simCount);
        }
        Console.WriteLine("{0,10}\t{1,10}", "Total Hands", _simCount);
    }

    public void Append(Pokerscore ps) {
        _counts[(int)ps]++;
    }

    public void Reset() {
        for(int i = 0; i < _counts.Length; ++i)
            _counts[i] = 0;
    }

    public Stats() {
        Reset();
    }
    public int SimCount {
        set { _simCount = value; }
        get { return _simCount; }
    }
}

public class PokerApp {
    public static void Main(string[] args) {
        int simCount = 5000;
        if(args.Length == 1)
            simCount = int.Parse(args[0]);

        Deck d = new Deck();
        PokerHand hand = new PokerHand(d);

        Stats stats = new Stats();
        stats.SimCount = simCount;
        for(int i = 0; i < simCount; i++) {
            // worry counter
            if((i % 1000) == 0)
                Console.Write("*");
            d.Shuffle();
            hand.PullCards();
            hand.Sort();
            Pokerscore ps = PokerLogic.Score(hand);
            stats.Append(ps);
        }
        Console.WriteLine();
        stats.Report();
    }
}
