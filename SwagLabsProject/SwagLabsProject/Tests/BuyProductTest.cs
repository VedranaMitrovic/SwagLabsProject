using OpenQA.Selenium;
using SwagLabsProject.Driver;
using SwagLabsProject.Pages;

namespace SwagLabsProject.Tests
{
    public class Tests
    {
        LoginPage loginPage;
        ProductPage productPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();
        }

        [TearDown]
        public void ClosePage()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_AddTwoProductsInCart_ShouldDisplayTwoProducts()
        {
            loginPage.LoginOnPage("standard_user", "secret_sauce");
            productPage.AddBackpack.Click();
            productPage.AddBoltTShirt.Click();
            Assert.That("2", Is.EqualTo(productPage.Cart.Text));
        }
    }
}