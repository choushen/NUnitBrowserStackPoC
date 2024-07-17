using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NUnitBrowserStackPoC.Driver
{

    [Binding]
    public class Hooks: IDisposable
    {

        [BeforeScenario]
        public static void SetUp()
        {
            Driver.CreateDriver();
            Console.WriteLine("Setup");
        }


        [AfterScenario]
        public void Dispose()
        {
            Driver.CloseDriver();
            Console.WriteLine("Tidyup");
        }


    }
}
