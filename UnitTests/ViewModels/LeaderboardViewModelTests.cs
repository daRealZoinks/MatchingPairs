using Game.ViewModels;

namespace UnitTests.ViewModels
{
    [TestClass]
    public class LeaderboardViewModelTests
    {
        [TestMethod]
        public void SetLeaderboardTest()
        {
            var leaderboardViewModel = new LeaderboardViewModel();
            leaderboardViewModel.SetLeaderboard();
        }
    }
}