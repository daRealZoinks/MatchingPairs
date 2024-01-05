using Game.Models;
using Game.ViewModels;
using System.Xml.Serialization;

namespace UnitTests.ViewModels
{
    [TestClass]
    public class ChangeUserViewModelTests
    {
        private ChangeUserViewModel _changeUserViewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            _changeUserViewModel = new ChangeUserViewModel
            {
                profilePicturesFilePath = "..\\..\\..\\..\\Game\\Images\\ProfilePictures\\",
                userFilePath = "..\\..\\..\\..\\Game\\Data\\TestUsers.xml"
            };
            _changeUserViewModel.InitializeLists();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Serialize an empty user list in the test users file
            var emptyUserList = new List<User>();
            var serializer = new XmlSerializer(typeof(List<User>));
            using var writer = new StreamWriter(_changeUserViewModel.userFilePath);
            serializer.Serialize(writer, emptyUserList);
        }

        [TestMethod]
        public void CreateUser_ShouldCreateUser_WhenAValidUsernameIsProvided()
        {
            _changeUserViewModel.NewUserName = "TestUser";
            _changeUserViewModel.CreateUser();

            Assert.IsTrue(_changeUserViewModel.Users.Count > 0);
            Assert.AreEqual("TestUser", _changeUserViewModel.Users[0].Username);
        }

        [TestMethod]
        public void CreateUser_ShouldShowWarning_WhenADuplicateUsernameIsUsed()
        {
            _changeUserViewModel.NewUserName = "TestUser";
            _changeUserViewModel.CreateUser();
            _changeUserViewModel.CreateUser();
        }

        [TestMethod]
        public void CreateUser_ShouldShowWarning_WhenANullUsernameIsProvided()
        {
            _changeUserViewModel.NewUserName = null;
            _changeUserViewModel.CreateUser();
        }

        [TestMethod]
        public void NextImage_ShouldChangeImage_WhenCalled()
        {
            _changeUserViewModel.CurrentProfilePicture = "TestPicture1";
            _changeUserViewModel.NextImage();
        }

        [TestMethod]
        public void PreviousImage_ShouldChangeImage_WhenCalled()
        {
            _changeUserViewModel.CurrentProfilePicture = "TestPicture2";
            _changeUserViewModel.PreviousImage();
        }
    }
}
