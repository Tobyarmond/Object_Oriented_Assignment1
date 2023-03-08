namespace Shuffler;

// Card class using int to represent suit and value
// values start at 1 not 0 for both suit and value
public class Card 
{
    // This is an example of ENCAPSULATION
    private int _suit;
    // This is an example of ENCAPSULATION
    private int _value;

    // Interface is an example of ENCAPSULATION
    /// <summary>
    /// Interface for Card suit. Read-Only
    /// </summary>
    public int Suit
    {
        get => _suit;
    }
    // Interface is an example of ENCAPSULATION
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
    
    // ADDITIONAL METHOD
    /// <summary>
    /// Returns a string representing the card in the format value of suit. Includes suit symbol with UTF-8 character
    /// </summary>
    /// <returns>string - value of suit</returns>
    public override string ToString()
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
                output += "Spades \u2660";
                break;
            case 2:
                // Clubs
                output += "Clubs \u2663";
                break;
            case 3:
                // Hearts
                output += "Hearts \u2665";
                break;
            case 4:
                // Diamonds
                output += "Diamonds \u2666";
                break;
        }
        return output;
    }
}