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
            var board = new Board();
            GameService.SaveBoard(board, "..\\..\\..\\..\\Game\\Data\\TestBoard.xml");
        }

        [TestMethod]
        public void LoadBoard_ShouldLoad_WhenCalled()
        {
            var board = GameService.LoadBoard("..\\..\\..\\..\\Game\\Data\\TestBoard.xml");
            Assert.IsNotNull(board);
        }
    }
}