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
            //desktopSession.FindElementByAccessibilityId("ButtonRedSection").Click();
            //Thread.Sleep(TimeSpan.FromSeconds(1));
            //desktopSession.FindElementByAccessibilityId("ButtonGreenSection").Click();
            //Thread.Sleep(TimeSpan.FromSeconds(1));
            //desktopSession.FindElementByAccessibilityId("ButtonBlueSection").Click();
            //Thread.Sleep(TimeSpan.FromSeconds(5));

            int numberOfTestings = 5;
            int actualTest = 0;

            for (int i = 0; i < numberOfTestings; i++)
            {
                desktopSession.FindElementByAccessibilityId("ButtonRedSection").Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                desktopSession.FindElementByAccessibilityId("ButtonGreenSection").Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                desktopSession.FindElementByAccessibilityId("ButtonBlueSection").Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                actualTest++;
            }

            desktopSession.Quit();
            desktopSession = null;

            ReportOfTesting(actualTest);
            Console.ReadLine();

            //Console.ReadLine();
        }

        public static void ReportOfTesting(int numberOfTests)
        {
            Console.WriteLine("==========TEST-REPORT==========");
            Console.WriteLine($"Test Executed: {numberOfTests}");
            Console.WriteLine("==========END-OF-TEST==========");
        }
    }
}
