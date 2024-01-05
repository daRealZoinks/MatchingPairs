using System.IO;

namespace Game.Services;

public class CardPicturesService
{
    public const string path = "..\\..\\..\\Images\\Cards\\";

    public static List<string> LoadPictures()
    {
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), path);
        return Directory.GetFiles(fullPath, "*.png").ToList();
    }
}
