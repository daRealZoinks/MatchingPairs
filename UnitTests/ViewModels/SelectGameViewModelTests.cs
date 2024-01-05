using Game.ViewModels;

namespace UnitTests.ViewModels
{
    [TestClass]
    public class SelectGameViewModelTests
    {
        [TestMethod]
        public void SelectGameViewModel_ShouldConstruct_WhenCalled()
        {
            var selectGameViewModel = new SelectGameViewModel();
            Assert.IsNotNull(selectGameViewModel);
        }
    }
}