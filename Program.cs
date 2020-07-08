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
 
            driver.Navigate().GoToUrl(targetInstagramUrl);

            var count = 0;

            while (true)
            {
                if (count >= words.Length) {
                    count = 0;
                }
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//textarea[@aria-label='Add a comment…']"))
                    .Click();
                    
                Thread.Sleep(2000);
 
                driver.FindElement(By.XPath("//textarea[@aria-label='Add a comment…']"))
                    .SendKeys(words[count]);
                
                Thread.Sleep(2000);
                var commentButton = driver.FindElement(By.XPath("//button[@type='submit']"));
                commentButton.Click();
                count++;
                
                
                Thread.Sleep(61000);
            }
        }
    }
}
