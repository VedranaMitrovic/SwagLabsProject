using OpenQA.Selenium;
using SwagLabsProject.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsProject.Pages
{
    public class CartPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement Checkout => driver.FindElement(By.Id("checkout"));

    }
}
