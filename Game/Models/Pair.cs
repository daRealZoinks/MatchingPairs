namespace Game.Models;

public class Pair
{
    public Card Card1 { get; init; }
    public Card Card2 { get; init; }
    public bool IsMatched { get; set; } = false;
}