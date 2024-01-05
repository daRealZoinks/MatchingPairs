using Game.Models;
using System.IO;
using System.Xml.Serialization;

namespace Game.Services;

public static class UserService
{
	public const string filePath = "..\\..\\..\\Data\\Users.xml";

	public static List<User> GetAllUsers(string filePath)
	{
		if (File.Exists(filePath))
		{
			XmlSerializer serializer = new(typeof(List<User>));
			using FileStream fileStream = new(filePath, FileMode.Open);
			return serializer.Deserialize(fileStream) as List<User> ?? [];
		}
		return [];
	}

	public static void AddUser(User newUser, string filePath)
	{
		List<User> users = GetAllUsers(filePath);
		users.Add(newUser);
		SaveUsers(users, filePath);
	}

	public static void SaveUsers(List<User> users, string filePath)
	{
		XmlSerializer serializer = new(typeof(List<User>));
		using FileStream fileStream = new(filePath, FileMode.Create);
		serializer.Serialize(fileStream, users);
	}

}
