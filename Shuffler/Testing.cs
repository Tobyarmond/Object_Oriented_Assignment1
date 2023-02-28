namespace Shuffler;
public static class Testing
{
    /// <summary>
    /// Deals a number of Cards. 6 Cards are dealt, and output to the console. Cards are lost after being dealt
    /// </summary>
    public static void TestDeal()
    {
        Card? test = Pack.Deal();
        List<Card?> testHand = Pack.DealCard(5);
        Console.WriteLine(test?.CardAsString());
        foreach (Card? c in testHand)
        {
            Console.WriteLine(c?.CardAsString());
        }
    }

    /// <summary>
    /// Performs all 3 specified shuffles and also provides an illegal value. Prints the bool value returned to the console.
    /// </summary>
    public static void TestShuffle()
    {
        Console.WriteLine(Pack.ShuffleCardPack(1));
        Console.WriteLine(Pack.ShuffleCardPack(2));
        Console.WriteLine(Pack.ShuffleCardPack(3));
        Console.WriteLine(Pack.ShuffleCardPack(4));
    }

    /// <summary>
    /// Iterates over the pack and prints all non-null Cards remaining.
    /// </summary>
    public static void OutputPack()
    {
        foreach (Card? card in Pack.Cards)
        {
            if (card != null)
            {
                Console.WriteLine(card.CardAsString());    
            }
        }
    }
}