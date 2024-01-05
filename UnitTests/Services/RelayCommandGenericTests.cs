namespace UnitTests.Services
{
    [TestClass]
    public class RelayCommandGenericTests
    {
        private bool _canExecute;
        private bool _isExecuted;
        private string _parameter;

        [TestInitialize]
        public void TestInitialize()
        {
            _canExecute = false;
            _isExecuted = false;
            _parameter = "Test";
        }

        [TestMethod]
        public void CanExecute_ReturnsCorrectValue()
        {
            var command = new RelayCommand<string>(param => _isExecuted = true, param => _canExecute);
            var result = command.CanExecute(_parameter);
            Assert.AreEqual(_canExecute, result);
        }

        [TestMethod]
        public void Execute_CallsAction()
        {
            var command = new RelayCommand<string>(param => _isExecuted = true, param => _canExecute);
            command.Execute(_parameter);
            Assert.IsTrue(_isExecuted);
        }
    }
}
