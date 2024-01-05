using Game.Models;
using Game.Services;

namespace UnitTests.Services
{
    [TestClass]
    public class GameServiceTests
    {
        [TestMethod]
        public void SaveBoard_ShouldSave_WhenCalled()
        {
            var gameObject = new GameObject();
            GameService.SaveGame(gameObject, "..\\..\\..\\..\\Game\\Data\\TestGame.xml");
        }

        [TestMethod]
        public void LoadBoard_ShouldLoad_WhenCalled()
        {
            var board = GameService.GetAllGames("..\\..\\..\\..\\Game\\Data\\TestGame.xml");
            Assert.IsNotNull(board);
        }
    }
}