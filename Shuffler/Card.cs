namespace Shuffler;

// Card class using int to represent suit and value
// values start at 1 not 0 for both suit and value
public class Card 
{
    private int _suit;
    private int _value;

    /// <summary>
    /// Interface for Card suit. Read-Only
    /// </summary>
    public int Suit
    {
        get => _suit;
    }
    /// <summary>
    /// Interface for Card value. Read-Only
    /// </summary>
    public int Value
    {
        get => _value;
    }

    /// <summary>
    /// Card constructor
    /// </summary>
    /// <param name="suit">int - integer value representing suit. 1 = Spades, 2 = Clubs, 3 = Hearts, 4 =  Diamonds</param>
    /// <param name="value">int - integer value representing Card value. 1 = Ace, 2-10 = Number, 11 = Jack, 12 = Queen,
    /// 13 = King</param>
    public Card(int suit, int value)
    {
        _suit = suit;
        _value = value;
    }
    /// <summary>
    /// Returns a string representing the card in the format value of suit 
    /// </summary>
    /// <returns>string - value of suit</returns>
    // TODO Would like a better way of doing this. Could override .asString method?
    public string CardAsString()
    {
        string output = "";
        switch (_value)
        {
            case 1:
                output += "Ace";
                break;
            case 2:
                output += "Two";
                break;
            case 3:
                output += "Three";
                break;
            case 4:
                output += "Four";
                break;
            case 5:
                output += "Five";
                break;
            case 6:
                output += "Six";
                break;
            case 7:
                output += "Seven";
                break;
            case 8:
                output += "Eight";
                break;
            case 9:
                output += "Nine";
                break;
            case 10:
                output += "Ten";
                break;
            case 11:
                output += "Jack";
                break;
            case 12:
                output += "Queen";
                break;
            case 13:
                output += "King";
                break;
        }

        output += " of ";

        switch (_suit)
        {
            case 1:
                // Spades
                output += "\u2660";
                break;
            case 2:
                // Clubs
                output += "\u2663";
                break;
            case 3:
                // Hearts
                output += "\u2665";
                break;
            case 4:
                // Diamonds
                output += "\u2666";
                break;
        }

        return output;
    }

    
}