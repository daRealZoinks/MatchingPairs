using Game.ViewModels;

namespace UnitTests.ViewModels
{
    [TestClass]
    public class SelectGameViewModelTests
    {
        [TestMethod]
        public void SwitchToLeaderboardTest()
        {
            var selectGameViewModel = new SelectGameViewModel();
            selectGameViewModel.SwitchToLeaderboard();
        }

        [TestMethod]
        public void GoBackTest()
        {
            var selectGameViewModel = new SelectGameViewModel();
            selectGameViewModel.GoBack();
        }

        [TestMethod]
        public void NewGameTest()
        {
            var selectGameViewModel = new SelectGameViewModel();
            selectGameViewModel.NewGame();
        }

        [TestMethod]
        public void OpenGameTest()
        {
            var selectGameViewModel = new SelectGameViewModel();
            selectGameViewModel.OpenGame();
        }
    }
}