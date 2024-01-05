using System.IO;

namespace Game.Services
{
	public static class ProfilePicturesService
	{
		public const string path = "..\\..\\..\\Images\\ProfilePictures\\";

		public static List<string> LoadPictures(string path)
		{
			string fullPath = Path.Combine(Directory.GetCurrentDirectory(), path);
			return Directory.GetFiles(fullPath, "*.jpg").ToList();
		}
	}
}
