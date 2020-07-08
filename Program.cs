using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Botgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver();

            var instagramUrl = "https://www.instagram.com";
            var targetInstagramUrl = "https://www.instagram.com/p/CCUKG7AHltl/";
            var words = new[] {"Meu", "aniversário", "é", "dia", "20"};

            driver.Navigate().GoToUrl(instagramUrl);
            Thread.Sleep(10000);


            var userNameField = driver.FindElement(By.Name("username"));
            var passwordField = driver.FindElement(By.Name("password"));
            var loginButton = driver.FindElement(By.XPath("//button[@type='submit']"));
    
            userNameField.SendKeys("");
            passwordField.SendKeys("");
            loginButton.Click();

            Thread.Sleep(10000);
 
            var count = 0;

            while (true)
            {
                driver.Navigate().GoToUrl(targetInstagramUrl);

                if (count >= words.Length) {
                    count = 0;
                }
                Thread.Sleep(5000);

                var inputComment = driver.FindElement(By.ClassName("Ypffh"));
                if (inputComment == null || !inputComment.Displayed || !inputComment.Enabled)
                {
                    continue;
                }
                inputComment.Click();
                
                
                inputComment = driver.FindElement(By.ClassName("Ypffh"));
                inputComment.SendKeys(words[count]);
                
                Thread.Sleep(2000);
                
                driver.FindElement(By.XPath("//button[@type='submit']"))
                    .Click();
                count++;
                
                Thread.Sleep(61000);
            }
        }
    }
}
