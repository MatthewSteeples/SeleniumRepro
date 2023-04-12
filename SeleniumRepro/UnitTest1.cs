using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace SeleniumRepro
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly TimeSpan _defaultTimeout = TimeSpan.FromMinutes(3);

        [TestMethod]
        public void TestMethod1()
        {
            var options = new EdgeOptions();

            options.AddArguments("headless");
            options.AddArguments("disable-gpu");
            options.AddArguments("window-size=1920,1080");

            // Setup to retrieve JS errors
            options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);

            var path = Environment.GetEnvironmentVariable("EDGE_PATH");

            if (!string.IsNullOrEmpty(path))
            {
                options.BinaryLocation = path;
            }

            var webDriverPath = Environment.GetEnvironmentVariable("EdgeWebDriver");
            var webDriver = new EdgeDriver(webDriverPath, options, _defaultTimeout);
        }
    }
}