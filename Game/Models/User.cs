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

		[XmlElement("Username")]
		public string Username { get; set; } 

		[XmlElement("TotalGames")]
		public int TotalGames { get; set; } 

		[XmlElement("GamesWon")]
		public int GamesWon { get; set; }

		[XmlElement("ProfilePic")]
		public string ProfilePic { get; set; }

    }

}
