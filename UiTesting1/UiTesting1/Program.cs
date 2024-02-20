using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace UiTesting1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========Starting Test==========");


            var desktopSession = new ButtonsInterfaceTesting().TestingProcess();

            // Name of the element from the inspector
            //desktopSession.FindElementByName("Red").Click();
            //desktopSession.FindElementByName("+3").Click();

            // AutomationId from the inspector
            desktopSession.FindElementByAccessibilityId("ButtonRedSection").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            desktopSession.FindElementByAccessibilityId("ButtonGreenSection").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            desktopSession.FindElementByAccessibilityId("ButtonBlueSection").Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));


            desktopSession.Quit();
            desktopSession = null;
            //Console.ReadLine();
        }
    }
}
