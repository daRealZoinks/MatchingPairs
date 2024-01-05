using Game.ViewModels;

namespace UnitTests.ViewModels
{
    [TestClass]
    public class LeaderboardViewModelTests
    {
        [TestMethod]
        public void GoBackTest()
        {
            var leaderboardViewModel = new LeaderboardViewModel();
            leaderboardViewModel.GoBack();
        }

        [TestMethod]
        public void SetLeaderboardTest()
        {
            var leaderboardViewModel = new LeaderboardViewModel();
            leaderboardViewModel.SetLeaderboard();
        }
    }
}