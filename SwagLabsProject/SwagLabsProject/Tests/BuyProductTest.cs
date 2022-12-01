using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using SwagLabsProject.Driver;
using SwagLabsProject.Pages;

namespace SwagLabsProject.Tests
{
    public class Tests
    {
        LoginPage loginPage;
        ProductPage productPage;
        CartPage cartPage;
        CheckoutPage checkoutPage;
        CheckoutOverviewPage checkoutOverviewPage;
        OrderFinishedPage orderFinishedPage;


        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();
            cartPage = new CartPage();
            checkoutPage = new CheckoutPage();
            checkoutOverviewPage = new CheckoutOverviewPage();
            orderFinishedPage = new OrderFinishedPage();

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


        [Test]
        public void TC02_SortProductsByPriceHighToLow_ShouldSortProductByPriceHighToLow()
        {
            loginPage.LoginOnPage("standard_user", "secret_sauce");
            productPage.SelectSortOption("Price (high to low)");
            Assert.That(productPage.SortByPrice.Displayed);

        }


        [Test]
        public void TC03_GoToAboutPage_ShouldRedirectToNewPage()
        {
            loginPage.LoginOnPage("standard_user", "secret_sauce");
            productPage.MenuClick.Click();
            productPage.AboutClick.Click();
            Assert.That("https://saucelabs.com/", Is.EqualTo(WebDrivers.Instance.Url));

        }

        [Test]
        public void TC04_BuyProducts_ShouldBeFinishedShopping()
        {
            loginPage.LoginOnPage("standard_user", "secret_sauce");
            productPage.AddBackpack.Click();
            productPage.AddBoltTShirt.Click();
            productPage.ShoppingCartClick.Click();

            cartPage.Checkout.Click();
            checkoutPage.FirstName.SendKeys("Vedrana");
            checkoutPage.LastName.SendKeys("Mitrovic");
            checkoutPage.ZipCode.SendKeys("11000");
            checkoutPage.ContinueButton.Submit();

            checkoutOverviewPage.FinishClick.Click();

            Assert.That("THANK YOU FOR YOUR ORDER", Is.EqualTo(orderFinishedPage.OrderFinished.Text));


        }

    }
}