namespace Shuffler;
public static class Testing
{
    /// <summary>
    /// Deals a number of Cards. 6 Cards are dealt, and output to the console.
    /// </summary>
    public static void TestDeal()
    {
        Player player1 = new Player("player1");
        player1.Hand.Add(Pack.Deal());
        player1.Hand.AddRange(Pack.DealCard(5));
        player1.OutputHand();
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
}