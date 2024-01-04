using Game.Models;
using System.IO;
using System.Xml.Serialization;

namespace Game.Services
{
    public class GameService
    {
        private const string _filePath = "..\\..\\..\\Data\\Board.xml";

        public static void SaveBoard(Board board)
        {
            var serializer = new XmlSerializer(typeof(Board));
            using var fileStream = new FileStream(_filePath, FileMode.Create);
            serializer.Serialize(fileStream, board);
        }

        public static Board? LoadBoard()
        {
            if (File.Exists(_filePath))
            {
                var serializer = new XmlSerializer(typeof(Board));
                using var fileStream = new FileStream(_filePath, FileMode.Open);
                return serializer.Deserialize(fileStream) as Board;
            }
            return null;
        }
    }
}
