using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RequestSupport.Connection;
using RequestSupport.Model;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RequestSupport.FunctionRequestSupport
{
    public class FunctionRequestSupport_PanelHiweb
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        //public static ModelRequestSupport Convert_to_list_and_choose_random(string my_variable)
        //{
        //    List<string> mylist = my_variable.Split(new[] { "\n", "\r\n" }, StringSplitOptions.None)
        //                        .Select(s => s.Trim())
        //                        .Where(s => !string.IsNullOrWhiteSpace(s))
        //                        .ToList();
        //    List<string> filterReadList = mylist.Where(value => !(value.Contains("VPS") || value.Equals("سلب امتیاز سیم کارت") || value.Equals("انتخاب کنید"))).ToList();

        //    Random random = new Random();
        //    int IndexCustomerService = random.Next(0, filterReadList.Count);
        //    string RandomValue = filterReadList[IndexCustomerService];

        //    int iteration = IndexCustomerService;
        //    ModelRequestSupport randomCustomerService = new ModelRequestSupport();
        //    randomCustomerService.CustomerService = RandomValue;
        //    randomCustomerService.IndexCustomerService = iteration;
        //    return randomCustomerService;
        //}

        public static ModelRequestSupport Convert_to_list_and_choose_random(string my_variable)
        {
            List<string> mylist = my_variable.Split(new[] { "\n", "\r\n" }, StringSplitOptions.None)
                                            .Select(s => s.Trim())
                                            .Where(s => !string.IsNullOrWhiteSpace(s))
                                            .ToList();

            List<string> originalList = new List<string>(mylist); // لیست اصلی
            List<string> filterReadList = mylist.Where(value => !(value.Contains("VPS") || value.Equals("سلب امتیاز سیم کارت") || value.Equals("جمع آوری") || value.Equals("انتخاب کنید"))).ToList();

            Random random = new Random();
            int IndexCustomerService = random.Next(0, filterReadList.Count);

            int iteration = originalList.IndexOf(filterReadList[IndexCustomerService]); // اینجا شماره اصلی مقدار فیلتر شده را در لیست اصلی بدست می‌آوریم

            ModelRequestSupport randomCustomerService = new ModelRequestSupport();
            randomCustomerService.CustomerService = filterReadList[IndexCustomerService];
            randomCustomerService.IndexCustomerService = iteration;
            return randomCustomerService;
        }



        // Get Table First Request Support B2C
        public static ModelGetTableFirstRequestSupport GetTableFirstRequestSupport_B2C(IWebDriver driver, WebDriverWait wait)
        {
            ModelGetTableFirstRequestSupport getTableFirst_B2C = new ModelGetTableFirstRequestSupport();
            try
            {
                getTableFirst_B2C.Service_Table_First = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[@class=' fanum text-center'])[2]"))).Text;
                getTableFirst_B2C.Service_Table_First = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[@class=' fanum text-center'])[2]"))).Text;
                getTableFirst_B2C.Tittle_Table_First = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//td[@class=' fanum text-center'])[3]"))).Text;
                getTableFirst_B2C.Discription_Table_First = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='grid']/tbody/tr[1]/td[4]"))).Text;
                getTableFirst_B2C.CreateOn_Table_First = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[@class=' text-center ltr'])[1]"))).Text;
                getTableFirst_B2C.Status_Table_First = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[@class=' fanum text-center'])[4]"))).Text;

                IWebElement Guid_Create_Request_Support_First = driver.FindElement(By.XPath("(//button[@type='button' and @data-action='cancel'])[1]"));
                string dataId = Guid_Create_Request_Support_First.GetAttribute("data-id");
                getTableFirst_B2C.Guid_Create_Request_Support_First = dataId;
            }
            catch { }
            return getTableFirst_B2C;
        }
        // Get Table Second Request Support B2C
        public static ModelGetTableSecondRequestSupport GetTableSecondRequestSupport_B2C(IWebDriver driver, WebDriverWait wait)
        {
            ModelGetTableSecondRequestSupport getTableSecend_B2C = new ModelGetTableSecondRequestSupport();
            try
            {
                getTableSecend_B2C.Service_Table_Second = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[@class=' fanum text-center'])[2]"))).Text;
                getTableSecend_B2C.Tittle_Table_Second = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//td[@class=' fanum text-center'])[3]"))).Text;
                getTableSecend_B2C.Discription_Table_Second = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='grid']/tbody/tr[1]/td[4]"))).Text;
                getTableSecend_B2C.CreateOn_Table_Second = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[@class=' text-center ltr'])[1]"))).Text;
                getTableSecend_B2C.Status_Table_Second = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[@class=' fanum text-center'])[4]"))).Text;

                IWebElement Guid_Create_Request_Support_Second = driver.FindElement(By.XPath("(//button[@type='button' and @data-action='cancel'])[1]"));
                string dataId = Guid_Create_Request_Support_Second.GetAttribute("data-id");
                getTableSecend_B2C.Guid_Create_Request_Support_Second = dataId;
            }
            catch { }
            return getTableSecend_B2C;
        }
        // Get Table First Request Support B2B
        public static ModelGetTableFirstRequestSupport GetTableFirstRequestSupport_B2B(IWebDriver driver, WebDriverWait wait)
        {
            ModelGetTableFirstRequestSupport getTableFirst_B2B = new ModelGetTableFirstRequestSupport();
            try
            {
                getTableFirst_B2B.Tittle_Table_First = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//td[@class=' fanum text-center'])[2]"))).Text;
                getTableFirst_B2B.Service_Table_First = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='text-muted mr-2'])[1]"))).Text;
                getTableFirst_B2B.CreateOn_Table_First = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[@class=' fanum text-center ltr'])[1]"))).Text;
                getTableFirst_B2B.TrackingCode_Table_First = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//td[@class=' text-center'])[1]"))).Text;
                getTableFirst_B2B.Status_Table_First = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//td[@class=' fanum text-center'])[3]"))).Text;
                getTableFirst_B2B.Guid_Table_First = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[@class='btn btn-default btn-sm'])[1]"))).GetAttribute("href");
            }
            catch { }
            
            return getTableFirst_B2B;
        }
        // Get Table Second Request Support B2B
        public static ModelGetTableSecondRequestSupport GetTableSecondRequestSupport_B2B(IWebDriver driver, WebDriverWait wait)
        {
            ModelGetTableSecondRequestSupport getTableSecend_B2B = new ModelGetTableSecondRequestSupport();
            try
            {
                getTableSecend_B2B.Tittle_Table_Second = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//td[@class=' fanum text-center'])[2]"))).Text;
                getTableSecend_B2B.Service_Table_Second = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='text-muted mr-2'])[1]"))).Text;
                getTableSecend_B2B.CreateOn_Table_Second = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[@class=' fanum text-center ltr'])[1]"))).Text;
                getTableSecend_B2B.TrackingCode_Table_Second = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//td[@class=' text-center'])[1]"))).Text;
                getTableSecend_B2B.Status_Table_Second = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//td[@class=' fanum text-center'])[3]"))).Text;
                getTableSecend_B2B.Guid_Table_Second = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[@class='btn btn-default btn-sm'])[1]"))).GetAttribute("href");
            }
            catch { }
            return getTableSecend_B2B;
        }

        public static string ExtractGuidFromTable(string input)
        {
            Regex guidRegex = new Regex(@"([a-f\d]{8}-(?:[a-f\d]{4}-){3}[a-f\d]{12})", RegexOptions.IgnoreCase);
            MatchCollection matches = guidRegex.Matches(input);

            if (matches.Count > 0)
            {
                return matches[0].Value;
            }
            else
            {
                return null;
            }
        }

        public string GenerateRandomGuid()
        {
            Guid randomGuid = Guid.NewGuid();
            return randomGuid.ToString();
        }
        public void UploadRandomFile(IWebDriver driver, List<string> fileFormats = null)
        {
            string folderPath = @"C:\Users\m.eftekhari\Desktop\RequestSupport\RequestSupport\Upload_File_Test";
            //string folderPath = @"C:\Users\Mohammad\Desktop\RequestSupport\RequestSupport\Upload_File_Test";
            string[] listFiles = Directory.GetFiles(folderPath);

            List<string> filteredFiles;

            if (fileFormats != null)
            {
                filteredFiles = listFiles.Where(file => fileFormats.Contains(Path.GetExtension(file).ToLower())).ToList();
            }
            else
            {
                filteredFiles = listFiles.ToList();
            }

            if (filteredFiles.Count > 0)
            {
                Random random = new Random();
                string selectedRandomFile = filteredFiles[random.Next(filteredFiles.Count)];

                Console.WriteLine("List of files: " + string.Join(", ", listFiles));
                Console.WriteLine("Selected random file: " + selectedRandomFile);

                IWebElement fileInput = driver.FindElement(By.XPath("//input[@type='file']"));
                fileInput.SendKeys(selectedRandomFile);

                Console.WriteLine("File path: " + selectedRandomFile);
            }
            else
            {
                Console.WriteLine("No files found in the specified formats.");
            }
        }
        public string FindElementByXPath(string xpath, string text, IWebDriver driver)
        {
            try
            {
                var element = driver.FindElement(By.XPath(xpath));
                if (element.Text.Contains(text))
                {
                    string elementText = element.Text;
                    return elementText;
                }
                else
                {
                    return null;
                }
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        public void SendKeysToElement(string xpath, string text, WebDriverWait wait)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            element.SendKeys(text);
        }

        public void ClickElement(string xpath, WebDriverWait wait)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            element.Click();
        }
    }
}