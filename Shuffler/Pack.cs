namespace Shuffler;

// Top of pack is index 0 this is because foreach starts at index 0 to make other features added later easier.
public static class Pack
{
    private static Card?[] _cards = new Card?[52];
    private static Random _random = new Random();

    /// <summary>
    /// Interface for cards within the pack. Read-Only
    /// </summary>
    public static Card?[] Cards
    {
        get => _cards;
    }

    /// <summary>
    /// Pack Constructor. Automatically creates a full deck of 52 cards.
    /// </summary>
    static Pack()
    {
        int index = 0;
        for (int s = 1; s < 5; s++)
        {
            for (int v = 1; v < 14; v++)
            {
                _cards[index] = new Card(s, v);
                index++;
            }
        }
    }


    /// <summary>
    /// Counts number of cards left in the deck (ignores null positions within the deck array)
    /// </summary>
    /// <returns>int - Cards left in the deck</returns>
    public static int CardsRemaining()
    {
        return _cards.Count(card => card != null);
    }
    
    /// <summary>
    /// Shuffles the cards within the pack. Empty parts of the pack are ignored. Shuffle types are local methods. Fisher
    /// yates iterates over the pack swapping with another random card within the part not yet iterated over. Riffle
    /// interlaces two halves of the pack.
    /// </summary>
    /// <param name="shuffleType">int used to select shuffle type 1 = Fisher yates, 2 = Riffle 3 = None </param>
    /// <returns>Bool returns True if a valid shuffle has been selected (1-3) returns False otherwise</returns>
    public static bool ShuffleCardPack(int shuffleType)
    {
        bool FisherYates()
        {
            int cardsLeft = CardsRemaining();
            if (cardsLeft > 0)
            {
                int end = _cards.Length - 1;
                int start = end + 1 - cardsLeft;
                for (int i = end; i > start; i--)
                {
                    Card? card1 = _cards[i];
                    int position =_random.Next(end - start) + start;
                    Card? card2 = _cards[position];
                    _cards[i] = card2;
                    _cards[position] = card1;
                }
            }
            // Even if pack is empty this will return true because it is a legal value of shuffle requested
            return true;
        }

        // Riffle could implement random split of cards rather than being perfect?
        // Could just create two lists to simulate the riffle but this is more resource intensive than current implementation
        bool Riffle()
        {
            int cardsLeft = CardsRemaining();
            if (cardsLeft > 0)
            {
                int firstSplitStart = _cards.Length - cardsLeft - 1;
                int secondSplitStart = cardsLeft / 2 + (_cards.Length - cardsLeft);
                for (int i = 0; i < cardsLeft / 2; i++)
                {
                    Card? card1 = _cards[firstSplitStart + i];
                    Card? card2 = _cards[secondSplitStart + i];
                    _cards[firstSplitStart + i] = card2;
                    _cards[secondSplitStart + i] = card1;
                    i++;
                }
            }
            // Even if pack is empty this will return true because it is a legal value of shuffle requested
            return true;
        }

        if (shuffleType == 1)
        {
            return FisherYates();
        }
        if (shuffleType == 2)
        {
            return Riffle();
        }
        if (shuffleType == 3)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns the Card on the top of the pack. If pack is empty a Card{null} will be returned. Usages should be prepared
    /// for null types or should check size of pack using CardsRemaining() before using.
    /// </summary>
    /// <returns>Card or Card{null}</returns>
    public static Card? Deal()
    {
        for (int i = 0; i < _cards.Length; i++)
        {
            if (_cards[i] != null)
            {
                Card? dealt = _cards[i];
                // remove card from pack
                _cards[i] = null;
                return dealt;
            }
        }
        // if pack is empty
        return null;
    }

    /// <summary>
    /// Deals a number of cards from the top of the pack. If not enough cards in the pack List of Cards will contain
    /// Card{null}. Usages should be prepared for null types or should check the size of the pack using CardsRemaining()
    /// before using.
    /// </summary>
    /// <param name="amount">int - Number of cards to be dealt</param>
    /// <returns>List - Containing cards dealt</returns>
    public static List<Card?> DealCard(int amount)
    {
        // List is instantiated at size requested. If not enough cards left in pack some of list will contain null.
        List<Card?> dealt = new List<Card?>(amount);
        
        // If amount requested is larger than cards left in the pack reduce size to be dealt to number left in pack
        int cardsLeft = CardsRemaining();
        if (amount > cardsLeft)
        {
            amount = cardsLeft;
        }
        int cardsDealt = 0;
        for (int i = 0; cardsDealt <= amount; i++,cardsDealt++)
        {
            if (_cards[i] != null)
            {
                dealt.Add(_cards[i]);
                _cards[i] = null;
            }
        }
        return dealt;
    }
}