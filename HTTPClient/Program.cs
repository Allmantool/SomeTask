namespace HTTPClient
{
    using OpenQA.Selenium;
    using System.Linq;
    using OpenQA.Selenium.Chrome;
    using System.Threading;

    public class Program
    {
        private const string demantedDay = "30";
        private const int MaxIterationCount = 5;
        private const int DelaySecond = 3;
        private const string DemandedTime = "18:45";

        public static void Main(string[] args)
        {
            var browser = new ChromeDriver();

            browser.Navigate().GoToUrl(@"https://npm.by/");

            var dayElement = GetDesiredDateElement(browser);

            var iteration = 0;
            while (iteration <= MaxIterationCount)
            {
                TimeToTimeClicking(dayElement);
                IsThereFreeSpace();

                Thread.Sleep(DelaySecond * 1000);
                iteration++;
            }

            browser.Quit();
        }

        private static IWebElement GetDesiredDateElement(ChromeDriver browser)
        {
            var calendar = browser.FindElement(By.ClassName("xdsoft_calendar"));
            return calendar
                .FindElements(By.TagName("td"))
                .SingleOrDefault(x => x.Text.Equals(demantedDay, System.StringComparison.CurrentCultureIgnoreCase));
        }

        // TODO: This method should click on target html element the required number of times.
        private static void TimeToTimeClicking(IWebElement element)
        {
            element.Click();
        }

        // TODO: This method responsable for nofyfication about existing free space on demand time.
        // Read actual value from time table (right table).
        private static bool IsThereFreeSpace()
        {
            return false;
        }
    }
}
