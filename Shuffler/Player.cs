namespace Shuffler;

public class Player
{
    private string _name;
    private List<Card> _hand;

    public string Name
    {
        get => _name;
    }

    public List<Card> Hand
    {
        get => _hand;
        set => _hand = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Player(string name)
    {
        _name = name;
        _hand = new List<Card>();
    }

    public void OutputHand()
    {
        foreach (Card? card in _hand)
        {
            Console.WriteLine(card.CardAsString());
        }
    }
}