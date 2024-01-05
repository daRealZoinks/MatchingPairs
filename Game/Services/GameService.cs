using Game.Models;
using System.IO;
using System.Xml.Serialization;

namespace Game.Services
{
    public static class GameService
    {
        public const string filePath = "..\\..\\..\\Data\\Games.xml";

        public static List<GameObject> GetAllGames(string filePath)
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new(typeof(List<GameObject>));
                using FileStream fileStream = new(filePath, FileMode.Open);
                return serializer.Deserialize(fileStream) as List<GameObject> ?? [];
            }
            return [];
        }
        public static void SaveGame(GameObject newGame, string filePath)
        {
            List<GameObject> games = GetAllGames(filePath);
            games.Add(newGame);
            SaveGames(games, filePath);
        }

        private static void SaveGames(List<GameObject> games, string filePath)
        {
            XmlSerializer serializer = new(typeof(List<GameObject>));
            using FileStream fileStream = new(filePath, FileMode.Create);
            serializer.Serialize(fileStream, games);
        }

        public static GameObject? LoadGame(User user, string filePath)
        {
            //if (File.Exists(_filePath))
            //{
            //	var serializer = new XmlSerializer(typeof(GameObject));
            //	using var fileStream = new FileStream(_filePath, FileMode.Open);
            //	return serializer.Deserialize(fileStream) as GameObject;
            //}
            //return null;
            var games = GetAllGames(filePath);
            return games.Find(game => game.User.Username == user.Username);
        }

        public static GameObject? GetLastGame(string filePath)
        {
            var games = GetAllGames(filePath);
			return games.Last();
		}
	}
}
