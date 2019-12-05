using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using NUnit.Framework;
using System.IO;

namespace Appium
{
    [TestClass]
    public class AppiumTest
    {

        AppiumDriver<AndroidElement> _driver;

        [TestMethod]
        public void TestBrowser()
        {
            AppiumOptions options = new AppiumOptions();
            options.PlatformName = "Android";
            options.AddAdditionalCapability("deviceName","Generic_x86");
            options.AddAdditionalCapability("platformVersion", "6.0.0");
            options.AddAdditionalCapability("automationName", "UiAutomator2");
            options.AddAdditionalCapability("browserName", "Browser");
            options.AddAdditionalCapability("chromedriverExecutableDir", @"C:\Users\Administrator\Documents\ChromeDriver");
            options.AddAdditionalCapability("chromedriverChromeMappingFile", @"C:\Users\Administrator\Documents\ChromeDriver\mapping.json");
            options.AddAdditionalCapability("newCommandTimeout", "120");

            _driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"),options);

            //Navigate to browser
            _driver.Navigate().GoToUrl("http://www.bing.com");
            _driver.FindElementByName("q").SendKeys("Microsoft");
            _driver.FindElementByName("q").SendKeys(Keys.Enter);

            //Verify something

        }

        [TestMethod]
        public void TestApp()
        {
            AppiumOptions options = new AppiumOptions();
            options.PlatformName = "Android";
            options.AddAdditionalCapability("deviceName", "Generic_x86");
            options.AddAdditionalCapability("platformVersion", "6.0.0");
            //options.AddAdditionalCapability("automationName", "UiAutomator2");
            options.AddAdditionalCapability("newCommandTimeout", "120");
            options.AddAdditionalCapability(MobileCapabilityType.App, "C:\\Users\\Administrator\\AppData\\Local\\Programs\\Appium\\resources\\app\\builds\\apk\\APIDemos.apk");
        
              // options.AddAdditionalCapability(MobileCapabilityType.App, "http://appium.s3.amazonaws.com/TestApp6.0.app.zip");
              ///options.AddAdditionalCapability("appPackage", "appPackage");
            //options.AddAdditionalCapability("appActivity", "appActivity");


            _driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), options);
            
            //Wait
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(80);

            //Open Application



            //tap 
            var el2 = (AndroidElement)_driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.ListView/android.widget.TextView[1]");
            el2.Click();
            var el3 = (AndroidElement)_driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.ListView/android.widget.TextView[2]");
            //el3.Click();
            _driver.Navigate().Back();
            _driver.Navigate().Back();

            //Verify something
            //Assert
        }
    }
}