namespace Game.Models;

public class Board
{
    public int Width { get; set; }
    public int Height { get; set; }
    public List<Pair> Pairs { get; set; } = [];
}