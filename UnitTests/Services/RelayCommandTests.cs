namespace UnitTests.Services
{
    [TestClass]
    public class RelayCommandTests
    {
        private bool _canExecute;
        private bool _isExecuted;

        [TestInitialize]
        public void TestInitialize()
        {
            _canExecute = false;
            _isExecuted = false;
        }

        [TestMethod]
        public void CanExecute_ReturnsCorrectValue()
        {
            var command = new RelayCommand(() => _isExecuted = true, () => _canExecute);
            var result = command.CanExecute(null);
            Assert.AreEqual(_canExecute, result);
        }

        [TestMethod]
        public void Execute_CallsAction()
        {
            var command = new RelayCommand(() => _isExecuted = true, () => _canExecute);
            command.Execute(null);
            Assert.IsTrue(_isExecuted);
        }
    }
}
