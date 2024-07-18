using BrowserStack;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using NUnitBrowserStackPoC.Utilities;
using static NUnitBrowserStackPoC.Utilities.BrowserStackConfigManager;

namespace NUnitBrowserStackPoC.Driver
{
    internal class Driver
    {

        public static IOSDriver<IOSElement> driverIOS;
        public static  Local browserStackLocal = null;
        public static string currentEnv = "UAT1";
        public static Platform selectedPlatform;

        public static void CreateDriver()
        {


            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string bsYmlConfig = Path.Combine(projectDirectory, "browserstack.yml");

            BrowserStackConfigManager config = new BrowserStackConfigManager().Load(bsYmlConfig);

            var appiumOptions = new AppiumOptions();

            switch(currentEnv)
            {
                case "UAT1":
                    selectedPlatform = config.platforms.First(p => p.environment == "UAT1");
                    break;
                case "UAT2":
                    selectedPlatform = config.platforms.First(p => p.environment == "UAT2");
                    break;
                default:
                    selectedPlatform = config.platforms.First(p => p.environment == "UAT1"); 
                    break;
            }



            // Configure Appium driver
            appiumOptions.AddAdditionalCapability("browserstack.user", config.userName);
            appiumOptions.AddAdditionalCapability("browserstack.key", config.accessKey);
            appiumOptions.AddAdditionalCapability("device", selectedPlatform.deviceName);
            appiumOptions.AddAdditionalCapability("os_version", selectedPlatform.platformVersion);
            appiumOptions.AddAdditionalCapability("project", config.projectName);
            appiumOptions.AddAdditionalCapability("app", config.app);
            appiumOptions.AddAdditionalCapability("build", config.buildName);
            appiumOptions.AddAdditionalCapability("name", "test name");
            appiumOptions.AddAdditionalCapability("browserstack.local", config.browserstackLocal);
            appiumOptions.AddAdditionalCapability("browserstack.debug", config.debug);
            appiumOptions.AddAdditionalCapability("browserstack.networkLogs", config.networkLogs);

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
