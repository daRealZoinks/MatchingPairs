using Game.Models;
using System.IO;
using System.Xml.Serialization;

namespace Game.Services;

public static class UserService
{
	private const string _filePath = "..\\..\\..\\Data\\Users.xml"; 

	public static List<User> GetAllUsers()
	{
		if (File.Exists(_filePath))
		{
			XmlSerializer serializer = new(typeof(List<User>));
			using FileStream fileStream = new(_filePath, FileMode.Open);
			return serializer.Deserialize(fileStream) as List<User> ?? [];
		}
		return [];
	}

	public static void AddUser(User newUser)
	{
		List<User> users = GetAllUsers();
		users.Add(newUser);
		SaveUsers(users);
	}

	private static void SaveUsers(List<User> users)
	{
		XmlSerializer serializer = new(typeof(List<User>));
		using FileStream fileStream = new(_filePath, FileMode.Create);
		serializer.Serialize(fileStream, users);
	}

}
