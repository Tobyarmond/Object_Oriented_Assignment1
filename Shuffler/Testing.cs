namespace Shuffler;
public static class Testing
{
    /// <summary>
    /// Deals a number of Cards. Cards are dealt, and output to the console.
    /// </summary>
    /// <param name="numberToDeal">int - Number of cards to deal from the DealCard method</param>
    public static void TestDeal(int numberToDeal)
    {
        // OBJECT INSTANTIATION
        Player player1 = new Player("player1");
        // Try block to catch any empty pack exceptions thrown
        try
        {
            player1.Hand.Add(Pack.Deal());
            player1.Hand.AddRange(Pack.DealCard(numberToDeal));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        player1.OutputHand();
    }

    /// <summary>
    /// Performs all 3 specified shuffles and also provides an illegal value. Prints the bool value returned to the console.
    /// </summary>
    public static void TestShuffle()
    {
        // This is an ABSTRACTION. By using the shuffleCardPack method the inner workings of the different shuffles are
        // hidden from the user.
        // Try block to catch any empty pack exceptions thrown
        try
        {
            Console.WriteLine(Pack.ShuffleCardPack(1));
            Console.WriteLine(Pack.ShuffleCardPack(2));
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        Console.WriteLine(Pack.ShuffleCardPack(3));
        Console.WriteLine(Pack.ShuffleCardPack(4));
    }
}