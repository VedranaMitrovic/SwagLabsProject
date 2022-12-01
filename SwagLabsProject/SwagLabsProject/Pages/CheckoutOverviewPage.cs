using OpenQA.Selenium;
using SwagLabsProject.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsProject.Pages
{
    public class CheckoutOverviewPage
    {
        private IWebDriver driver = WebDrivers.Instance;
        public IWebElement FinishClick => driver.FindElement(By.Id("finish"));

    }
}
