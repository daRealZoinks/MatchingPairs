using Game.Models;
using Game.ViewModels;

namespace UnitTests.ViewModels
{
    [TestClass]
    public class MainContentViewModelTests
    {
        [TestMethod]
        public void MainContentViewModel_ShouldCreateTheViewModel_WhenCalledWithAUser()
        {
            var mainContentViewModel = new MainContentViewModel(new User());
            Assert.IsNotNull(mainContentViewModel);
        }
    }
}