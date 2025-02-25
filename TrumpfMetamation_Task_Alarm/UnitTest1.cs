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
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("Clock", "ClockPath"); // Here we need to set the Clock App which is System App Clock
            //Navigating to Alarm
            var alarmButton = driver.FindElement(By.Name("Alarm"));
            alarmButton.Click();
            Console.WriteLine("Alarm section opened successfully.");
            //
            IWebElement AddBtn = driver.FindElement(By.XPath("//span[text()='Add']"));
            AddBtn.Click();
            IWebElement NewAlarmLbl = driver.FindElement(By.XPath("//span[text()='Add new alarm']"));
            string alarmLabel = NewAlarmLbl.Text;
            Assert.AreEqual("Add new alarm", alarmLabel); //To verify the Alarm label using Assertion

            //Taking ScreenShot
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string filePath = @"C:\Users\jinog\OneDrive\Pictures\Screenshots\ClockImage";
            screenshot.SaveAsFile(filePath);
            Console.WriteLine("Screenshot saved to: " + filePath);
            //Setting the Time using Input

            IWebElement hourOption = driver.FindElement(By.XPath("//div[@class='hour']//button[text()='10']"));
            hourOption.Click();

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

        }

    }

}


