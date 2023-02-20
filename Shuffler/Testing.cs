namespace Shuffler;
using System.Linq;
public static class Testing
{
    public static void TestDeal()
    {
        Card? test = Pack.Deal();
        List<Card?> testHand = Pack.DealCard(5);
    }

    public static void TestShuffle()
    {
        Console.WriteLine(Pack.ShuffleCardPack(1));
        Console.WriteLine(Pack.ShuffleCardPack(2));
        Console.WriteLine(Pack.ShuffleCardPack(3));
        Console.WriteLine(Pack.ShuffleCardPack(4));
    }

    public static void OutputPack()
    {
        foreach (Card card in Pack.Cards)
        {
            if (card != null)
            {
                Console.WriteLine(card.CardAsString());    
            }
        }
    }
}