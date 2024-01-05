using Game.Services;

namespace UnitTests.Services
{
    [TestClass]
    public class ProfilePicturesServiceTests
    {
        [TestMethod]
        public void LoadPictures_ShouldLoadPictures_WhenCalled()
        {
            var paths = ProfilePicturesService.LoadPictures("..\\..\\..\\..\\Game\\Images\\ProfilePictures\\");
            Assert.IsNotNull(paths);
        }
    }
}