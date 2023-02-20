namespace Shuffler;

// Top of pack is index 0 this is because foreach starts at index 0 to make other features added later easier.
public static class Pack
{
    private static Card?[] _cards = new Card?[52];
    // Is it a good idea to have an instance of Random attached to the class?
    private static Random _random = new Random();

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

    public static Card?[] Cards
    {
        get => _cards;
    }

    // Cards remaining made public as may be useful for other classes to access.
    public static int CardsRemaining()
    {
        return _cards.Count(s => s != null);
    }
    
    // Spec asks for return value to be a bool.
    // Bool return true has been used to symbolise that the int handed to method was a legal value. 
    public static bool ShuffleCardPack(int shuffleType)
    {
        bool FisherYates()
        {
            // Could be made a static value as a pack of cards is 52 cards. But left dynamic for possible future changes.
            int end = _cards.Length - 1;
            int cardsLeft = CardsRemaining();
            // Not sure about this indexing?
            int start = end + 1 - cardsLeft;
            for (int i = end; i > start; i--)
            {
                //int randomIndex = _random.Next(cardsLeft) 
                Card? card1 = _cards[i];
                // BUG I think this needs to be shifted to stop empty parts of the pack being shuffled?
                int position =_random.Next(end - start);
                Card? card2 = _cards[position];
                _cards[i] = card2;
                _cards[position] = card1;
                // TODO Don't think I need this line
                //start++;
            }
            return true;
        }

        // Riffle could implement random slices of cards rather than being perfect?
        // Riffle should actually cut the pack then intersect. 
        bool Riffle()
        {
            int cardsLeft = CardsRemaining();
            // Not sure about indexing again?
            int end = _cards.Length -1;
            int start = end - cardsLeft;
            // i+2 not allowed could use i++ twice?
            for (int i = start; i < end; i++)
            {
                Card? card1 = _cards[i];
                Card? card2 = _cards[i + 1];
                _cards[i] = card2;
                _cards[i + 1] = card1;
                i++;
            }
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

    // TODO need to make all usages ready for possible null reference return
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

    // TODO hand dealt has possible null references within it. all usages should be prepared for null types
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
        // TODO not sure about this condition?
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