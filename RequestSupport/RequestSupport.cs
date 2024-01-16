using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using System.IO;
using OpenQA.Selenium.Interactions;
using RequestSupport.FunctionRequestSupport;
using System.Collections.Generic;
using System.Linq;
using RequestSupport.Model;
using RequestSupport.Connection;
using System.Text.RegularExpressions;
using Assert = NUnit.Framework.Assert;
using RequestSupport.Retrive_Case;
using RequestSupport.Retrive_Contact_Account_CS;
using Microsoft.Xrm.Sdk;

namespace RequestSupport
{
    public class Tests
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public Actions actions;
        private ModelContact_Account_Service_CRM data;
        private ModelContact_Account_Service_CRM data_Type_CS;
        private Guid RESULT_TEST_id;

        [SetUp]
        public void Setup()
        {
            Connection_Selenium seleniumConnection = new Connection_Selenium();
            driver = seleniumConnection.driver;
            wait = seleniumConnection.wait;
            actions = seleniumConnection.action;

            string Username = "6390531";
            string Password = "492843";

            try
            {

                FunctionRequestSupport_PanelHiweb LoginPanel = new FunctionRequestSupport_PanelHiweb();
                LoginPanel.SendKeysToElement("//*[@id='Username']", Username, wait);
                LoginPanel.SendKeysToElement("//*[@id='Password']", Password, wait);
                LoginPanel.ClickElement("//input[@type='submit']", wait);


                Ritrive_MergeContactAccount_CustomerService ritrive_MergeContactAccount_CustomerService = new Ritrive_MergeContactAccount_CustomerService();
                List<ModelContact_Account_Service_CRM> retrive_Account_Contact_CustomerService = ritrive_MergeContactAccount_CustomerService.Contact_Account_CustomerService(Username, Password);
                if (retrive_Account_Contact_CustomerService != null && retrive_Account_Contact_CustomerService.Count > 0)
                {
                    foreach (var data in retrive_Account_Contact_CustomerService)
                    {
                        this.data = data;
                        if (data.LogicalName == "contact")
                        {
                            var orgService_Demo = Connetion_CRM.GetOrgServiceDemo();

                            Entity entity = new Entity("new_resulttest");

                            entity["new_name"] = data.Name;

                            entity["new_username"] = data.Username;

                            entity["new_password"] = data.Password;


                            switch (data.Type_id)
                            {
                                case 1:    // Customer
                                    entity["new_type"] = new OptionSetValue(1);
                                    break;
                                case 2:    // B2C
                                    entity["new_type"] = new OptionSetValue(2);
                                    break;
                                case 3:    // B2B
                                    entity["new_type"] = new OptionSetValue(3);
                                    break;
                                case 4:    //Reseller
                                    entity["new_type"] = new OptionSetValue(4);
                                    break;
                                default:
                                    break;
                            }


                            if (data.LogicalName == "account")
                            {
                                entity["new_customer"] = new OptionSetValue(1);
                            }
                            if (data.LogicalName == "contact")
                            {
                                entity["new_customer"] = new OptionSetValue(2);
                            }
                            if (data.LogicalName == "hiw_customerservice")
                            {
                                entity["new_customer"] = new OptionSetValue(3);
                            }

                            RESULT_TEST_id = orgService_Demo.Create(entity);
                        }

                        if (data.LogicalName == "account")
                        {
                            var orgService_Demo = Connetion_CRM.GetOrgServiceDemo();

                            Entity entity = new Entity("new_resulttest");


                            entity["new_name"] = data.Name;

                            entity["new_username"] = data.Username;

                            entity["new_password"] = data.Password;


                            switch (data.Type_id)
                            {
                                case 1:    // Customer
                                    entity["new_type"] = new OptionSetValue(1);
                                    break;
                                case 2:    // B2C
                                    entity["new_type"] = new OptionSetValue(2);
                                    break;
                                case 3:    // B2B
                                    entity["new_type"] = new OptionSetValue(3);
                                    break;
                                case 4:    //Reseller
                                    entity["new_type"] = new OptionSetValue(4);
                                    break;
                                default:
                                    break;
                            }

                            if (data.LogicalName == "account")
                            {
                                entity["new_customer"] = new OptionSetValue(1);
                            }
                            if (data.LogicalName == "contact")
                            {
                                entity["new_customer"] = new OptionSetValue(2);
                            }
                            if (data.LogicalName == "hiw_customerservice")
                            {
                                entity["new_customer"] = new OptionSetValue(3);
                            }

                            RESULT_TEST_id = orgService_Demo.Create(entity);
                        }

                        if (data.LogicalName == "hiw_customerservice")
                        {
                            var orgService_Demo = Connetion_CRM.GetOrgServiceDemo();

                            Entity entity = new Entity("new_resulttest");

                            entity["new_name"] = data.Name;

                            entity["new_username"] = data.Username;

                            entity["new_password"] = data.Password;

                            if (data.LogicalName == "account")
                            {
                                entity["new_customer"] = new OptionSetValue(1);
                            }
                            if (data.LogicalName == "contact")
                            {
                                entity["new_customer"] = new OptionSetValue(2);
                            }
                            if (data.LogicalName == "hiw_customerservice")
                            {
                                entity["new_customer"] = new OptionSetValue(3);
                            }

                            if (data.FcpProvider_Guid == new Guid("AF55450B-5597-EA11-9C12-00505681AE19"))
                            {
                                entity["new_fcpprovider"] = new OptionSetValue(1);
                            }
                            if (data.FcpProvider_Guid == new Guid("E7E69611-5597-EA11-9C12-00505681AE19"))
                            {
                                entity["new_fcpprovider"] = new OptionSetValue(2);
                            }


                            Guid guid_customer_CS = data.GetGuid_CS_Customer;

                            Ritrive_MergeContactAccount ritrive_MergeContactAccount = new Ritrive_MergeContactAccount();
                            List<ModelContact_Account_Service_CRM> retrive_Account_Contact = ritrive_MergeContactAccount.Get_Contact_Account(guid_customer_CS);
                            if (retrive_Account_Contact != null && retrive_Account_Contact.Count > 0)
                            {
                                foreach (var data_Type_CS in retrive_Account_Contact)
                                {
                                    this.data_Type_CS = data_Type_CS;
                                    switch (data_Type_CS.Type_id)
                                    {
                                        case 1:    // Customer
                                            entity["new_type"] = new OptionSetValue(1);
                                            break;
                                        case 2:    // B2C
                                            entity["new_type"] = new OptionSetValue(2);
                                            break;
                                        case 3:    // B2B
                                            entity["new_type"] = new OptionSetValue(3);
                                            break;
                                        case 4:    //Reseller
                                            entity["new_type"] = new OptionSetValue(4);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            RESULT_TEST_id = orgService_Demo.Create(entity);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        [Test]
        public void Test1()
        {
            var orgService_Demo = Connetion_CRM.GetOrgServiceDemo();
            Entity entity = new Entity("new_resulttest", RESULT_TEST_id);

            // ***************************************************************** B2C / Customer *****************************************************************
            if (data.Type_id == 1 || data.Type_id == 2 || data_Type_CS.Type_id == 1 || data_Type_CS.Type_id == 2)
            {
                actions.SendKeys(Keys.End).Perform();
                IWebElement Buttom_HomePanel_RequestSupport = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//a[@href='/ticketing'])[2]")));
                actions.MoveToElement(Buttom_HomePanel_RequestSupport);
                actions.Perform();
                while (!Buttom_HomePanel_RequestSupport.Enabled)
                {
                    actions.MoveToElement(Buttom_HomePanel_RequestSupport);
                    actions.Perform();
                    Thread.Sleep(1000);
                }
                Buttom_HomePanel_RequestSupport.Click();

                //Checked Value in Table
                string xpath_Not_Value_Table = "//*[@class='dataTables_empty']";
                string Text_Not_Value_Table = "موردی یافت نشد";

                FunctionRequestSupport_PanelHiweb Checked_Value_in_Table = new FunctionRequestSupport_PanelHiweb();
                string element_Value_Table = Checked_Value_in_Table.FindElementByXPath(xpath_Not_Value_Table, Text_Not_Value_Table, driver);

                if (element_Value_Table == Text_Not_Value_Table)
                {
                    //Create New Record Request_Support
                    IWebElement New_Request_Support_PH = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='btn btn-primary btn-sm collapsed' and @role='button']")));
                    New_Request_Support_PH.Click();

                    var ticketsubject = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@id='SubjectId']"))).Text;
                    Console.WriteLine("Ticket Subject: " + ticketsubject);

                    //Start Get Convert_to_list_and_choose_random
                    var GetRandomticketsubject = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(ticketsubject);
                    IWebElement Select_ticketsubject = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//select[@id='CustomerServiceId']/option[{GetRandomticketsubject.IndexCustomerService + 1}][@class='text-center']")));
                    Select_ticketsubject.Click();

                    Console.WriteLine("Get Random Customer Service: " + GetRandomticketsubject.CustomerService);
                    Console.WriteLine("Get Random iteration: " + GetRandomticketsubject.IndexCustomerService);
                    Thread.Sleep(1000);

                    var my_variable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@id='CustomerServiceId']"))).Text;
                    Console.WriteLine("Customer Service: " + my_variable);

                    //Start Get Convert_to_list_and_choose_random
                    var GetRandomCustomerService = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(my_variable);

                    IWebElement Select_CustomerService = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//select[@id='CustomerServiceId']/option[{GetRandomCustomerService.IndexCustomerService + 1}][@class='text-center']")));
                    string Guid_CustomerService = Select_CustomerService.GetAttribute("value");
                    Select_CustomerService.Click();

                    Console.WriteLine("Get Random Customer Service: " + GetRandomCustomerService.CustomerService);
                    Console.WriteLine("Get Random iteration: " + GetRandomCustomerService.IndexCustomerService);
                    Console.WriteLine("Get Random iteration: " + Guid_CustomerService);
                    Thread.Sleep(2000);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='Description']"))).SendKeys("Guid First Record Table: " + Guid_CustomerService + "\n" + GetRandomCustomerService.CustomerService);
                    Console.WriteLine("Description: Guid First Record Table = " + "\n" + Guid_CustomerService + "\n" + GetRandomCustomerService.CustomerService);

                    //Upload Random File
                    FunctionRequestSupport_PanelHiweb GetRandomFile = new FunctionRequestSupport_PanelHiweb();
                    List<string> allowedExtensions = new List<string> { ".pdf", ".jpg" };
                    GetRandomFile.UploadRandomFile(driver, allowedExtensions);

                    // Send Data To Server
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//Button[@id='saveButton']"))).Click();

                    //Checked Pass or Faild Create Request Support
                    string xpath_Pass_Alert_Create_RS = "//*[@class='alert alert-success']";
                    string xpath_Faild_Alert_Create_RS = "//*[@class='alert alert-danger']";
                    string Text_Pass_Alert = "درخواست پشتیبانی با موفقیت ثبت شد.";
                    string Text_Faild_Alert = "شما یک درخواست پشتیبانی باز با موضوع انتخاب شده برای سرویس انتخاب شده دارید. امکان ایجاد درخواست مجدد وجود ندارد.";

                    FunctionRequestSupport_PanelHiweb ElementPassFaild = new FunctionRequestSupport_PanelHiweb();
                    string element_Pass = ElementPassFaild.FindElementByXPath(xpath_Pass_Alert_Create_RS, Text_Pass_Alert, driver);
                    string element_Faild = ElementPassFaild.FindElementByXPath(xpath_Faild_Alert_Create_RS, Text_Faild_Alert, driver);

                    Guid GuidCS = new Guid(Guid_CustomerService);

                    Ritrive_CustomerService ritrive_CustomerService = new Ritrive_CustomerService();
                    List<ModelContact_Account_Service_CRM> ritrive_CS = ritrive_CustomerService.CustomerService(GuidCS);

                    if (ritrive_CS != null && ritrive_CS.Count > 0)
                    {
                        foreach (var data_FcpProvider in ritrive_CS)
                        {
                            if (data_FcpProvider.LogicalName == "hiw_customerservice")
                            {
                                if (data.FcpProvider_Guid == new Guid("AF55450B-5597-EA11-9C12-00505681AE19"))
                                {
                                    entity["new_fcpprovider"] = new OptionSetValue(1);
                                }
                                if (data.FcpProvider_Guid == new Guid("E7E69611-5597-EA11-9C12-00505681AE19"))
                                {
                                    entity["new_fcpprovider"] = new OptionSetValue(2);
                                }
                            }
                        }
                        orgService_Demo.Update(entity);
                    }

                    // Pass Request Support
                    if (element_Pass == Text_Pass_Alert)
                    {
                        Console.WriteLine($"پیدا شد: {Text_Pass_Alert}");
                        entity["new_discription"] = Text_Pass_Alert;

                        //Get Table Value Second Request Support
                        var GetValueTableSecond = FunctionRequestSupport_PanelHiweb.GetTableSecondRequestSupport_B2C(driver, wait);

                        Console.WriteLine("************ Start ************ Get Value Table Second ***************" + "\n");
                        string Service_Table_Second = GetValueTableSecond.Service_Table_Second;
                        Console.WriteLine("Service Table Second: " + Service_Table_Second.ToString());

                        string Tittle_Table_Second = GetValueTableSecond.Tittle_Table_Second;
                        if (!string.IsNullOrEmpty(Tittle_Table_Second))
                        {
                            Tittle_Table_Second = GetRandomticketsubject.CustomerService;
                            Console.WriteLine("Tittle Table Second: " + Tittle_Table_Second);
                        }
                        else
                        {
                            Console.WriteLine("Tittle Table Second: " + Tittle_Table_Second);
                        }

                        string Discription_Table_Second = GetValueTableSecond.Discription_Table_Second;
                        Console.WriteLine("Discription Table Second: " + Discription_Table_Second.ToString());

                        string CreateOn_Table_Second = GetValueTableSecond.CreateOn_Table_Second;
                        Console.WriteLine("CreateOn Table Second: " + CreateOn_Table_Second.ToString());

                        string Status_Table_Second = GetValueTableSecond.Status_Table_Second;
                        Console.WriteLine("Status Table Second: " + Status_Table_Second.ToString());

                        string Guid_Create_RequestSupport_Second = GetValueTableSecond.Guid_Create_Request_Support_Second;
                        if (!string.IsNullOrEmpty(Guid_Create_RequestSupport_Second))
                        {
                            Console.WriteLine("Guid Create RequestSupport Second: " + Guid_Create_RequestSupport_Second.ToString());
                        }

                        entity["new_tittletablesecond"] = Tittle_Table_Second;
                        entity["new_servicetablesecond"] = Service_Table_Second;
                        entity["new_discriptiontablesecond"] = Discription_Table_Second;
                        entity["new_createontablesecond"] = CreateOn_Table_Second;
                        entity["new_guidtablesecond"] = Guid_Create_RequestSupport_Second;
                        entity["new_statustablesecond"] = Status_Table_Second;
                        orgService_Demo.Update(entity);
                        Console.WriteLine("************ End ************ Get Value Table Second ***************");

                        //Get case values create in CRM
                        try
                        {
                            Guid GuidRecordCase = new Guid(Guid_CustomerService);
                            string Value_ticketsubjects = GetRandomticketsubject.CustomerService.ToString().Trim();

                            Incident_Case incidentCaseInstance = new Incident_Case();

                            List<ModelCaseCRM> incidentData = incidentCaseInstance.GetIncidentCase_B2C(GuidRecordCase, Value_ticketsubjects);
                            if (incidentData != null && incidentData.Count > 0)
                            {
                                foreach (var data in incidentData)
                                {
                                    Console.WriteLine("************ Start ************ Get Value Case CRM ***************" + "\n");
                                    Console.WriteLine($"Title: {data.title_Case}");
                                    Console.WriteLine($"Extraction Title Case: {data.Extraction_title_Case}");
                                    Console.WriteLine($"State Code: {data.statecode_Case}");
                                    Console.WriteLine($"Status Code: {data.statuscode_Case}");
                                    Console.WriteLine($"Ticket Number: {data.ticketNumber_Case}");
                                    Console.WriteLine($"Customer Service: {data.customerService_Case}");
                                    Console.WriteLine($"Ticket Department: {data.ticketDepartemant_Case}");
                                    Console.WriteLine($"Ticket Subject: {data.ticketsubject_Case}");
                                    Console.WriteLine($"Ticket Subject B2C: {data.subjectid_case}");
                                    Console.WriteLine($"Created On: {data.createdon_Case}");
                                    Console.WriteLine($"Guid Case CRM: {data.GetGuidCaseRecord}");
                                    Console.WriteLine("************ End ************ Get Value Case CRM ***************");

                                    if (Tittle_Table_Second == data.Extraction_title_Case)
                                    {
                                        string guidFromSecond = Guid_Create_RequestSupport_Second;
                                        string guidFromData = data.GetGuidCaseRecord.ToString();

                                        if (guidFromSecond == guidFromData)
                                        {
                                            entity["new_titlecase"] = data.Extraction_title_Case;
                                            entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                            entity["new_createdoncase"] = data.createdon_Case;
                                            entity["new_customerservicecase"] = data.customerService_Case;
                                            entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                            entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                            entity["new_subjectcase"] = data.subjectid_case;
                                            entity["new_guidcreaterequestsupportsecond"] = data.GetGuidCaseRecord;

                                            if (data.statecode_Case == 0) // Active
                                            {
                                                entity["new_status"] = new OptionSetValue(0);
                                            }
                                            if (data.statecode_Case == 1) // Resolved
                                            {
                                                entity["new_status"] = new OptionSetValue(1);
                                            }
                                            if (data.statecode_Case == 2) // Canceled
                                            {
                                                entity["new_status"] = new OptionSetValue(2);
                                            }


                                            if (data.statuscode_Case == 910340003) // Draft
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(91034003);
                                            }
                                            if (data.statuscode_Case == 1) // InProgress
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(1);
                                            }
                                            if (data.statuscode_Case == 2) // On Hold
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(2);
                                            }
                                            if (data.statuscode_Case == 3) // Wating for Details
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(3);
                                            }
                                            if (data.statuscode_Case == 4) // Resaching
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(4);
                                            }

                                            entity["new_resulttest"] = new OptionSetValue(1);

                                            entity["new_messageresult"] = "Assertion succeeded.";
                                            orgService_Demo.Update(entity);

                                            Assert.Pass("Assertion succeeded.");
                                        }
                                        else
                                        {

                                            entity["new_titlecase"] = data.Extraction_title_Case;
                                            entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                            entity["new_createdoncase"] = data.createdon_Case;
                                            entity["new_customerservicecase"] = data.customerService_Case;
                                            entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                            entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                            entity["new_subjectcase"] = data.subjectid_case;

                                            if (data.statecode_Case == 0) // Active
                                            {
                                                entity["new_status"] = new OptionSetValue(0);
                                            }
                                            if (data.statecode_Case == 1) // Resolved
                                            {
                                                entity["new_status"] = new OptionSetValue(1);
                                            }
                                            if (data.statecode_Case == 2) // Canceled
                                            {
                                                entity["new_status"] = new OptionSetValue(2);
                                            }


                                            if (data.statuscode_Case == 910340003) // Draft
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(91034003);
                                            }
                                            if (data.statuscode_Case == 1) // InProgress
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(1);
                                            }
                                            if (data.statuscode_Case == 2) // On Hold
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(2);
                                            }
                                            if (data.statuscode_Case == 3) // Wating for Details
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(3);
                                            }
                                            if (data.statuscode_Case == 4) // Resaching
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(4);
                                            }

                                            entity["new_resulttest"] = new OptionSetValue(2);
                                            entity["new_messageresult"] = "Guid_Create_RequestSupport_Second does not match data.GetGuidCaseRecord.";
                                            orgService_Demo.Update(entity);

                                            Assert.Fail("Guid_Create_RequestSupport_Second does not match data.GetGuidCaseRecord.");
                                        }
                                    }
                                    else
                                    {

                                        entity["new_titlecase"] = data.Extraction_title_Case;
                                        entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                        entity["new_createdoncase"] = data.createdon_Case;
                                        entity["new_customerservicecase"] = data.customerService_Case;
                                        entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                        entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                        entity["new_subjectcase"] = data.subjectid_case;

                                        if (data.statecode_Case == 0) // Active
                                        {
                                            entity["new_status"] = new OptionSetValue(0);
                                        }
                                        if (data.statecode_Case == 1) // Resolved
                                        {
                                            entity["new_status"] = new OptionSetValue(1);
                                        }
                                        if (data.statecode_Case == 2) // Canceled
                                        {
                                            entity["new_status"] = new OptionSetValue(2);
                                        }


                                        if (data.statuscode_Case == 910340003) // Draft
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(91034003);
                                        }
                                        if (data.statuscode_Case == 1) // InProgress
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(1);
                                        }
                                        if (data.statuscode_Case == 2) // On Hold
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(2);
                                        }
                                        if (data.statuscode_Case == 3) // Wating for Details
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(3);
                                        }
                                        if (data.statuscode_Case == 4) // Resaching
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(4);
                                        }

                                        entity["new_resulttest"] = new OptionSetValue(2);
                                        entity["new_messageresult"] = "Tittle_Table_Second does not match data.Extraction_title_Case.";
                                        orgService_Demo.Update(entity);
                                        Assert.Fail("Tittle_Table_Second does not match data.Extraction_title_Case.");
                                    }
                                }
                            }
                            else
                            {
                                entity["new_resulttest"] = new OptionSetValue(2);
                                entity["new_messageresult"] = "رکورد ایجادی تکراری می باشد.";
                                orgService_Demo.Update(entity);
                                Console.WriteLine("رکورد ایجادی تکراری می باشد.");
                            }
                        }
                        catch
                        {
                        }
                    }
                    //Faild Request Support
                    else if (element_Faild == Text_Faild_Alert)
                    {
                        Console.WriteLine("پیدا شد: " + Text_Faild_Alert);
                        entity["new_discription"] = Text_Faild_Alert;

                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@href='/ticketing'])[2]"))).Click();

                        //Checked Value in Table
                        FunctionRequestSupport_PanelHiweb Checked_Value_in_Table_Not = new FunctionRequestSupport_PanelHiweb();
                        string element_Value_Table_Not = Checked_Value_in_Table_Not.FindElementByXPath(xpath_Not_Value_Table, Text_Not_Value_Table, driver);

                        if (element_Value_Table_Not != null)
                        {
                            entity["new_resulttest"] = new OptionSetValue(1);
                            entity["new_messageresult"] = "element_Value_Table_Not And Discription_Table_Second should not be null.";
                            orgService_Demo.Update(entity);
                            Assert.IsNotNull(element_Value_Table_Not, "Discription_Table_Second should not be null.");
                        }
                        else
                        {
                            entity["new_resulttest"] = new OptionSetValue(2);
                            entity["new_messageresult"] = "SupportRequest Record Created";
                            orgService_Demo.Update(entity);
                            Assert.Fail("SupportRequest Record Created");
                        }
                    }
                    else
                    {
                        entity["new_resulttest"] = new OptionSetValue(2);
                        entity["new_messageresult"] = "شما مجاز به ثبت درخواست نمی باشد.";
                        orgService_Demo.Update(entity);
                        Assert.Fail("شما مجاز به ثبت درخواست نمی باشد.");
                    }
                }
                else if (element_Value_Table == null)
                {
                    //Get Table Value First Request Support
                    var GetValueTableFirst = FunctionRequestSupport_PanelHiweb.GetTableFirstRequestSupport_B2C(driver, wait);

                    Console.WriteLine("************ Start ************ Get Value Table First ***************" + "\n");
                    string Service_Table_First = GetValueTableFirst.Service_Table_First;
                    Console.WriteLine("Service Table First: " + Service_Table_First.ToString());

                    string Tittle_Table_First = GetValueTableFirst.Tittle_Table_First;
                    Console.WriteLine("Tittle Table First: " + Tittle_Table_First);

                    string Discription_Table_First = GetValueTableFirst.Discription_Table_First;
                    Console.WriteLine("Discription Table First: " + Discription_Table_First.ToString());

                    string CreateOn_Table_First = GetValueTableFirst.CreateOn_Table_First;
                    Console.WriteLine("CreateOn Table First: " + CreateOn_Table_First.ToString());

                    string Status_Table_First = GetValueTableFirst.Status_Table_First;
                    Console.WriteLine("Status Table First: " + Status_Table_First.ToString());

                    string Guid_Create_RequestSupport_First = GetValueTableFirst.Guid_Create_Request_Support_First;
                    if (!string.IsNullOrEmpty(Guid_Create_RequestSupport_First))
                    {
                        Console.WriteLine("Guid Create RequestSupport First: " + Guid_Create_RequestSupport_First.ToString());
                    }

                    entity["new_tittletablefirst"] = Tittle_Table_First;
                    entity["new_servicetablefirst"] = Service_Table_First;
                    entity["new_discriptiontablefirst"] = Discription_Table_First;
                    entity["new_createontablefirst"] = CreateOn_Table_First;
                    entity["new_statustablefirst"] = Status_Table_First;
                    entity["new_guidrequestsupportfirst"] = Guid_Create_RequestSupport_First;

                    orgService_Demo.Update(entity);
                    Console.WriteLine("************ End ************ Get Value Table First ***************");

                    //Create New Record Request_Support
                    IWebElement New_Request_Support_PH = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='btn btn-primary btn-sm collapsed' and @role='button']")));
                    New_Request_Support_PH.Click();

                    var ticketsubject = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@id='SubjectId']"))).Text;
                    Console.WriteLine("Ticket Subject: " + ticketsubject);

                    //Start Get Convert_to_list_and_choose_random
                    var GetRandomticketsubject = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(ticketsubject);
                    IWebElement Select_ticketsubject = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//select[@id='SubjectId']/option[{GetRandomticketsubject.IndexCustomerService + 1}]")));
                    Select_ticketsubject.Click();

                    Console.WriteLine("Get Random Customer Service: " + GetRandomticketsubject.CustomerService);
                    Console.WriteLine("Get Random iteration: " + GetRandomticketsubject.IndexCustomerService);
                    Thread.Sleep(1000);

                    var my_variable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@id='CustomerServiceId']"))).Text;
                    Console.WriteLine("Customer Service: " + my_variable);

                    //Start Get Convert_to_list_and_choose_random
                    var GetRandomCustomerService = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(my_variable);

                    IWebElement Select_CustomerService = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//select[@id='CustomerServiceId']/option[{GetRandomCustomerService.IndexCustomerService + 1}][@class='text-center']")));
                    string Guid_CustomerService = Select_CustomerService.GetAttribute("value");
                    Select_CustomerService.Click();

                    Console.WriteLine("Get Random Customer Service: " + GetRandomCustomerService.CustomerService);
                    Console.WriteLine("Get Random iteration: " + GetRandomCustomerService.IndexCustomerService);
                    Console.WriteLine("Get Random iteration: " + Guid_CustomerService);

                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='Description']"))).SendKeys("Guid First Record Table: " + Guid_CustomerService + "\n" + GetRandomCustomerService.CustomerService);
                    Console.WriteLine("Description: Guid First Record Table = " + "\n" + Guid_CustomerService + "\n" + GetRandomCustomerService.CustomerService);

                    //Upload Random File
                    FunctionRequestSupport_PanelHiweb GetRandomFile = new FunctionRequestSupport_PanelHiweb();
                    List<string> allowedExtensions = new List<string> { ".pdf", ".jpg" };
                    GetRandomFile.UploadRandomFile(driver, allowedExtensions);

                    // Send Data To Server
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//Button[@id='saveButton']"))).Click();

                    //Checked Pass or Faild Create Request Support
                    string xpath_Pass_Alert_Create_RS = "//*[@class='alert alert-success']";
                    string xpath_Faild_Alert_Create_RS = "//*[@class='alert alert-danger']";
                    string Text_Pass_Alert = "درخواست پشتیبانی با موفقیت ثبت شد.";
                    string Text_Faild_Alert = "شما یک درخواست پشتیبانی باز با موضوع انتخاب شده برای سرویس انتخاب شده دارید. امکان ایجاد درخواست مجدد وجود ندارد.";

                    FunctionRequestSupport_PanelHiweb ElementPassFaild = new FunctionRequestSupport_PanelHiweb();
                    string element_Pass = ElementPassFaild.FindElementByXPath(xpath_Pass_Alert_Create_RS, Text_Pass_Alert, driver);
                    string element_Faild = ElementPassFaild.FindElementByXPath(xpath_Faild_Alert_Create_RS, Text_Faild_Alert, driver);

                    Guid GuidCS = new Guid(Guid_CustomerService);

                    Ritrive_CustomerService ritrive_CustomerService = new Ritrive_CustomerService();
                    List<ModelContact_Account_Service_CRM> ritrive_CS = ritrive_CustomerService.CustomerService(GuidCS);

                    if (ritrive_CS != null && ritrive_CS.Count > 0)
                    {
                        foreach (var data_FcpProvider in ritrive_CS)
                        {
                            if (data_FcpProvider.FcpProvider_Guid == new Guid("AF55450B-5597-EA11-9C12-00505681AE19"))
                            {
                                entity["new_fcpprovider"] = new OptionSetValue(1);
                            }
                            if (data_FcpProvider.FcpProvider_Guid == new Guid("E7E69611-5597-EA11-9C12-00505681AE19"))
                            {
                                entity["new_fcpprovider"] = new OptionSetValue(2);
                            }
                        }
                        orgService_Demo.Update(entity);
                    }

                    // Pass Request Support
                    if (element_Pass == Text_Pass_Alert)
                    {
                        Console.WriteLine($"پیدا شد: {Text_Pass_Alert}");
                        entity["new_discription"] = Text_Pass_Alert;

                        //Get Table Value Second Request Support
                        var GetValueTableSecond = FunctionRequestSupport_PanelHiweb.GetTableSecondRequestSupport_B2C(driver, wait);

                        Console.WriteLine("************ Start ************ Get Value Table Second ***************" + "\n");
                        string Service_Table_Second = GetValueTableSecond.Service_Table_Second;
                        Console.WriteLine("Service Table Second: " + Service_Table_Second.ToString());

                        string Tittle_Table_Second = GetValueTableSecond.Tittle_Table_Second;
                        if (!string.IsNullOrEmpty(Tittle_Table_Second))
                        {
                            Tittle_Table_Second = GetRandomticketsubject.CustomerService;
                            Console.WriteLine("Tittle Table Second: " + Tittle_Table_Second);
                        }
                        else
                        {
                            Console.WriteLine("Tittle Table Second: " + Tittle_Table_Second);
                        }

                        string Discription_Table_Second = GetValueTableSecond.Discription_Table_Second;
                        Console.WriteLine("Discription Table Second: " + Discription_Table_Second.ToString());

                        string CreateOn_Table_Second = GetValueTableSecond.CreateOn_Table_Second;
                        Console.WriteLine("CreateOn Table Second: " + CreateOn_Table_Second.ToString());

                        string Status_Table_Second = GetValueTableSecond.Status_Table_Second;
                        Console.WriteLine("Status Table Second: " + Status_Table_Second.ToString());

                        string Guid_Create_RequestSupport_Second = GetValueTableSecond.Guid_Create_Request_Support_Second;
                        if (!string.IsNullOrEmpty(Guid_Create_RequestSupport_Second))
                        {
                            Console.WriteLine("Guid Create RequestSupport Second: " + Guid_Create_RequestSupport_Second.ToString());
                        }

                        entity["new_tittletablesecond"] = Tittle_Table_Second;
                        entity["new_servicetablesecond"] = Service_Table_Second;
                        entity["new_discriptiontablesecond"] = Discription_Table_Second;
                        entity["new_createontablesecond"] = CreateOn_Table_Second;
                        entity["new_guidtablesecond"] = Guid_Create_RequestSupport_Second;
                        entity["new_statustablesecond"] = Status_Table_Second;
                        entity["new_guidcreaterequestsupportsecond"] = Guid_Create_RequestSupport_Second;
                        orgService_Demo.Update(entity);
                        Console.WriteLine("************ End ************ Get Value Table Second ***************");

                        //Get case values create in CRM
                        try
                        {
                            Guid GuidRecordCase = new Guid(Guid_CustomerService);
                            string Value_ticketsubjects = GetRandomticketsubject.CustomerService.ToString().Trim();

                            Incident_Case incidentCaseInstance = new Incident_Case();

                            List<ModelCaseCRM> incidentData = incidentCaseInstance.GetIncidentCase_B2C(GuidRecordCase, Value_ticketsubjects);
                            if (incidentData != null && incidentData.Count > 0)
                            {
                                foreach (var data in incidentData)
                                {
                                    Console.WriteLine("************ Start ************ Get Value Case CRM ***************" + "\n");
                                    Console.WriteLine($"Title: {data.title_Case}");
                                    Console.WriteLine($"Extraction Title Case: {data.Extraction_title_Case}");
                                    Console.WriteLine($"State Code: {data.statecode_Case}");
                                    Console.WriteLine($"Status Code: {data.statuscode_Case}");
                                    Console.WriteLine($"Ticket Number: {data.ticketNumber_Case}");
                                    Console.WriteLine($"Customer Service: {data.customerService_Case}");
                                    Console.WriteLine($"Ticket Department: {data.ticketDepartemant_Case}");
                                    Console.WriteLine($"Ticket Subject: {data.ticketsubject_Case}");
                                    Console.WriteLine($"Ticket Subject B2C: {data.subjectid_case}");
                                    Console.WriteLine($"Created On: {data.createdon_Case}");
                                    Console.WriteLine($"Guid Case CRM: {data.GetGuidCaseRecord}");
                                    Console.WriteLine("************ End ************ Get Value Case CRM ***************");

                                    if (Tittle_Table_Second == data.Extraction_title_Case)
                                    {
                                        string guidFromSecond = Guid_Create_RequestSupport_Second;
                                        string guidFromData = data.GetGuidCaseRecord.ToString();

                                        if (guidFromSecond == guidFromData)
                                        {
                                            entity["new_titlecase"] = data.Extraction_title_Case;
                                            entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                            entity["new_createdoncase"] = data.createdon_Case;
                                            entity["new_customerservicecase"] = data.customerService_Case;
                                            entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                            entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                            entity["new_subjectcase"] = data.subjectid_case;

                                            if (data.statecode_Case == 0) // Active
                                            {
                                                entity["new_status"] = new OptionSetValue(0);
                                            }
                                            if (data.statecode_Case == 1) // Resolved
                                            {
                                                entity["new_status"] = new OptionSetValue(1);
                                            }
                                            if (data.statecode_Case == 2) // Canceled
                                            {
                                                entity["new_status"] = new OptionSetValue(2);
                                            }


                                            if (data.statuscode_Case == 910340003) // Draft
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(91034003);
                                            }
                                            if (data.statuscode_Case == 1) // InProgress
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(1);
                                            }
                                            if (data.statuscode_Case == 2) // On Hold
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(2);
                                            }
                                            if (data.statuscode_Case == 3) // Wating for Details
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(3);
                                            }
                                            if (data.statuscode_Case == 4) // Resaching
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(4);
                                            }

                                            entity["new_resulttest"] = new OptionSetValue(1);

                                            entity["new_messageresult"] = "Assertion succeeded.";
                                            orgService_Demo.Update(entity);

                                            Assert.Pass("Assertion succeeded.");
                                        }
                                        else
                                        {
                                            entity["new_titlecase"] = data.Extraction_title_Case;
                                            entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                            entity["new_createdoncase"] = data.createdon_Case;
                                            entity["new_customerservicecase"] = data.customerService_Case;
                                            entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                            entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                            entity["new_subjectcase"] = data.subjectid_case;

                                            if (data.statecode_Case == 0) // Active
                                            {
                                                entity["new_status"] = new OptionSetValue(0);
                                            }
                                            if (data.statecode_Case == 1) // Resolved
                                            {
                                                entity["new_status"] = new OptionSetValue(1);
                                            }
                                            if (data.statecode_Case == 2) // Canceled
                                            {
                                                entity["new_status"] = new OptionSetValue(2);
                                            }


                                            if (data.statuscode_Case == 910340003) // Draft
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(91034003);
                                            }
                                            if (data.statuscode_Case == 1) // InProgress
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(1);
                                            }
                                            if (data.statuscode_Case == 2) // On Hold
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(2);
                                            }
                                            if (data.statuscode_Case == 3) // Wating for Details
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(3);
                                            }
                                            if (data.statuscode_Case == 4) // Resaching
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(4);
                                            }

                                            entity["new_resulttest"] = new OptionSetValue(2);
                                            entity["new_messageresult"] = "Guid_Create_RequestSupport_Second does not match data.GetGuidCaseRecord.";
                                            orgService_Demo.Update(entity);

                                            Assert.Fail("Guid_Create_RequestSupport_Second does not match data.GetGuidCaseRecord.");
                                        }
                                    }
                                    else
                                    {
                                        entity["new_titlecase"] = data.Extraction_title_Case;
                                        entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                        entity["new_createdoncase"] = data.createdon_Case;
                                        entity["new_customerservicecase"] = data.customerService_Case;
                                        entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                        entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                        entity["new_subjectcase"] = data.subjectid_case;

                                        if (data.statecode_Case == 0) // Active
                                        {
                                            entity["new_status"] = new OptionSetValue(0);
                                        }
                                        if (data.statecode_Case == 1) // Resolved
                                        {
                                            entity["new_status"] = new OptionSetValue(1);
                                        }
                                        if (data.statecode_Case == 2) // Canceled
                                        {
                                            entity["new_status"] = new OptionSetValue(2);
                                        }


                                        if (data.statuscode_Case == 910340003) // Draft
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(91034003);
                                        }
                                        if (data.statuscode_Case == 1) // InProgress
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(1);
                                        }
                                        if (data.statuscode_Case == 2) // On Hold
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(2);
                                        }
                                        if (data.statuscode_Case == 3) // Wating for Details
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(3);
                                        }
                                        if (data.statuscode_Case == 4) // Resaching
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(4);
                                        }

                                        entity["new_resulttest"] = new OptionSetValue(2);
                                        entity["new_messageresult"] = "Tittle_Table_Second does not match data.Extraction_title_Case.";
                                        orgService_Demo.Update(entity);

                                        Assert.Fail("Tittle_Table_Second does not match data.Extraction_title_Case.");
                                    }
                                }
                            }
                            else
                            {
                                entity["new_resulttest"] = new OptionSetValue(2);
                                entity["new_messageresult"] = "رکورد ایجادی تکراری می باشد.";
                                orgService_Demo.Update(entity);
                                Console.WriteLine("رکورد ایجادی تکراری می باشد.");
                            }
                        }
                        catch
                        {
                        }
                    }
                    //Faild Request Support
                    else if (element_Faild == Text_Faild_Alert)
                    {
                        Console.WriteLine("پیدا شد: " + Text_Faild_Alert);
                        entity["new_discription"] = Text_Faild_Alert;

                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@href='/ticketing'])[2]"))).Click();

                        var GetValueTableSecond = FunctionRequestSupport_PanelHiweb.GetTableSecondRequestSupport_B2C(driver, wait);
                        string Discription_Table_Second = GetValueTableSecond.Discription_Table_Second;

                        if (Discription_Table_First.ToString() == Discription_Table_Second.ToString())
                        {
                            entity["new_resulttest"] = new OptionSetValue(1);
                            entity["new_messageresult"] = "Assertion succeeded.";
                            orgService_Demo.Update(entity);
                            Assert.Pass("Assertion succeeded.");
                        }
                        else
                        {
                            entity["new_resulttest"] = new OptionSetValue(2);
                            entity["new_messageresult"] = "SupportRequest Record Created";
                            orgService_Demo.Update(entity);
                            Assert.Fail("SupportRequest Record Created");
                        }
                    }
                    else
                    {
                        entity["new_resulttest"] = new OptionSetValue(2);
                        entity["new_messageresult"] = "شما مجاز به ثبت درخواست نمی باشد.";
                        orgService_Demo.Update(entity);
                        Assert.Fail("شما مجاز به ثبت درخواست نمی باشد.");
                    }
                }
            }

















            // ***************************************************************** B2B / Reseller *****************************************************************
            if (data.Type_id == 3 || data.Type_id == 4 || data_Type_CS.Type_id == 3 || data_Type_CS.Type_id == 4)
            {
                actions.SendKeys(Keys.End).Perform();
                IWebElement Buttom_HomePanel_RequestSupport = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//a[@href='/supportticket'])[2]")));
                actions.MoveToElement(Buttom_HomePanel_RequestSupport);
                actions.Perform();
                while (!Buttom_HomePanel_RequestSupport.Enabled)
                {
                    actions.MoveToElement(Buttom_HomePanel_RequestSupport);
                    actions.Perform();
                    Thread.Sleep(1000);
                }
                Buttom_HomePanel_RequestSupport.Click();

                //Checked Value in Table
                string xpath_Not_Value_Table = "//*[@class='dataTables_empty']";
                string Text_Not_Value_Table = "موردی یافت نشد";

                FunctionRequestSupport_PanelHiweb Checked_Value_in_Table = new FunctionRequestSupport_PanelHiweb();
                string element_Value_Table = Checked_Value_in_Table.FindElementByXPath(xpath_Not_Value_Table, Text_Not_Value_Table, driver);

                if (element_Value_Table == Text_Not_Value_Table)
                {
                    //Create New Record Request_Support
                    IWebElement New_Request_Support_PH = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='btn btn-primary btn-sm collapsed' and @role='button']")));
                    New_Request_Support_PH.Click();

                    var my_variable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@id='CustomerServiceId']"))).Text;
                    Console.WriteLine("Customer Service: " + my_variable);

                    //Start Get Convert_to_list_and_choose_random
                    var GetRandomCustomerService = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(my_variable);

                    IWebElement Select_CustomerService = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//select[@id='CustomerServiceId']/option[{GetRandomCustomerService.IndexCustomerService + 1}][@class='text-center']")));
                    string Guid_CustomerService = Select_CustomerService.GetAttribute("value");
                    Select_CustomerService.Click();
                    Console.WriteLine("Get Random Customer Service: " + GetRandomCustomerService.CustomerService);
                    Console.WriteLine("Get Random iteration: " + GetRandomCustomerService.IndexCustomerService);
                    Thread.Sleep(1000);

                    if (Regex.IsMatch(GetRandomCustomerService.CustomerService, @"ADSL2|LTE|Fiber|Wireless"))
                    {
                        //Get TicketDepartment
                        var TicketDepartment = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='TicketDepartmentId']"))).Text;
                        var GetTicketDepartment = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(TicketDepartment);
                        IWebElement Select_TicketDepartment = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='TicketDepartmentId']/option[{GetTicketDepartment.IndexCustomerService + 1}]")));
                        Select_TicketDepartment.Click();
                        Console.WriteLine("Get Random Ticket Department: " + GetTicketDepartment.CustomerService);
                        Console.WriteLine("Get Random Ticket Department iteration: " + GetTicketDepartment.IndexCustomerService + 1);
                        actions.SendKeys(Keys.End).Perform();
                        Thread.Sleep(2000);

                        //Get ChooseTopic
                        var TicketSubject = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='TicketSubjectId']"))).Text;
                        var GetTicketSubject = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(TicketSubject);
                        IWebElement Select_TicketSubject = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='TicketSubjectId']/option[{GetTicketSubject.IndexCustomerService + 1}]")));
                        Select_TicketSubject.Click();
                        Console.WriteLine("Get Random Ticket Subject: " + GetTicketSubject.CustomerService);
                        Console.WriteLine("Get Random Ticket Subject iteration: " + GetTicketSubject.IndexCustomerService + 1);

                        //Generate GUID Random For Description
                        //FunctionRequestSupport_PanelHiweb RandomSeleniumGuid = new FunctionRequestSupport_PanelHiweb();
                        //string randomGuid = RandomSeleniumGuid.GenerateRandomGuid();

                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='Description']"))).SendKeys(GetRandomCustomerService.CustomerService);
                        Console.WriteLine("Description: " + GetRandomCustomerService.CustomerService);

                        //Upload Random File
                        FunctionRequestSupport_PanelHiweb GetRandomFile = new FunctionRequestSupport_PanelHiweb();
                        List<string> allowedExtensions = new List<string> { ".pdf", ".jpg" };
                        GetRandomFile.UploadRandomFile(driver, allowedExtensions);

                        // Send Data To Server
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//Button[@id='senddata']"))).Click();

                        //Checked Pass or Faild Create Request Support
                        string xpath_Pass_Alert_Create_RS = "//*[@class='alert alert-success']";
                        string xpath_Faild_Alert_Create_RS = "//*[@class='alert alert-danger']";
                        string Text_Pass_Alert = "درخواست پشتیبانی با موفقیت ثبت شد.";
                        string Text_Faild_Alert = "شما یک درخواست پشتیبانی باز با موضوع انتخاب شده برای سرویس انتخاب شده دارید. امکان ایجاد درخواست مجدد وجود ندارد.";

                        FunctionRequestSupport_PanelHiweb ElementPassFaild = new FunctionRequestSupport_PanelHiweb();
                        string element_Pass = ElementPassFaild.FindElementByXPath(xpath_Pass_Alert_Create_RS, Text_Pass_Alert, driver);
                        string element_Faild = ElementPassFaild.FindElementByXPath(xpath_Faild_Alert_Create_RS, Text_Faild_Alert, driver);

                        Guid GuidCS = new Guid(Guid_CustomerService);

                        Ritrive_CustomerService ritrive_CustomerService = new Ritrive_CustomerService();
                        List<ModelContact_Account_Service_CRM> ritrive_CS = ritrive_CustomerService.CustomerService(GuidCS);

                        if (ritrive_CS != null && ritrive_CS.Count > 0)
                        {
                            foreach (var data_FcpProvider in ritrive_CS)
                            {
                                if (data_FcpProvider.FcpProvider_Guid == new Guid("AF55450B-5597-EA11-9C12-00505681AE19"))
                                {
                                    entity["new_fcpprovider"] = new OptionSetValue(1);
                                }
                                if (data_FcpProvider.FcpProvider_Guid == new Guid("E7E69611-5597-EA11-9C12-00505681AE19"))
                                {
                                    entity["new_fcpprovider"] = new OptionSetValue(2);
                                }
                            }
                            orgService_Demo.Update(entity);
                        }

                        // Pass Request Support
                        if (element_Pass == Text_Pass_Alert)
                        {
                            Console.WriteLine($"پیدا شد: {Text_Pass_Alert}");
                            entity["new_discription"] = Text_Pass_Alert;

                            //Get Table Value Second Request Support
                            var GetValueTableSecond = FunctionRequestSupport_PanelHiweb.GetTableSecondRequestSupport_B2B(driver, wait);
                            string Tittle_Table_Second = GetValueTableSecond.Tittle_Table_Second;
                            Console.WriteLine("Tittle Table Second: " + Tittle_Table_Second);
                            string Service_Table_Second = GetValueTableSecond.Service_Table_Second;
                            Console.WriteLine("Service Table Second: " + Service_Table_Second.ToString());
                            string CreateOn_Table_Second = GetValueTableSecond.CreateOn_Table_Second;
                            Console.WriteLine("CreateOn Table Second: " + CreateOn_Table_Second.ToString());
                            string TrackingCode_Table_Second = GetValueTableSecond.TrackingCode_Table_Second;
                            Console.WriteLine("TrackingCode Table Second: " + TrackingCode_Table_Second.ToString());
                            string Status_Table_Second = GetValueTableSecond.Status_Table_Second;
                            Console.WriteLine("Status Table Second: " + Status_Table_Second.ToString());
                            string Guid_Table_Second = GetValueTableSecond.Guid_Table_Second;
                            Console.WriteLine("Guid Table First: " + Guid_Table_Second.ToString());

                            var ExtractGuid_Second = FunctionRequestSupport_PanelHiweb.ExtractGuidFromTable(Guid_Table_Second);
                            if (ExtractGuid_Second != null)
                            {
                                Console.WriteLine("Extracted Guid: " + ExtractGuid_Second);
                            }
                            //Guid Request Support
                            Guid GuidRecordCase = new Guid(ExtractGuid_Second);

                            entity["new_tittletablesecond"] = Tittle_Table_Second;
                            entity["new_servicetablesecond"] = Service_Table_Second;
                            entity["new_createontablesecond"] = CreateOn_Table_Second;
                            entity["new_trackingcodetablesecond"] = TrackingCode_Table_Second;
                            entity["new_statustablesecond"] = Status_Table_Second;
                            entity["new_guidtablesecond"] = Guid_Table_Second;
                            entity["new_guidtablesecond"] = ExtractGuid_Second;
                            orgService_Demo.Update(entity);

                            //Get case values create in CRM
                            Incident_Case incidentCaseInstance = new Incident_Case();
                            List<ModelCaseCRM> incidentData = incidentCaseInstance.GetIncidentCase_B2B(GuidRecordCase);
                            if (incidentData != null && incidentData.Count > 0)
                            {
                                foreach (var data in incidentData)
                                {
                                    Console.WriteLine($"Title: {data.title_Case}");
                                    Console.WriteLine($"State Code: {data.statecode_Case}");
                                    Console.WriteLine($"Status Code: {data.statuscode_Case}");
                                    Console.WriteLine($"Ticket Number: {data.ticketNumber_Case}");
                                    Console.WriteLine($"Customer Service: {data.customerService_Case}");
                                    Console.WriteLine($"Ticket Department: {data.ticketDepartemant_Case}");
                                    Console.WriteLine($"Ticket Subject: {data.ticketsubject_Case}");
                                    Console.WriteLine($"Created On: {data.createdon_Case}");

                                    // Assertion
                                    if (GetTicketDepartment.CustomerService == data.ticketDepartemant_Case && Service_Table_Second == data.customerService_Case)
                                    {
                                        if (TrackingCode_Table_Second.ToString() == data.ticketDepartemant_Case)
                                        {
                                            entity["new_titlecase"] = data.title_Case;
                                            entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                            entity["new_createdoncase"] = data.createdon_Case;
                                            entity["new_customerservicecase"] = data.customerService_Case;
                                            entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                            entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                            entity["new_subjectcase"] = data.subjectid_case;

                                            if (data.statecode_Case == 0) // Active
                                            {
                                                entity["new_status"] = new OptionSetValue(0);
                                            }
                                            if (data.statecode_Case == 1) // Resolved
                                            {
                                                entity["new_status"] = new OptionSetValue(1);
                                            }
                                            if (data.statecode_Case == 2) // Canceled
                                            {
                                                entity["new_status"] = new OptionSetValue(2);
                                            }


                                            if (data.statuscode_Case == 910340003) // Draft
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(91034003);
                                            }
                                            if (data.statuscode_Case == 1) // InProgress
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(1);
                                            }
                                            if (data.statuscode_Case == 2) // On Hold
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(2);
                                            }
                                            if (data.statuscode_Case == 3) // Wating for Details
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(3);
                                            }
                                            if (data.statuscode_Case == 4) // Resaching
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(4);
                                            }

                                            entity["new_resulttest"] = new OptionSetValue(1);

                                            entity["new_messageresult"] = "Assertion succeeded.";
                                            orgService_Demo.Update(entity);

                                            Assert.Pass("Assertion succeeded.");
                                        }
                                        else
                                        {
                                            entity["new_titlecase"] = data.title_Case;
                                            entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                            entity["new_createdoncase"] = data.createdon_Case;
                                            entity["new_customerservicecase"] = data.customerService_Case;
                                            entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                            entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                            entity["new_subjectcase"] = data.subjectid_case;

                                            if (data.statecode_Case == 0) // Active
                                            {
                                                entity["new_status"] = new OptionSetValue(0);
                                            }
                                            if (data.statecode_Case == 1) // Resolved
                                            {
                                                entity["new_status"] = new OptionSetValue(1);
                                            }
                                            if (data.statecode_Case == 2) // Canceled
                                            {
                                                entity["new_status"] = new OptionSetValue(2);
                                            }


                                            if (data.statuscode_Case == 910340003) // Draft
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(91034003);
                                            }
                                            if (data.statuscode_Case == 1) // InProgress
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(1);
                                            }
                                            if (data.statuscode_Case == 2) // On Hold
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(2);
                                            }
                                            if (data.statuscode_Case == 3) // Wating for Details
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(3);
                                            }
                                            if (data.statuscode_Case == 4) // Resaching
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(4);
                                            }

                                            entity["new_resulttest"] = new OptionSetValue(2);
                                            entity["new_messageresult"] = "TrackingCode_Table_First does match TrackingCode_Table_Second.";
                                            orgService_Demo.Update(entity);

                                            Assert.Fail("TrackingCode_Table_First does match TrackingCode_Table_Second.");
                                        }
                                    }
                                    else
                                    {
                                        entity["new_titlecase"] = data.title_Case;
                                        entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                        entity["new_createdoncase"] = data.createdon_Case;
                                        entity["new_customerservicecase"] = data.customerService_Case;
                                        entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                        entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                        entity["new_subjectcase"] = data.subjectid_case;

                                        if (data.statecode_Case == 0) // Active
                                        {
                                            entity["new_status"] = new OptionSetValue(0);
                                        }
                                        if (data.statecode_Case == 1) // Resolved
                                        {
                                            entity["new_status"] = new OptionSetValue(1);
                                        }
                                        if (data.statecode_Case == 2) // Canceled
                                        {
                                            entity["new_status"] = new OptionSetValue(2);
                                        }


                                        if (data.statuscode_Case == 910340003) // Draft
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(91034003);
                                        }
                                        if (data.statuscode_Case == 1) // InProgress
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(1);
                                        }
                                        if (data.statuscode_Case == 2) // On Hold
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(2);
                                        }
                                        if (data.statuscode_Case == 3) // Wating for Details
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(3);
                                        }
                                        if (data.statuscode_Case == 4) // Resaching
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(4);
                                        }

                                        entity["new_resulttest"] = new OptionSetValue(2);
                                        entity["new_messageresult"] = "GetTicketDepartment.CustomerService == data.ticketDepartemant_Case && Service_Table_Second == data.customerService_Case (does not match)";
                                        orgService_Demo.Update(entity);

                                        Assert.Fail("GetTicketDepartment.CustomerService == data.ticketDepartemant_Case && Service_Table_Second == data.customerService_Case (does not match)");
                                    }
                                }
                            }
                            else
                            {
                                entity["new_resulttest"] = new OptionSetValue(2);
                                entity["new_messageresult"] = "رکورد ایجادی تکراری می باشد.";
                                orgService_Demo.Update(entity);
                                Assert.Fail("رکورد ایجادی تکراری می باشد.");
                            }
                        }
                        //Faild Request Support
                        else if (element_Faild == Text_Faild_Alert)
                        {
                            Console.WriteLine("پیدا شد: " + Text_Faild_Alert);
                            entity["new_discription"] = Text_Faild_Alert;
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@href='/supportticket'])[2]"))).Click();

                            // بپرسم از امیرحسین
                            var GetValueTableSecond = FunctionRequestSupport_PanelHiweb.GetTableSecondRequestSupport_B2B(driver, wait);
                            string TrackingCode_Table_Second = GetValueTableSecond.TrackingCode_Table_Second;

                            if (TrackingCode_Table_Second != null)
                            {
                                entity["new_resulttest"] = new OptionSetValue(1);
                                entity["new_messageresult"] = "Assertion succeeded.";
                                orgService_Demo.Update(entity);
                                Assert.Pass("Assertion succeeded.");
                            }
                            else
                            {
                                entity["new_resulttest"] = new OptionSetValue(2);
                                entity["new_messageresult"] = "SupportRequest Record Created";
                                orgService_Demo.Update(entity);
                                Assert.Fail("SupportRequest Record Created");
                            }
                        }
                        else
                        {
                            entity["new_resulttest"] = new OptionSetValue(2);
                            entity["new_messageresult"] = "شما مجاز به ثبت درخواست نمی باشد.";
                            orgService_Demo.Update(entity);
                            Assert.Fail("شما مجاز به ثبت درخواست نمی باشد.");
                        }
                    }

                    else if (Regex.IsMatch(GetRandomCustomerService.CustomerService, "VPS"))
                    {
                        //Get TicketDepartment
                        var TicketDepartment = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='TicketDepartmentId']"))).Text;
                        var GetTicketDepartment = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(TicketDepartment);
                        IWebElement Select_TicketDepartment = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='TicketDepartmentId']/option[{GetTicketDepartment.IndexCustomerService + 1}]")));
                        Select_TicketDepartment.Click();
                        Console.WriteLine("Get Random Ticket Department: " + GetTicketDepartment.CustomerService);
                        Console.WriteLine("Get Random Ticket Department iteration: " + GetTicketDepartment.IndexCustomerService + 1);
                        actions.SendKeys(Keys.End).Perform();
                        Thread.Sleep(1000);

                        //Get ChooseTopic
                        //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='TicketSubjectId']"))).Click();
                        var TicketSubject = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='TicketSubjectId']"))).Text;
                        var GetTicketSubject = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(TicketSubject);
                        IWebElement Select_TicketSubject = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='TicketSubjectId']/option[{GetTicketSubject.IndexCustomerService + 1}]")));
                        Select_TicketSubject.Click();
                        Console.WriteLine("Get Random Ticket Subject: " + GetTicketSubject.CustomerService);
                        Console.WriteLine("Get Random Ticket Subject iteration: " + GetTicketSubject.IndexCustomerService + 1);

                        //Generate GUID Random For Description
                        //FunctionRequestSupport_PanelHiweb RandomSeleniumGuid = new FunctionRequestSupport_PanelHiweb();
                        //string randomGuid = RandomSeleniumGuid.GenerateRandomGuid();

                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='Description']"))).SendKeys(GetRandomCustomerService.CustomerService);
                        Console.WriteLine("Description:" + GetRandomCustomerService.CustomerService);

                        //Upload Random File
                        FunctionRequestSupport_PanelHiweb GetRandomFile = new FunctionRequestSupport_PanelHiweb();
                        List<string> allowedExtensions = new List<string> { "pdf", "jpg" };
                        GetRandomFile.UploadRandomFile(driver, allowedExtensions);

                        // Send Data To Server
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//Button[@id='senddata']"))).Click();


                        string xpath_Pass_Alert_Create_RS = "//*[@class='alert alert-success']";
                        string xpath_Faild_Alert_Create_RS = "//*[@class='alert alert-danger']";
                        string Text_Pass_Alert = "درخواست پشتیبانی با موفقیت ثبت شد.";
                        string Text_Faild_Alert = "شما یک درخواست پشتیبانی باز با موضوع انتخاب شده برای سرویس انتخاب شده دارید. امکان ایجاد درخواست مجدد وجود ندارد.";

                        FunctionRequestSupport_PanelHiweb ElementPassFaild = new FunctionRequestSupport_PanelHiweb();
                        string element_Pass = ElementPassFaild.FindElementByXPath(xpath_Pass_Alert_Create_RS, Text_Pass_Alert, driver);
                        string element_Faild = ElementPassFaild.FindElementByXPath(xpath_Faild_Alert_Create_RS, Text_Faild_Alert, driver);

                        Guid GuidCS = new Guid(Guid_CustomerService);

                        Ritrive_CustomerService ritrive_CustomerService = new Ritrive_CustomerService();
                        List<ModelContact_Account_Service_CRM> ritrive_CS = ritrive_CustomerService.CustomerService(GuidCS);

                        if (ritrive_CS != null && ritrive_CS.Count > 0)
                        {
                            foreach (var data_FcpProvider in ritrive_CS)
                            {
                                if (data_FcpProvider.FcpProvider_Guid == new Guid("AF55450B-5597-EA11-9C12-00505681AE19"))
                                {
                                    entity["new_fcpprovider"] = new OptionSetValue(1);
                                }
                                if (data_FcpProvider.FcpProvider_Guid == new Guid("E7E69611-5597-EA11-9C12-00505681AE19"))
                                {
                                    entity["new_fcpprovider"] = new OptionSetValue(2);
                                }
                            }
                            orgService_Demo.Update(entity);
                        }

                        //Pass Request Support
                        if (element_Pass == Text_Pass_Alert)
                        {
                            Console.WriteLine($"پیدا شد: {Text_Pass_Alert}");
                            entity["new_discription"] = Text_Pass_Alert;

                            //Get Table Value Second Request Support
                            var GetValueTableSecond = FunctionRequestSupport_PanelHiweb.GetTableSecondRequestSupport_B2B(driver, wait);
                            string Tittle_Table_Second = GetValueTableSecond.Tittle_Table_Second;
                            Console.WriteLine("Tittle Table Second: " + Tittle_Table_Second);
                            string Service_Table_Second = GetValueTableSecond.Service_Table_Second;
                            Console.WriteLine("Service Table Second: " + Service_Table_Second.ToString());
                            string CreateOn_Table_Second = GetValueTableSecond.CreateOn_Table_Second;
                            Console.WriteLine("CreateOn Table Second: " + CreateOn_Table_Second.ToString());
                            string TrackingCode_Table_Second = GetValueTableSecond.TrackingCode_Table_Second;
                            Console.WriteLine("TrackingCode Table Second: " + TrackingCode_Table_Second.ToString());
                            string Status_Table_Second = GetValueTableSecond.Status_Table_Second;
                            Console.WriteLine("Status Table Second: " + Status_Table_Second.ToString());
                            string Guid_Table_Second = GetValueTableSecond.Guid_Table_Second;
                            Console.WriteLine("Guid Table First: " + Guid_Table_Second.ToString());

                            var ExtractGuid_Second = FunctionRequestSupport_PanelHiweb.ExtractGuidFromTable(Guid_Table_Second);
                            if (ExtractGuid_Second != null)
                            {
                                Console.WriteLine("Extracted Guid: " + ExtractGuid_Second);
                            }

                            //Guid Request Support
                            Guid GuidRecordCase = new Guid(ExtractGuid_Second);

                            entity["new_tittletablesecond"] = Tittle_Table_Second;
                            entity["new_servicetablesecond"] = Service_Table_Second;
                            entity["new_createontablesecond"] = CreateOn_Table_Second;
                            entity["new_trackingcodetablesecond"] = TrackingCode_Table_Second;
                            entity["new_statustablesecond"] = Status_Table_Second;
                            entity["new_guidtablesecond"] = Guid_Table_Second;
                            entity["new_guidtablesecond"] = ExtractGuid_Second;
                            orgService_Demo.Update(entity);

                            //Get case values create in CRM
                            Incident_Case incidentCaseInstance = new Incident_Case();
                            List<ModelCaseCRM> incidentData = incidentCaseInstance.GetIncidentCase_B2B(GuidRecordCase);
                            if (incidentData != null && incidentData.Count > 0)
                            {
                                foreach (var data in incidentData)
                                {
                                    Console.WriteLine($"Title: {data.title_Case}");
                                    Console.WriteLine($"State Code: {data.statecode_Case}");
                                    Console.WriteLine($"Status Code: {data.statuscode_Case}");
                                    Console.WriteLine($"Ticket Number: {data.ticketNumber_Case}");
                                    Console.WriteLine($"Customer Service: {data.customerService_Case}");
                                    Console.WriteLine($"Ticket Department: {data.ticketDepartemant_Case}");
                                    Console.WriteLine($"Ticket Subject: {data.ticketsubject_Case}");
                                    Console.WriteLine($"Created On: {data.createdon_Case}");


                                    // Assertion
                                    if (GetTicketDepartment.CustomerService == data.ticketDepartemant_Case && Service_Table_Second == data.customerService_Case)
                                    {
                                        if (TrackingCode_Table_Second.ToString() == data.ticketDepartemant_Case)
                                        {
                                            entity["new_titlecase"] = data.title_Case;
                                            entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                            entity["new_createdoncase"] = data.createdon_Case;
                                            entity["new_customerservicecase"] = data.customerService_Case;
                                            entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                            entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                            entity["new_subjectcase"] = data.subjectid_case;

                                            if (data.statecode_Case == 0) // Active
                                            {
                                                entity["new_status"] = new OptionSetValue(0);
                                            }
                                            if (data.statecode_Case == 1) // Resolved
                                            {
                                                entity["new_status"] = new OptionSetValue(1);
                                            }
                                            if (data.statecode_Case == 2) // Canceled
                                            {
                                                entity["new_status"] = new OptionSetValue(2);
                                            }


                                            if (data.statuscode_Case == 910340003) // Draft
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(91034003);
                                            }
                                            if (data.statuscode_Case == 1) // InProgress
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(1);
                                            }
                                            if (data.statuscode_Case == 2) // On Hold
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(2);
                                            }
                                            if (data.statuscode_Case == 3) // Wating for Details
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(3);
                                            }
                                            if (data.statuscode_Case == 4) // Resaching
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(4);
                                            }

                                            entity["new_resulttest"] = new OptionSetValue(1);

                                            entity["new_messageresult"] = "Assertion succeeded.";
                                            orgService_Demo.Update(entity);

                                            Assert.Pass("Assertion succeeded.");
                                        }
                                        else
                                        {
                                            entity["new_titlecase"] = data.title_Case;
                                            entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                            entity["new_createdoncase"] = data.createdon_Case;
                                            entity["new_customerservicecase"] = data.customerService_Case;
                                            entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                            entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                            entity["new_subjectcase"] = data.subjectid_case;

                                            if (data.statecode_Case == 0) // Active
                                            {
                                                entity["new_status"] = new OptionSetValue(0);
                                            }
                                            if (data.statecode_Case == 1) // Resolved
                                            {
                                                entity["new_status"] = new OptionSetValue(1);
                                            }
                                            if (data.statecode_Case == 2) // Canceled
                                            {
                                                entity["new_status"] = new OptionSetValue(2);
                                            }


                                            if (data.statuscode_Case == 910340003) // Draft
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(91034003);
                                            }
                                            if (data.statuscode_Case == 1) // InProgress
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(1);
                                            }
                                            if (data.statuscode_Case == 2) // On Hold
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(2);
                                            }
                                            if (data.statuscode_Case == 3) // Wating for Details
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(3);
                                            }
                                            if (data.statuscode_Case == 4) // Resaching
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(4);
                                            }

                                            entity["new_resulttest"] = new OptionSetValue(2);
                                            entity["new_messageresult"] = "TrackingCode_Table_First does match TrackingCode_Table_Second.";
                                            orgService_Demo.Update(entity);

                                            Assert.Fail("TrackingCode_Table_First does match TrackingCode_Table_Second.");
                                        }

                                    }
                                    else
                                    {
                                        entity["new_titlecase"] = data.title_Case;
                                        entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                        entity["new_createdoncase"] = data.createdon_Case;
                                        entity["new_customerservicecase"] = data.customerService_Case;
                                        entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                        entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                        entity["new_subjectcase"] = data.subjectid_case;

                                        if (data.statecode_Case == 0) // Active
                                        {
                                            entity["new_status"] = new OptionSetValue(0);
                                        }
                                        if (data.statecode_Case == 1) // Resolved
                                        {
                                            entity["new_status"] = new OptionSetValue(1);
                                        }
                                        if (data.statecode_Case == 2) // Canceled
                                        {
                                            entity["new_status"] = new OptionSetValue(2);
                                        }


                                        if (data.statuscode_Case == 910340003) // Draft
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(91034003);
                                        }
                                        if (data.statuscode_Case == 1) // InProgress
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(1);
                                        }
                                        if (data.statuscode_Case == 2) // On Hold
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(2);
                                        }
                                        if (data.statuscode_Case == 3) // Wating for Details
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(3);
                                        }
                                        if (data.statuscode_Case == 4) // Resaching
                                        {
                                            entity["new_statusreason"] = new OptionSetValue(4);
                                        }

                                        entity["new_resulttest"] = new OptionSetValue(2);
                                        entity["new_messageresult"] = "GetTicketDepartment.CustomerService == data.ticketDepartemant_Case && Service_Table_Second == data.customerService_Case (does not match)";
                                        orgService_Demo.Update(entity);

                                        Assert.Fail("GetTicketDepartment.CustomerService == data.ticketDepartemant_Case && Service_Table_Second == data.customerService_Case (does not match)");
                                    }
                                }
                            }
                            else
                            {
                                entity["new_resulttest"] = new OptionSetValue(2);
                                entity["new_messageresult"] = "رکورد ایجادی تکراری می باشد.";
                                orgService_Demo.Update(entity);
                                Assert.Fail("رکورد ایجادی تکراری می باشد.");
                            }
                        }
                        //Faild Request Support
                        else if (element_Faild == Text_Faild_Alert)
                        {
                            Console.WriteLine("پیدا شد: " + Text_Faild_Alert);
                            entity["new_discription"] = Text_Faild_Alert;

                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@href='/supportticket'])[2]"))).Click();

                            // بپرسم از امیرحسین
                            var GetValueTableSecond = FunctionRequestSupport_PanelHiweb.GetTableSecondRequestSupport_B2B(driver, wait);
                            string TrackingCode_Table_Second = GetValueTableSecond.TrackingCode_Table_Second;

                            if (TrackingCode_Table_Second != null)
                            {
                                entity["new_resulttest"] = new OptionSetValue(1);
                                entity["new_messageresult"] = "Assertion succeeded.";
                                orgService_Demo.Update(entity);
                                Assert.Pass("Assertion succeeded.");
                            }
                            else
                            {
                                entity["new_resulttest"] = new OptionSetValue(2);
                                entity["new_messageresult"] = "SupportRequest Record Created";
                                orgService_Demo.Update(entity);
                                Assert.Fail("SupportRequest Record Created");
                            }
                        }
                        else
                        {
                            entity["new_resulttest"] = new OptionSetValue(2);
                            entity["new_messageresult"] = "شما مجاز به ثبت درخواست نمی باشد.";
                            orgService_Demo.Update(entity);
                            Assert.Fail("شما مجاز به ثبت درخواست نمی باشد.");
                        }
                    }
                }
                else if (element_Value_Table == null)
                {
                    //Get Table Value First Request Support
                    var GetValueTableFirst = FunctionRequestSupport_PanelHiweb.GetTableFirstRequestSupport_B2B(driver, wait);
                    string Tittle_Table_First = GetValueTableFirst.Tittle_Table_First;
                    Console.WriteLine("Tittle Table First: " + Tittle_Table_First);
                    string Service_Table_First = GetValueTableFirst.Service_Table_First;
                    Console.WriteLine("Service Table First: " + Service_Table_First.ToString());
                    string CreateOn_Table_First = GetValueTableFirst.CreateOn_Table_First;
                    Console.WriteLine("CreateOn Table First: " + CreateOn_Table_First.ToString());
                    string TrackingCode_Table_First = GetValueTableFirst.TrackingCode_Table_First;
                    Console.WriteLine("TrackingCode Table First: " + TrackingCode_Table_First.ToString());
                    string Status_Table_First = GetValueTableFirst.Status_Table_First;
                    Console.WriteLine("Status Table First: " + Status_Table_First.ToString());
                    string Guid_Table_First = GetValueTableFirst.Guid_Table_First;
                    Console.WriteLine("Guid Table First: " + Guid_Table_First.ToString());

                    var ExtractGuid_First = FunctionRequestSupport_PanelHiweb.ExtractGuidFromTable(Guid_Table_First);

                    if (ExtractGuid_First != null)
                    {
                        Console.WriteLine("Extracted Guid: " + ExtractGuid_First);
                    }
                    entity["new_tittletablefirst"] = Tittle_Table_First;
                    entity["new_servicetablefirst"] = Service_Table_First;
                    entity["new_createontablefirst"] = CreateOn_Table_First;
                    entity["new_trackingcodetablefirst"] = TrackingCode_Table_First;
                    entity["new_statustablefirst"] = Status_Table_First;
                    entity["new_guidtablefirst"] = Guid_Table_First;
                    entity["new_extractguidtablefirst"] = ExtractGuid_First;
                    orgService_Demo.Update(entity);
                    //Create New Record Request_Support
                    IWebElement New_Request_Support_PH = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='btn btn-primary btn-sm collapsed' and @role='button']")));
                    New_Request_Support_PH.Click();

                    var my_variable = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@id='CustomerServiceId']"))).Text;
                    Console.WriteLine("Customer Service: " + my_variable);

                    //Start Get Convert_to_list_and_choose_random
                    var GetRandomCustomerService = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(my_variable);

                    IWebElement Select_CustomerService = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//select[@id='CustomerServiceId']/option[{GetRandomCustomerService.IndexCustomerService + 1}][@class='text-center']")));
                    string Guid_CustomerService = Select_CustomerService.GetAttribute("value");
                    Select_CustomerService.Click();
                    Console.WriteLine("Get Random Customer Service: " + GetRandomCustomerService.CustomerService);
                    Console.WriteLine("Get Random iteration: " + GetRandomCustomerService.IndexCustomerService);
                    Thread.Sleep(1000);

                    if (Regex.IsMatch(GetRandomCustomerService.CustomerService, @"ADSL2|LTE|Fiber|Wireless"))
                    {
                        //Get TicketDepartment
                        var TicketDepartment = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='TicketDepartmentId']"))).Text;
                        var GetTicketDepartment = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(TicketDepartment);
                        IWebElement Select_TicketDepartment = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='TicketDepartmentId']/option[{GetTicketDepartment.IndexCustomerService + 1}]")));
                        Select_TicketDepartment.Click();
                        Console.WriteLine("Get Random Ticket Department: " + GetTicketDepartment.CustomerService);
                        Console.WriteLine("Get Random Ticket Department iteration: " + GetTicketDepartment.IndexCustomerService + 1);
                        actions.SendKeys(Keys.End).Perform();
                        Thread.Sleep(2000);

                        //Get ChooseTopic
                        var TicketSubject = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='TicketSubjectId']"))).Text;
                        var GetTicketSubject = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(TicketSubject);
                        IWebElement Select_TicketSubject = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='TicketSubjectId']/option[{GetTicketSubject.IndexCustomerService + 1}]")));
                        Select_TicketSubject.Click();
                        Console.WriteLine("Get Random Ticket Subject: " + GetTicketSubject.CustomerService);
                        Console.WriteLine("Get Random Ticket Subject iteration: " + GetTicketSubject.IndexCustomerService + 1);

                        //Generate GUID Random For Description
                        //FunctionRequestSupport_PanelHiweb RandomSeleniumGuid = new FunctionRequestSupport_PanelHiweb();
                        //string randomGuid = RandomSeleniumGuid.GenerateRandomGuid();

                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='Description']"))).SendKeys("Guid First Record Table: " + ExtractGuid_First + "\n" + GetRandomCustomerService.CustomerService);
                        Console.WriteLine("Description: Guid First Record Table = " + "\n" + ExtractGuid_First + "\n" + GetRandomCustomerService.CustomerService);

                        //Upload Random File
                        FunctionRequestSupport_PanelHiweb GetRandomFile = new FunctionRequestSupport_PanelHiweb();
                        List<string> allowedExtensions = new List<string> { ".pdf", ".jpg" };
                        GetRandomFile.UploadRandomFile(driver, allowedExtensions);

                        // Send Data To Server
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//Button[@id='senddata']"))).Click();

                        //Checked Pass or Faild Create Request Support
                        string xpath_Pass_Alert_Create_RS = "//*[@class='alert alert-success']";
                        string xpath_Faild_Alert_Create_RS = "//*[@class='alert alert-danger']";
                        string Text_Pass_Alert = "درخواست پشتیبانی با موفقیت ثبت شد.";
                        string Text_Faild_Alert = "شما یک درخواست پشتیبانی باز با موضوع انتخاب شده برای سرویس انتخاب شده دارید. امکان ایجاد درخواست مجدد وجود ندارد.";

                        FunctionRequestSupport_PanelHiweb ElementPassFaild = new FunctionRequestSupport_PanelHiweb();
                        string element_Pass = ElementPassFaild.FindElementByXPath(xpath_Pass_Alert_Create_RS, Text_Pass_Alert, driver);
                        string element_Faild = ElementPassFaild.FindElementByXPath(xpath_Faild_Alert_Create_RS, Text_Faild_Alert, driver);

                        Guid GuidCS = new Guid(Guid_CustomerService);

                        Ritrive_CustomerService ritrive_CustomerService = new Ritrive_CustomerService();
                        List<ModelContact_Account_Service_CRM> ritrive_CS = ritrive_CustomerService.CustomerService(GuidCS);

                        if (ritrive_CS != null && ritrive_CS.Count > 0)
                        {
                            foreach (var data_FcpProvider in ritrive_CS)
                            {
                                if (data_FcpProvider.FcpProvider_Guid == new Guid("AF55450B-5597-EA11-9C12-00505681AE19"))
                                {
                                    entity["new_fcpprovider"] = new OptionSetValue(1);
                                }
                                if (data_FcpProvider.FcpProvider_Guid == new Guid("E7E69611-5597-EA11-9C12-00505681AE19"))
                                {
                                    entity["new_fcpprovider"] = new OptionSetValue(2);
                                }
                            }
                            orgService_Demo.Update(entity);
                        }

                        // Pass Request Support
                        if (element_Pass == Text_Pass_Alert)
                        {
                            Console.WriteLine($"پیدا شد: {Text_Pass_Alert}");
                            entity["new_discription"] = Text_Pass_Alert;

                            //Get Table Value Second Request Support
                            var GetValueTableSecond = FunctionRequestSupport_PanelHiweb.GetTableSecondRequestSupport_B2B(driver, wait);
                            string Tittle_Table_Second = GetValueTableSecond.Tittle_Table_Second;
                            Console.WriteLine("Tittle Table Second: " + Tittle_Table_Second);
                            string Service_Table_Second = GetValueTableSecond.Service_Table_Second;
                            Console.WriteLine("Service Table Second: " + Service_Table_Second.ToString());
                            string CreateOn_Table_Second = GetValueTableSecond.CreateOn_Table_Second;
                            Console.WriteLine("CreateOn Table Second: " + CreateOn_Table_Second.ToString());
                            string TrackingCode_Table_Second = GetValueTableSecond.TrackingCode_Table_Second;
                            Console.WriteLine("TrackingCode Table Second: " + TrackingCode_Table_Second.ToString());
                            string Status_Table_Second = GetValueTableSecond.Status_Table_Second;
                            Console.WriteLine("Status Table Second: " + Status_Table_Second.ToString());
                            string Guid_Table_Second = GetValueTableSecond.Guid_Table_Second;
                            Console.WriteLine("Guid Table First: " + Guid_Table_Second.ToString());

                            var ExtractGuid_Second = FunctionRequestSupport_PanelHiweb.ExtractGuidFromTable(Guid_Table_Second);
                            if (ExtractGuid_Second != null)
                            {
                                Console.WriteLine("Extracted Guid: " + ExtractGuid_Second);
                            }

                            entity["new_tittletablesecond"] = Tittle_Table_Second;
                            entity["new_servicetablesecond"] = Service_Table_Second;
                            entity["new_createontablesecond"] = CreateOn_Table_Second;
                            entity["new_trackingcodetablesecond"] = TrackingCode_Table_Second;
                            entity["new_statustablesecond"] = Status_Table_Second;
                            entity["new_guidtablesecond"] = Guid_Table_Second;
                            entity["new_extractguidtablesecond"] = ExtractGuid_Second;

                            if (ExtractGuid_First != ExtractGuid_Second)
                            {
                                //Guid Request Support
                                Guid GuidRecordCase = new Guid(ExtractGuid_Second);

                                //Get case values create in CRM
                                Incident_Case incidentCaseInstance = new Incident_Case();
                                List<ModelCaseCRM> incidentData = incidentCaseInstance.GetIncidentCase_B2B(GuidRecordCase);
                                if (incidentData != null && incidentData.Count > 0)
                                {
                                    foreach (var data in incidentData)
                                    {
                                        Console.WriteLine($"Title: {data.title_Case}");
                                        Console.WriteLine($"State Code: {data.statecode_Case}");
                                        Console.WriteLine($"Status Code: {data.statuscode_Case}");
                                        Console.WriteLine($"Ticket Number: {data.ticketNumber_Case}");
                                        Console.WriteLine($"Customer Service: {data.customerService_Case}");
                                        Console.WriteLine($"Ticket Department: {data.ticketDepartemant_Case}");
                                        Console.WriteLine($"Ticket Subject: {data.ticketsubject_Case}");
                                        Console.WriteLine($"Created On: {data.createdon_Case}");

                                        // Assertion
                                        if (ExtractGuid_First != ExtractGuid_Second && GetTicketDepartment.CustomerService == data.ticketDepartemant_Case && Service_Table_Second == data.customerService_Case)
                                        {
                                            if (TrackingCode_Table_First.ToString() != TrackingCode_Table_Second.ToString())
                                            {
                                                entity["new_titlecase"] = data.title_Case;
                                                entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                                entity["new_createdoncase"] = data.createdon_Case;
                                                entity["new_customerservicecase"] = data.customerService_Case;
                                                entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                                entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                                entity["new_subjectcase"] = data.subjectid_case;

                                                if (data.statecode_Case == 0) // Active
                                                {
                                                    entity["new_status"] = new OptionSetValue(0);
                                                }
                                                if (data.statecode_Case == 1) // Resolved
                                                {
                                                    entity["new_status"] = new OptionSetValue(1);
                                                }
                                                if (data.statecode_Case == 2) // Canceled
                                                {
                                                    entity["new_status"] = new OptionSetValue(2);
                                                }


                                                if (data.statuscode_Case == 910340003) // Draft
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(91034003);
                                                }
                                                if (data.statuscode_Case == 1) // InProgress
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(1);
                                                }
                                                if (data.statuscode_Case == 2) // On Hold
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(2);
                                                }
                                                if (data.statuscode_Case == 3) // Wating for Details
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(3);
                                                }
                                                if (data.statuscode_Case == 4) // Resaching
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(4);
                                                }

                                                entity["new_resulttest"] = new OptionSetValue(1);

                                                entity["new_messageresult"] = "Assertion succeeded.";
                                                orgService_Demo.Update(entity);

                                                Assert.Pass("Assertion succeeded.");
                                            }
                                            else
                                            {
                                                entity["new_titlecase"] = data.title_Case;
                                                entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                                entity["new_createdoncase"] = data.createdon_Case;
                                                entity["new_customerservicecase"] = data.customerService_Case;
                                                entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                                entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                                entity["new_subjectcase"] = data.subjectid_case;

                                                if (data.statecode_Case == 0) // Active
                                                {
                                                    entity["new_status"] = new OptionSetValue(0);
                                                }
                                                if (data.statecode_Case == 1) // Resolved
                                                {
                                                    entity["new_status"] = new OptionSetValue(1);
                                                }
                                                if (data.statecode_Case == 2) // Canceled
                                                {
                                                    entity["new_status"] = new OptionSetValue(2);
                                                }


                                                if (data.statuscode_Case == 910340003) // Draft
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(91034003);
                                                }
                                                if (data.statuscode_Case == 1) // InProgress
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(1);
                                                }
                                                if (data.statuscode_Case == 2) // On Hold
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(2);
                                                }
                                                if (data.statuscode_Case == 3) // Wating for Details
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(3);
                                                }
                                                if (data.statuscode_Case == 4) // Resaching
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(4);
                                                }

                                                entity["new_resulttest"] = new OptionSetValue(2);
                                                entity["new_messageresult"] = "TrackingCode_Table_First does match TrackingCode_Table_Second.";

                                                orgService_Demo.Update(entity);
                                                Assert.Fail("TrackingCode_Table_First does match TrackingCode_Table_Second.");
                                            }
                                        }
                                        else
                                        {
                                            entity["new_titlecase"] = data.title_Case;
                                            entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                            entity["new_createdoncase"] = data.createdon_Case;
                                            entity["new_customerservicecase"] = data.customerService_Case;
                                            entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                            entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                            entity["new_subjectcase"] = data.subjectid_case;

                                            if (data.statecode_Case == 0) // Active
                                            {
                                                entity["new_status"] = new OptionSetValue(0);
                                            }
                                            if (data.statecode_Case == 1) // Resolved
                                            {
                                                entity["new_status"] = new OptionSetValue(1);
                                            }
                                            if (data.statecode_Case == 2) // Canceled
                                            {
                                                entity["new_status"] = new OptionSetValue(2);
                                            }


                                            if (data.statuscode_Case == 910340003) // Draft
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(91034003);
                                            }
                                            if (data.statuscode_Case == 1) // InProgress
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(1);
                                            }
                                            if (data.statuscode_Case == 2) // On Hold
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(2);
                                            }
                                            if (data.statuscode_Case == 3) // Wating for Details
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(3);
                                            }
                                            if (data.statuscode_Case == 4) // Resaching
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(4);
                                            }

                                            entity["new_resulttest"] = new OptionSetValue(2);
                                            entity["new_messageresult"] = "ExtractGuid_First != ExtractGuid_Second && GetTicketDepartment.CustomerService == data.ticketDepartemant_Case && Service_Table_Second == data.customerService_Case (does not match)";

                                            orgService_Demo.Update(entity);

                                            Assert.Fail("ExtractGuid_First != ExtractGuid_Second && GetTicketDepartment.CustomerService == data.ticketDepartemant_Case && Service_Table_Second == data.customerService_Case (does not match)");
                                        }

                                    }
                                }
                                else
                                {
                                    entity["new_resulttest"] = new OptionSetValue(2);
                                    entity["new_messageresult"] = "رکورد ایجادی تکراری می باشد.";
                                    orgService_Demo.Update(entity);
                                    Assert.Fail("رکورد ایجادی تکراری می باشد.");
                                }
                            }
                        }
                        //Faild Request Support
                        else if (element_Faild == Text_Faild_Alert)
                        {
                            Console.WriteLine("پیدا شد: " + Text_Faild_Alert);
                            entity["new_discription"] = Text_Faild_Alert;

                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@href='/supportticket'])[2]"))).Click();

                            // بپرسم از امیرحسین
                            var GetValueTableSecond = FunctionRequestSupport_PanelHiweb.GetTableSecondRequestSupport_B2B(driver, wait);
                            string TrackingCode_Table_Second = GetValueTableSecond.TrackingCode_Table_Second;

                            if (TrackingCode_Table_First == TrackingCode_Table_Second)
                            {
                                entity["new_resulttest"] = new OptionSetValue(1);
                                entity["new_messageresult"] = "Are Equal TrackingCode_Table_First And TrackingCode_Table_Second";
                                orgService_Demo.Update(entity);
                                Assert.AreEqual(TrackingCode_Table_First, TrackingCode_Table_Second);
                            }
                            else
                            {
                                entity["new_resulttest"] = new OptionSetValue(2);
                                entity["new_messageresult"] = "SupportRequest Record Created";
                                orgService_Demo.Update(entity);
                                Assert.Fail("SupportRequest Record Created");
                            }
                        }
                        else
                        {
                            entity["new_resulttest"] = new OptionSetValue(2);
                            entity["new_messageresult"] = "شما مجاز به ثبت درخواست نمی باشد.";
                            orgService_Demo.Update(entity);
                            Assert.Fail("شما مجاز به ثبت درخواست نمی باشد.");
                        }
                    }

                    else if (Regex.IsMatch(GetRandomCustomerService.CustomerService, "VPS"))
                    {
                        //Get TicketDepartment
                        var TicketDepartment = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='TicketDepartmentId']"))).Text;
                        var GetTicketDepartment = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(TicketDepartment);
                        IWebElement Select_TicketDepartment = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='TicketDepartmentId']/option[{GetTicketDepartment.IndexCustomerService + 1}]")));
                        Select_TicketDepartment.Click();
                        Console.WriteLine("Get Random Ticket Department: " + GetTicketDepartment.CustomerService);
                        Console.WriteLine("Get Random Ticket Department iteration: " + GetTicketDepartment.IndexCustomerService + 1);
                        actions.SendKeys(Keys.End).Perform();
                        Thread.Sleep(1000);

                        //Get ChooseTopic
                        //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='TicketSubjectId']"))).Click();
                        var TicketSubject = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='TicketSubjectId']"))).Text;
                        var GetTicketSubject = FunctionRequestSupport_PanelHiweb.Convert_to_list_and_choose_random(TicketSubject);
                        IWebElement Select_TicketSubject = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='TicketSubjectId']/option[{GetTicketSubject.IndexCustomerService + 1}]")));
                        Select_TicketSubject.Click();
                        Console.WriteLine("Get Random Ticket Subject: " + GetTicketSubject.CustomerService);
                        Console.WriteLine("Get Random Ticket Subject iteration: " + GetTicketSubject.IndexCustomerService + 1);

                        //Generate GUID Random For Description
                        //FunctionRequestSupport_PanelHiweb RandomSeleniumGuid = new FunctionRequestSupport_PanelHiweb();
                        //string randomGuid = RandomSeleniumGuid.GenerateRandomGuid();

                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@id='Description']"))).SendKeys("Guid First Record Table: " + ExtractGuid_First + "\n" + GetRandomCustomerService.CustomerService);
                        Console.WriteLine("Description: Guid First Record Table = " + "\n" + ExtractGuid_First + "\n" + GetRandomCustomerService.CustomerService);

                        //Upload Random File
                        FunctionRequestSupport_PanelHiweb GetRandomFile = new FunctionRequestSupport_PanelHiweb();
                        List<string> allowedExtensions = new List<string> { "pdf", "jpg" };
                        GetRandomFile.UploadRandomFile(driver, allowedExtensions);

                        // Send Data To Server
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//Button[@id='senddata']"))).Click();


                        string xpath_Pass_Alert_Create_RS = "//*[@class='alert alert-success']";
                        string xpath_Faild_Alert_Create_RS = "//*[@class='alert alert-danger']";
                        string Text_Pass_Alert = "درخواست پشتیبانی با موفقیت ثبت شد.";
                        string Text_Faild_Alert = "شما یک درخواست پشتیبانی باز با موضوع انتخاب شده برای سرویس انتخاب شده دارید. امکان ایجاد درخواست مجدد وجود ندارد.";

                        FunctionRequestSupport_PanelHiweb ElementPassFaild = new FunctionRequestSupport_PanelHiweb();
                        string element_Pass = ElementPassFaild.FindElementByXPath(xpath_Pass_Alert_Create_RS, Text_Pass_Alert, driver);
                        string element_Faild = ElementPassFaild.FindElementByXPath(xpath_Faild_Alert_Create_RS, Text_Faild_Alert, driver);

                        Guid GuidCS = new Guid(Guid_CustomerService);

                        Ritrive_CustomerService ritrive_CustomerService = new Ritrive_CustomerService();
                        List<ModelContact_Account_Service_CRM> ritrive_CS = ritrive_CustomerService.CustomerService(GuidCS);

                        if (ritrive_CS != null && ritrive_CS.Count > 0)
                        {
                            foreach (var data_FcpProvider in ritrive_CS)
                            {
                                if (data_FcpProvider.FcpProvider_Guid == new Guid("AF55450B-5597-EA11-9C12-00505681AE19"))
                                {
                                    entity["new_fcpprovider"] = new OptionSetValue(1);
                                }
                                if (data_FcpProvider.FcpProvider_Guid == new Guid("E7E69611-5597-EA11-9C12-00505681AE19"))
                                {
                                    entity["new_fcpprovider"] = new OptionSetValue(2);
                                }
                            }
                            orgService_Demo.Update(entity);
                        }

                        //Pass Request Support
                        if (element_Pass == Text_Pass_Alert)
                        {
                            Console.WriteLine($"پیدا شد: {Text_Pass_Alert}");
                            entity["new_discription"] = Text_Pass_Alert;

                            //Get Table Value Second Request Support
                            var GetValueTableSecond = FunctionRequestSupport_PanelHiweb.GetTableSecondRequestSupport_B2B(driver, wait);
                            string Tittle_Table_Second = GetValueTableSecond.Tittle_Table_Second;
                            Console.WriteLine("Tittle Table Second: " + Tittle_Table_Second);
                            string Service_Table_Second = GetValueTableSecond.Service_Table_Second;
                            Console.WriteLine("Service Table Second: " + Service_Table_Second.ToString());
                            string CreateOn_Table_Second = GetValueTableSecond.CreateOn_Table_Second;
                            Console.WriteLine("CreateOn Table Second: " + CreateOn_Table_Second.ToString());
                            string TrackingCode_Table_Second = GetValueTableSecond.TrackingCode_Table_Second;
                            Console.WriteLine("TrackingCode Table Second: " + TrackingCode_Table_Second.ToString());
                            string Status_Table_Second = GetValueTableSecond.Status_Table_Second;
                            Console.WriteLine("Status Table Second: " + Status_Table_Second.ToString());
                            string Guid_Table_Second = GetValueTableSecond.Guid_Table_Second;
                            Console.WriteLine("Guid Table First: " + Guid_Table_Second.ToString());

                            var ExtractGuid_Second = FunctionRequestSupport_PanelHiweb.ExtractGuidFromTable(Guid_Table_Second);
                            if (ExtractGuid_Second != null)
                            {
                                Console.WriteLine("Extracted Guid: " + ExtractGuid_Second);
                            }

                            entity["new_tittletablesecond"] = Tittle_Table_Second;
                            entity["new_servicetablesecond"] = Service_Table_Second;
                            entity["new_createontablesecond"] = CreateOn_Table_Second;
                            entity["new_trackingcodetablesecond"] = TrackingCode_Table_Second;
                            entity["new_statustablesecond"] = Status_Table_Second;
                            entity["new_extractguidtablesecond"] = ExtractGuid_Second;
                            entity["new_guidtablesecond"] = Guid_Table_Second;

                            if (ExtractGuid_First != ExtractGuid_Second)
                            {
                                //Guid Request Support
                                Guid GuidRecordCase = new Guid(ExtractGuid_Second);

                                //Get case values create in CRM
                                Incident_Case incidentCaseInstance = new Incident_Case();
                                List<ModelCaseCRM> incidentData = incidentCaseInstance.GetIncidentCase_B2B(GuidRecordCase);
                                if (incidentData != null && incidentData.Count > 0)
                                {
                                    foreach (var data in incidentData)
                                    {
                                        Console.WriteLine($"Title: {data.title_Case}");
                                        Console.WriteLine($"State Code: {data.statecode_Case}");
                                        Console.WriteLine($"Status Code: {data.statuscode_Case}");
                                        Console.WriteLine($"Ticket Number: {data.ticketNumber_Case}");
                                        Console.WriteLine($"Customer Service: {data.customerService_Case}");
                                        Console.WriteLine($"Ticket Department: {data.ticketDepartemant_Case}");
                                        Console.WriteLine($"Ticket Subject: {data.ticketsubject_Case}");
                                        Console.WriteLine($"Created On: {data.createdon_Case}");

                                        // Assertion
                                        if (ExtractGuid_First != ExtractGuid_Second && GetTicketDepartment.CustomerService == data.ticketDepartemant_Case && Service_Table_Second == data.customerService_Case)
                                        {
                                            if (TrackingCode_Table_First.ToString() != TrackingCode_Table_Second.ToString())
                                            {
                                                entity["new_titlecase"] = data.title_Case;
                                                entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                                entity["new_createdoncase"] = data.createdon_Case;
                                                entity["new_customerservicecase"] = data.customerService_Case;
                                                entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                                entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                                entity["new_subjectcase"] = data.subjectid_case;

                                                if (data.statecode_Case == 0) // Active
                                                {
                                                    entity["new_status"] = new OptionSetValue(0);
                                                }
                                                if (data.statecode_Case == 1) // Resolved
                                                {
                                                    entity["new_status"] = new OptionSetValue(1);
                                                }
                                                if (data.statecode_Case == 2) // Canceled
                                                {
                                                    entity["new_status"] = new OptionSetValue(2);
                                                }


                                                if (data.statuscode_Case == 910340003) // Draft
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(91034003);
                                                }
                                                if (data.statuscode_Case == 1) // InProgress
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(1);
                                                }
                                                if (data.statuscode_Case == 2) // On Hold
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(2);
                                                }
                                                if (data.statuscode_Case == 3) // Wating for Details
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(3);
                                                }
                                                if (data.statuscode_Case == 4) // Resaching
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(4);
                                                }

                                                entity["new_resulttest"] = new OptionSetValue(1);

                                                entity["new_messageresult"] = "Assertion succeeded.";
                                                orgService_Demo.Update(entity);

                                                Assert.Pass("Assertion succeeded.");
                                            }
                                            else
                                            {
                                                entity["new_titlecase"] = data.title_Case;
                                                entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                                entity["new_createdoncase"] = data.createdon_Case;
                                                entity["new_customerservicecase"] = data.customerService_Case;
                                                entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                                entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                                entity["new_subjectcase"] = data.subjectid_case;

                                                if (data.statecode_Case == 0) // Active
                                                {
                                                    entity["new_status"] = new OptionSetValue(0);
                                                }
                                                if (data.statecode_Case == 1) // Resolved
                                                {
                                                    entity["new_status"] = new OptionSetValue(1);
                                                }
                                                if (data.statecode_Case == 2) // Canceled
                                                {
                                                    entity["new_status"] = new OptionSetValue(2);
                                                }


                                                if (data.statuscode_Case == 910340003) // Draft
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(91034003);
                                                }
                                                if (data.statuscode_Case == 1) // InProgress
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(1);
                                                }
                                                if (data.statuscode_Case == 2) // On Hold
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(2);
                                                }
                                                if (data.statuscode_Case == 3) // Wating for Details
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(3);
                                                }
                                                if (data.statuscode_Case == 4) // Resaching
                                                {
                                                    entity["new_statusreason"] = new OptionSetValue(4);
                                                }

                                                entity["new_resulttest"] = new OptionSetValue(2);
                                                entity["new_messageresult"] = "TrackingCode_Table_First does match TrackingCode_Table_Second.";
                                                orgService_Demo.Update(entity);
                                                Assert.Fail("TrackingCode_Table_First does match TrackingCode_Table_Second.");
                                            }
                                        }
                                        else
                                        {
                                            entity["new_titlecase"] = data.title_Case;
                                            entity["new_ticketnumbercase"] = data.ticketNumber_Case;
                                            entity["new_createdoncase"] = data.createdon_Case;
                                            entity["new_customerservicecase"] = data.customerService_Case;
                                            entity["new_ticketsubjectcase"] = data.ticketsubject_Case;
                                            entity["new_ticketdepartemantcase"] = data.ticketDepartemant_Case;
                                            entity["new_subjectcase"] = data.subjectid_case;

                                            if (data.statecode_Case == 0) // Active
                                            {
                                                entity["new_status"] = new OptionSetValue(0);
                                            }
                                            if (data.statecode_Case == 1) // Resolved
                                            {
                                                entity["new_status"] = new OptionSetValue(1);
                                            }
                                            if (data.statecode_Case == 2) // Canceled
                                            {
                                                entity["new_status"] = new OptionSetValue(2);
                                            }


                                            if (data.statuscode_Case == 910340003) // Draft
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(91034003);
                                            }
                                            if (data.statuscode_Case == 1) // InProgress
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(1);
                                            }
                                            if (data.statuscode_Case == 2) // On Hold
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(2);
                                            }
                                            if (data.statuscode_Case == 3) // Wating for Details
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(3);
                                            }
                                            if (data.statuscode_Case == 4) // Resaching
                                            {
                                                entity["new_statusreason"] = new OptionSetValue(4);
                                            }

                                            entity["new_resulttest"] = new OptionSetValue(2);
                                            entity["new_messageresult"] = "ExtractGuid_First != ExtractGuid_Second && GetTicketDepartment.CustomerService == data.ticketDepartemant_Case && Service_Table_Second == data.customerService_Case (does not match)";
                                            orgService_Demo.Update(entity);
                                            Assert.Fail("ExtractGuid_First != ExtractGuid_Second && GetTicketDepartment.CustomerService == data.ticketDepartemant_Case && Service_Table_Second == data.customerService_Case (does not match)");
                                        }
                                    }
                                }
                                else
                                {
                                    entity["new_resulttest"] = new OptionSetValue(2);
                                    entity["new_messageresult"] = "رکورد ایجادی تکراری می باشد.";
                                    orgService_Demo.Update(entity);
                                    Assert.Fail("رکورد ایجادی تکراری می باشد.");
                                }
                            }
                        }
                        //Faild Request Support
                        else if (element_Faild == Text_Faild_Alert)
                        {
                            Console.WriteLine("پیدا شد: " + Text_Faild_Alert);
                            entity["new_discription"] = Text_Faild_Alert;

                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@href='/supportticket'])[2]"))).Click();

                            // بپرسم از امیرحسین
                            var GetValueTableSecond = FunctionRequestSupport_PanelHiweb.GetTableSecondRequestSupport_B2B(driver, wait);
                            string TrackingCode_Table_Second = GetValueTableSecond.TrackingCode_Table_Second;
                            if (TrackingCode_Table_First == TrackingCode_Table_Second)
                            {
                                entity["new_resulttest"] = new OptionSetValue(1);
                                entity["new_messageresult"] = "TrackingCode_Table_First And TrackingCode_Table_Second Are Equal";
                                orgService_Demo.Update(entity);
                                Assert.AreEqual(TrackingCode_Table_First, TrackingCode_Table_Second);
                            }
                            else
                            {
                                entity["new_resulttest"] = new OptionSetValue(2);
                                entity["new_messageresult"] = "SupportRequest Record Created";
                                orgService_Demo.Update(entity);
                                Assert.Fail("SupportRequest Record Created");
                            }

                        }
                        else
                        {
                            entity["new_resulttest"] = new OptionSetValue(2);
                            entity["new_messageresult"] = "شما مجاز به ثبت درخواست نمی باشد.";
                            orgService_Demo.Update(entity);
                            Assert.Fail("شما مجاز به ثبت درخواست نمی باشد.");
                        }
                    }

                }
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
            driver.Quit();
        }
    }
}