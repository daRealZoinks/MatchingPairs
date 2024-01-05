using Game.ViewModels;

namespace UnitTests.ViewModels
{
    [TestClass]
    public class ChangeUserViewModelTests
    {
        [TestMethod]
        public void CreateUserTest()
        {
            var changeUserViewModel = new ChangeUserViewModel
            {
                profilePicturesFilePath = "..\\..\\..\\..\\Game\\Data\\TestProfilePictures.xml",
                userFilePath = "..\\..\\..\\..\\Game\\Data\\TestProfilePictures.xml"
            };
            changeUserViewModel.InitializeLists();
        }

        [TestMethod]
        public void ChangeUserTest()
        {
            var changeUserViewModel = new ChangeUserViewModel
            {
                profilePicturesFilePath = "..\\..\\..\\..\\Game\\Data\\TestProfilePictures.xml",
                userFilePath = "..\\..\\..\\..\\Game\\Data\\TestProfilePictures.xml"
            };
            changeUserViewModel.InitializeLists();

        }

        [TestMethod]
        public void NextImageTest()
        {
            var changeUserViewModel = new ChangeUserViewModel
            {
                profilePicturesFilePath = "..\\..\\..\\..\\Game\\Data\\TestProfilePictures.xml",
                userFilePath = "..\\..\\..\\..\\Game\\Data\\TestProfilePictures.xml"
            };
            changeUserViewModel.InitializeLists();

        }

        [TestMethod]
        public void PreviousImageTest()
        {
            var changeUserViewModel = new ChangeUserViewModel
            {
                profilePicturesFilePath = "..\\..\\..\\..\\Game\\Data\\TestProfilePictures.xml",
                userFilePath = "..\\..\\..\\..\\Game\\Data\\TestProfilePictures.xml"
            };
            changeUserViewModel.InitializeLists();

        }
    }
}
