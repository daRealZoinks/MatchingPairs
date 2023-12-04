using System.IO;

namespace Game.Services
{
	public static class ProfilePicturesService
	{
		private const string _path = "..\\..\\..\\Images\\ProfilePictures\\";

		public static List<string> LoadPictures()
		{
			string fullPath = Path.Combine(Directory.GetCurrentDirectory(), _path);
			return Directory.GetFiles(fullPath, "*.jpg").ToList();
		}
	}
}
