using System.Xml.Serialization;

namespace Game.Models
{
	public class User
	{
		public User()
		{
		}

		public User(string username, int totalGames, int gamesWon, string profilePic)
		{
			Username = username;
			TotalGames = totalGames;
			GamesWon = gamesWon;
			ProfilePic = profilePic;
		}

		public string Username { get; set; } 

		public int TotalGames { get; set; } 

		public int GamesWon { get; set; }

		public string ProfilePic { get; set; }

    }

}
