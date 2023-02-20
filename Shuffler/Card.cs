namespace Shuffler;

// Card class using int to represent suit and value
// values start at 1 not 0 for both suit and value
// TODO implement string representation of suit and value.
public class Card 
{
    private int _suit;
    private int _value;

    public int Suit
    {
        get => _suit;
        //set => _suit = value;
    }

    public int Value
    {
        get => _value; 
        //set => _value = value;
    }

    public Card(int suit, int value)
    {
        _suit = suit;
        _value = value;
    }
    // TODO Would like a better way of doing this.
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
                output += "Spades";
                break;
            case 2:
                output += "Clubs";
                break;
            case 3:
                output += "Hearts";
                break;
            case 4:
                output += "Diamonds";
                break;
        }

        return output;
    }

    
}