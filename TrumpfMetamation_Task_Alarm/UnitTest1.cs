using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography.X509Certificates;
using TrumpfMetamation_Task_Alarm.Method;

namespace TrumpfMetamation_Task_Alarm
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }
        [Test]
        public void TrumpfMetamation_Task_AlarmTest()
        {
            var hours = 9;
            var minutes = 59;
            var inputTime = Methods.HoursMinute(hours, minutes);

            IWebDriver driver = new ChromeDriver();
            //To open the Clock App
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://os-clock.web.app/");
            driver.Manage().Window.Maximize();
            //Navigating to Alarm
            IWebElement alarmButton = driver.FindElement(By.XPath("//div[@onClick='showAlarm()']"));
            alarmButton.Click();
            Console.WriteLine("Alarm section opened successfully.");
          
            IWebElement AddAlarmBtn = driver.FindElement(By.Id("addAlarm"));
            AddAlarmBtn.Click();
            IWebElement NewAlarmName = driver.FindElement(By.ClassName("alarmName"));
            NewAlarmName.SendKeys("First alarm");        
           
            IWebElement TimeOption = driver.FindElement(By.ClassName("alarmTime"));
           
           TimeOption.SendKeys(inputTime);

            IWebElement AlarmAccept = driver.FindElement(By.XPath("//div[@onClick = 'submitAlarm(this)']"));
            AlarmAccept.Click();
              
            IWebElement Accept = driver.FindElement(By.ClassName("printAlarmName"));
            string AcceptAlarmNameLabel = Accept.Text;   
            
            IWebElement Time = driver.FindElement(By.ClassName("printAlarmTime"));
            string AlarmtimeLabel = Time.Text;

            Assert.AreEqual(AcceptAlarmNameLabel, "First alarm");
            Assert.AreEqual(AlarmtimeLabel, inputTime);


            //Taking ScreenShot
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string filePath = @"C:\Users\jinog\OneDrive\Pictures\Screenshots\Screenshot (65)";
            screenshot.SaveAsFile(filePath);
            Console.WriteLine("Screenshot saved to: " + filePath);

           // IWebElement DeleteBtn = driver.FindElement(By.Id("remove"));
           // DeleteBtn.Click();

            //Quit
           // driver.Close();

        }

    }

    
}


