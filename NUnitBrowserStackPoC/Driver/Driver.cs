using BrowserStack;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitBrowserStackPoC.Driver
{
    internal class Driver
    {

        public static IOSDriver<IOSElement> driverIOS;
        public static  Local browserStackLocal = null;

        public static void CreateDriver()
        {

            var appiumOptions = new AppiumOptions();
            
            // Configure Appium driver
            appiumOptions.AddAdditionalCapability("browserstack.user", "");
            appiumOptions.AddAdditionalCapability("browserstack.key", "");
            appiumOptions.AddAdditionalCapability("device", "iPad 10th");
            appiumOptions.AddAdditionalCapability("os_version", "16");
            appiumOptions.AddAdditionalCapability("project", "NUnitBrowserStackPoC");
            appiumOptions.AddAdditionalCapability("app", "");
            appiumOptions.AddAdditionalCapability("build", "Test Build");
            appiumOptions.AddAdditionalCapability("name", "bstack-demo");
            appiumOptions.AddAdditionalCapability("browserstack.local", "true");
            appiumOptions.AddAdditionalCapability("browserstack.debug", "true");
            appiumOptions.AddAdditionalCapability("browserstack.networkLogs", "true");

            // Configure BS Local
            browserStackLocal = new Local();

            List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>()
                {   new KeyValuePair<string, string>("key", ""),
                    new KeyValuePair<string, string>("forcelocal", "true"),    
            };

            // Start driver and local binary
            browserStackLocal.start(bsLocalArgs);

            driverIOS = new IOSDriver<IOSElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), appiumOptions);

        }

        public static void CloseDriver()
        {
            driverIOS.Quit();
            browserStackLocal.stop();
        }
    }
}
