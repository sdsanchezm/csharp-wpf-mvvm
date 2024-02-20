using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace UiTesting1
{
    public class ButtonsInterfaceTesting
    {

        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string NotepadAppId = @"C:\progs\AA_REPO_ALL\csharp-wpf-mvvm\wpfMVVM_buttonsInterface\ButtonsInterface\bin\x64\Release\net7.0-windows\ButtonsInterface.exe";

        protected static WindowsDriver<WindowsElement> session;
        protected static WindowsElement editBox;

        public ButtonsInterfaceTesting()
        {
            Console.WriteLine("initializing");
        }

        public WindowsDriver<WindowsElement> TestingProcess()
        {
            if (session == null)
            {
                DesiredCapabilities appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("app", NotepadAppId);
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            }

            return session;

        }

        public static void TearDown()
        {
            if (session != null)
            {
                session.Close();

                try
                {
                    session.FindElementByName("Don't Save").Click();
                }
                catch { }

                session.Quit();
                session = null;
            }
        }
    }
}
