using Game.ViewModels;

namespace UnitTests.ViewModels
{
    [TestClass]
    public class GameViewModelTests
    {
        [TestMethod]
        public void GameViewModel_ShouldConstruct_WhenCalled()
        {
            var gameViewModel = new GameViewModel();
            Assert.IsNotNull(gameViewModel);
        }
    }
}