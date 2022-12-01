using OpenQA.Selenium;
using SwagLabsProject.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsProject.Pages
{
    public class OrderFinishedPage
    {
        private IWebDriver driver = WebDrivers.Instance;
        public IWebElement OrderFinished => driver.FindElement(By.CssSelector("#checkout_complete_container .complete-header"));
    }
}
