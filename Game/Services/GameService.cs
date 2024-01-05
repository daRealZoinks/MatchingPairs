using Game.Models;
using System.IO;
using System.Xml.Serialization;

namespace Game.Services
{
	public static class GameService
	{
		private const string _filePath = "..\\..\\..\\Data\\Games.xml";

		public static List<GameObject> GetAllGames()
		{
			if (File.Exists(_filePath))
			{
				XmlSerializer serializer = new(typeof(List<GameObject>));
				using FileStream fileStream = new(_filePath, FileMode.Open);
				return serializer.Deserialize(fileStream) as List<GameObject> ?? [];
			}
			return [];
		}
		public static void SaveGame(GameObject newGame)
		{
			List<GameObject> games = GetAllGames();
			games.Add(newGame);
			SaveGames(games);
		}

		private static void SaveGames(List<GameObject> games)
		{
			XmlSerializer serializer = new(typeof(List<GameObject>));
			using FileStream fileStream = new(_filePath, FileMode.Create);
			serializer.Serialize(fileStream, games);
		}

		public static GameObject? LoadGame(User user)
		{
			//if (File.Exists(_filePath))
			//{
			//	var serializer = new XmlSerializer(typeof(GameObject));
			//	using var fileStream = new FileStream(_filePath, FileMode.Open);
			//	return serializer.Deserialize(fileStream) as GameObject;
			//}
			//return null;
			var games = GetAllGames();
			return games.Find(game => game.User.Username == user.Username);
		}

		public static GameObject? GetLastGame()
		{
			var games = GetAllGames();
			return games[0];
		}
	}
}
