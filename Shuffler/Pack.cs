namespace Shuffler;

public static class Pack
{
    // This is an example of ENCAPSULATION
    // Top of pack is index 0 this is because foreach starts at index 0 to make other features added later easier.
    private static Card?[] _cards = new Card?[52];
    private static Random _random = new();

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
    /// interlaces two halves of the pack. Both shuffling methods have been created in such a way that that they allow
    /// for shuffling an incomplete pack.
    /// </summary>
    /// <param name="typeOfShuffle">int used to select shuffle type 1 = Fisher yates, 2 = Riffle 3 = None </param>
    /// <returns>Bool returns True if a valid shuffle has been selected (1-3) returns False otherwise</returns>
    public static bool ShuffleCardPack(int typeOfShuffle)
    {
        bool FisherYates()
        {
            int cardsLeft = CardsRemaining();
            if (cardsLeft > 0)
            {
                int end = _cards.Length - 1;
                int start = end + 1 - cardsLeft;
                // j reduces size of random number generated as it goes through the pack to prevent switching with
                // already shuffled cards
                int j = 0;
                for (int i = end; i > start; i--)
                {
                    Card? card1 = _cards[i];
                    int position =_random.Next(end - start - j) + start ;
                    Card? card2 = _cards[position];
                    _cards[i] = card2;
                    _cards[position] = card1;
                    j++;
                }
            }
            else
            {
                PackEmptyException();
            }
            return true;
        }
        
        // Could just create two lists to simulate the riffle but this is more resource intensive than current implementation
        bool Riffle()
        {
            int cardsLeft = CardsRemaining()-1;
            if (cardsLeft > 0)
            {
                int firstSplitStart = _cards.Length - cardsLeft;
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
            else if (CardsRemaining() == 0)
            {
                PackEmptyException();
            }
            else
            {
                throw new Exception("There is only 1 card left in the pack");
            }
            return true;
        }

        if (typeOfShuffle == 1)
        {
            return FisherYates();
        }
        if (typeOfShuffle == 2)
        {
            return Riffle();
        }
        if (typeOfShuffle == 3)
        {
            return true;
        }
        // Returns a false if a non legal integer was passed to the method
        return false;
    }

    // Shares name with other Deal method to integrate into external software as per brief document
    /// <summary>
    /// Returns the Card on the top of the pack. If pack is empty a Card{null} will be returned. Usages should be prepared
    /// for null types or should check size of pack using CardsRemaining() before using.
    /// </summary>
    /// <returns>Card or Card{null}</returns>
    public static Card? DealCard()
    {
        if (CardsRemaining() <= 0)
        {
            PackEmptyException();
        }
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

    // Shares name with other Deal method to integrate into external software as per brief document
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
        if (cardsLeft <= 0)
        {
            PackEmptyException();
        }
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
    
    // ADDITIONAL METHOD
    /// <summary>
    /// Iterates over the pack and prints all non-null Cards remaining.
    /// </summary>
    public static void OutputPack()
    {
        foreach (Card? card in Pack.Cards)
        {
            if (card != null)
            {
                Console.WriteLine(card.ToString());    
            }
        }
    }

    // ADDITIONAL METHOD
    /// <summary>
    /// Throws a general exception if the pack is empty
    /// </summary>
    /// <exception cref="Exception">There are no cards left in the pack!</exception>
    private static void PackEmptyException()
    {
        throw new Exception("There are no cards left in the pack!");
    }

    // ADDITIONAL METHOD
    /// <summary>
    /// Throws a general exception if the pack is full
    /// </summary>
    /// <exception cref="Exception">The pack is already full!</exception>
    private static void PackFullException()
    {
        throw new Exception("The pack is already full!");
    }

    // ADDITIONAL METHOD
    /// <summary>
    /// Adds a card to the top of the pack. Required because pack uses an array instead of a list
    /// </summary>
    /// <param name="card">Card - Card to be added to Pack</param>
    public static void AddCard(Card card)
    {
        for (int i = _cards.Length; i > 0; i--)
        {
            if (_cards[i] == null)
            {
                _cards[i] = card;
                return;
            }
        }
        // If there are no spaces to put the card
        PackFullException();
    }

    // ADDITIONAL METHOD
    /// <summary>
    /// Adds a list of cards to the pack with the last card in the list being placed towards the top of the pack
    /// </summary>
    /// <param name="cards">List Card - List containing cards to be added to the pack</param>
    public static void AddCard(List<Card> cards)
    {
        try
        {
            foreach (Card card in cards)
            {
                AddCard(card);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
}