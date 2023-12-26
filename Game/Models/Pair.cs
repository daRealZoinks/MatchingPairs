namespace Game.Models;

public class Pair(Card card1, Card card2)
{
    public Card Card1 { get; init; } = card1;
    public Card Card2 { get; init; } = card2;
    public bool IsMatched { get; set; } = false;

    public override bool Equals(object? obj)
    {
        return obj is Pair other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Card1, Card2);
    }

    private bool Equals(Pair other)
    {
        return Card1.Equals(other.Card1) && Card2.Equals(other.Card2) ||
               Card1.Equals(other.Card2) && Card2.Equals(other.Card1);
    }
}