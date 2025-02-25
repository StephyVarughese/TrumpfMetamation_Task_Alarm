using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
            IWebElement AlarmAccept = driver.FindElement(By.XPath("//div[text()='Accept']"));

            IWebElement TimeOption = driver.FindElement(By.ClassName("alarmTime"));
            TimeOption.SendKeys("10:30");
          

            //Taking ScreenShot
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string filePath = @"C:\Users\jinog\OneDrive\Pictures\Screenshots\Screenshot (65)";
            screenshot.SaveAsFile(filePath);
            Console.WriteLine("Screenshot saved to: " + filePath);

            IWebElement DeleteBtn = driver.FindElement(By.Id("remove"));
            DeleteBtn.Click();

            //Quit
            driver.Close();
            //Setting the Time using Input


            /*
            IWebElement minuteOption = driver.FindElement(By.XPath("//div[@class='minute']//button[text()='30']"));
            minuteOption.Click();

            IWebElement ampmOption = driver.FindElement(By.XPath("//div[@class='am/pm']//button[text()='PM']"));
            ampmOption.Click();

            //dropdown
            IWebElement MusicDropdown = driver.FindElement(By.Id("SetMusic"));
            SelectElement dropdown = new SelectElement(MusicDropdown);
            dropdown.SelectByText("Option Text");
            IWebElement selectedOption = dropdown.AllSelectedOptions[0];
            Console.WriteLine("Selected Option: " + selectedOption.Text);

            //Checkbox
            IWebElement RepeatAlarmChkbox = driver.FindElement(By.Id("AlarmChk"));
            RepeatAlarmChkbox.Click();
            IWebElement SaveBtn = driver.FindElement(By.XPath("//button[text()='Save']"));
            SaveBtn.Click();


            //Using Assert we can able to Validate the Data


            //Once Alarm Saved back to Alarm Title
            //Delete the Alarm
            IWebElement DeleteBtn = driver.FindElement(By.XPath("//button[text()='Delete']")); // here we can use following siblings or dynamic xpath
            DeleteBtn.Click();
*/
        }

    }

}


