using Game.Models;
using System.IO;
using System.Xml.Serialization;

namespace Game.Services
{
    public class GameService
    {
        public const string filePath = "..\\..\\..\\Data\\Board.xml";

        public static void SaveBoard(Board board, string filePath)
        {
            var serializer = new XmlSerializer(typeof(Board));
            using var fileStream = new FileStream(filePath, FileMode.Create);
            serializer.Serialize(fileStream, board);
        }

        public static Board? LoadBoard(string filePath)
        {
            if (File.Exists(filePath))
            {
                var serializer = new XmlSerializer(typeof(Board));
                using var fileStream = new FileStream(filePath, FileMode.Open);
                return serializer.Deserialize(fileStream) as Board;
            }
            return null;
        }
    }
}
