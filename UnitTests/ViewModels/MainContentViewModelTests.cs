using Game.ViewModels;

namespace UnitTests.ViewModels
{
    [TestClass]
    public class MainContentViewModelTests
    {
        [TestMethod]
        public void SwitchToUserControl2Test()
        {
            var mainContentViewModel = new MainContentViewModel();
            mainContentViewModel.SwitchToUserControl2();
        }

        [TestMethod]
        public void PlayTest()
        {
            var mainContentViewModel = new MainContentViewModel();
            mainContentViewModel.Play();
        }
    }
}