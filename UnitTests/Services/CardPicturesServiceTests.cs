using Game.Services;

namespace UnitTests.Services
{
    [TestClass]
    public class CardPicturesServiceTests
    {
        [TestMethod]
        public void LoadPictures_ShouldReturnFilePaths_WhenCalled()
        {
            var paths = CardPicturesService.LoadPictures("..\\..\\..\\..\\Game\\Images\\Cards\\");
            Assert.IsNotNull(paths);
        }
    }
}