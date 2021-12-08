using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelbyCompany;

namespace ShelbyCompanyTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange 
            ShelbyCompany.Environment.Init();
            var sut = new ShelbyCompany.Menu.MainMenu();

            //Act
            var result = sut.IsUserLoggedIn();

            //Assert
            Assert.IsFalse(result);
        }
    }
}
