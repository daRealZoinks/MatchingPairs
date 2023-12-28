using System.IO;

namespace Game.Services;

public class CardPicturesService
{
    private const string _path = "..\\..\\..\\Images\\Cards\\";

    public static List<string> LoadPictures()
    {
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), _path);
        return Directory.GetFiles(fullPath, "*.png").ToList();
    }
}
