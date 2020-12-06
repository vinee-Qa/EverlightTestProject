using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EverlightTestProject
{
    public class TestCases
    {
        IWebDriver driver;

        public void OpenBrowserAndVerifyTitle()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://computer-database.gatling.io/computers");
            driver.Manage().Window.Maximize();
            var title = driver.FindElement(By.XPath("//h1[@class='fill']/a"));
            Assert.AreEqual("Computer database", title.Text);
            driver.Close();
            
        }

        public  void AddNewComputer()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://computer-database.gatling.io/computers");
            driver.Manage().Window.Maximize();
            var AddComputer = driver.FindElement(By.Id("add"));
            AddComputer.Click();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            var computerName = driver.FindElement(By.XPath("//input[@id='name']"));
            computerName.SendKeys("TestLenovoComputerEnter");
            var introducedDate = driver.FindElement(By.Id("introduced"));
            introducedDate.SendKeys("2020-12-01");
            var company = driver.FindElement(By.Id("company"));
            var companyDropDownValue = new SelectElement(company);
            companyDropDownValue.SelectByIndex(3);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            var alert = driver.FindElement(By.XPath("//div[@class='alert-message warning']/strong"));
            driver.Close();
        }

        public void HandleJavaScript(string response)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@onclick='jsAlert()']")).Click();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);
            if (response == "yes")
            {
                driver.FindElement(By.XPath(" //button[@onclick='jsConfirm()']")).Click();
                driver.SwitchTo().Alert().Accept();
            }
            else
            {
                driver.FindElement(By.XPath(" //button[@onclick='jsConfirm()']")).Click();
                driver.SwitchTo().Alert().Dismiss();
            }
            Thread.Sleep(10000);
            var jSPrompt = driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", jSPrompt);
            var jSPromptAlert = driver.SwitchTo().Alert();
            var alertText = jSPromptAlert.Text;
            jSPromptAlert.SendKeys("Test Java alert");
            jSPromptAlert.Accept();
            driver.Close();
        }

           

    }

}
