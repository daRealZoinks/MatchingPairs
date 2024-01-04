using Game.Models;

namespace Game.Services.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void GetAllUsers_ShouldGetUsers_WhenCalled()
        {
            var users = UserService.GetAllUsers("..\\..\\..\\..\\Game\\Data\\TestUsers.xml"); 
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void AddUser_ShouldAddUser_WhenCalled()
        {
            var user = new User();
            UserService.AddUser(user, "..\\..\\..\\..\\Game\\Data\\TestUsers.xml");
        }

        [TestMethod]
        public void SaveUsers_ShouldSaveUsers_WhenCalled()
        {
            var users = new List<User>();
            UserService.SaveUsers(users, "..\\..\\..\\..\\Game\\Data\\TestUsers.xml");
        }
    }
}