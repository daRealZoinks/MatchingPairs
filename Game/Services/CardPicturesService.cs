using System.IO;

namespace Game.Services;

public class CardPicturesService
{
    public const string path = "..\\..\\..\\Images\\Cards\\";

    public static List<string> LoadPictures(string filePath)
    {
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
        return Directory.GetFiles(fullPath, "*.png").ToList();
    }
}
