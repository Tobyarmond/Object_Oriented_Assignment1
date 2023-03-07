namespace Shuffler;

// This is an additional class used to represent a player. Holds a hand containing dealt cards
public class Player
{
    // This is an example of  encapsulation
    private string _name;
    // This is an example of encapsulation
    private List<Card> _hand;

    // Interface for Name
    public string Name
    {
        get => _name;
    }

    // Interface for Hand
    public List<Card> Hand
    {
        get => _hand;
        set => _hand = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>
    /// Constructor for Player
    /// </summary>
    /// <param name="name">string - Name of player</param>
    public Player(string name)
    {
        _name = name;
        _hand = new List<Card>();
    }

    /// <summary>
    /// Outputs all cards within the players Hand to Console.
    /// </summary>
    public void OutputHand()
    {
        foreach (Card? card in _hand)
        {
            Console.WriteLine(card.ToString());
        }
    }
}