using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class retriveCACS
    {
        private OrganizationServiceProxy orgService;

        // Get Value Contact
        public List<ModelContact_Account_Service_CRM> Contact(string Username, string Password)
        {

            orgService = Connetion_CRM.GetOrgService();
            QueryExpression query = new QueryExpression("contact");
            query.ColumnSet = new ColumnSet("fullname", "hiw_username", "hiw_password", "new_type");

            query.Criteria.AddCondition("hiw_username", ConditionOperator.Equal, Username);
            query.Criteria.AddCondition("hiw_password", ConditionOperator.Equal, Password);

            EntityCollection entityCollection = orgService.RetrieveMultiple(query);

            if (entityCollection != null && entityCollection.Entities != null && entityCollection.Entities.Count > 0)
            {
                List<ModelContact_Account_Service_CRM> modelContact_Account_Service = new List<ModelContact_Account_Service_CRM>();

                foreach (Entity entity in entityCollection.Entities)
                {
                    ModelContact_Account_Service_CRM modelContact_Account_Service_CRM = new ModelContact_Account_Service_CRM();

                    if (entity.Id != null)
                    {
                        var contact_LogicalName = entity.LogicalName;
                        modelContact_Account_Service_CRM.LogicalName = contact_LogicalName;
                    }

                    if (entity.Contains("contactid") && entity["contactid"] != null)
                    {
                        Guid Guid_Contact = (Guid)entity["contactid"];
                        modelContact_Account_Service_CRM.GetGuid_Contact_Account_Service_CRM = Guid_Contact;
                    }

                    if (entity.Contains("fullname") && entity["fullname"] != null)
                    {
                        string name_Contact = entity.GetAttributeValue<string>("fullname");
                        modelContact_Account_Service_CRM.Name = name_Contact;
                    }
                    if (entity.Contains("hiw_username") && entity["hiw_username"] != null)
                    {
                        string username_Contact = entity.GetAttributeValue<string>("hiw_username");
                        modelContact_Account_Service_CRM.Username = username_Contact;
                    }

                    if (entity.Contains("hiw_password") && entity["hiw_password"] != null)
                    {
                        string password_Contact = entity.GetAttributeValue<string>("hiw_password");
                        modelContact_Account_Service_CRM.Password = password_Contact;
                    }
                    if (entity.Contains("new_type") && entity["new_type"] != null)
                    {
                        OptionSetValue typeOptionSetValue = (OptionSetValue)entity["new_type"];
                        var Type_Contact = typeOptionSetValue.Value;

                        switch (Type_Contact)
                        {
                            case 1:
                                modelContact_Account_Service_CRM.Type = "Customer";
                                break;
                            case 2:
                                modelContact_Account_Service_CRM.Type = "B2C";
                                break;
                            case 3:
                                modelContact_Account_Service_CRM.Type = "B2B";
                                break;
                            case 4:
                                modelContact_Account_Service_CRM.Type = "Reseller";
                                break;
                            default:
                                break;
                        }

                    }
                    modelContact_Account_Service.Add(modelContact_Account_Service_CRM);
                }
                return modelContact_Account_Service;
            }
            else
                Console.WriteLine("Record not found.");
            return null;
        }

        // Get Value Account
        public List<ModelContact_Account_Service_CRM> Account(string username, string password)
        {
            orgService = Connetion_CRM.GetOrgService();
            Microsoft.Xrm.Sdk.Query.QueryExpression query = new Microsoft.Xrm.Sdk.Query.QueryExpression("account");
            query.ColumnSet = new Microsoft.Xrm.Sdk.Query.ColumnSet("hiw_username", "hiw_password", "name", "new_type");

            query.Criteria.FilterOperator = LogicalOperator.And;
            query.Criteria.AddCondition("hiw_username", ConditionOperator.Equal, username);
            query.Criteria.AddCondition("hiw_password", ConditionOperator.Equal, password);


            EntityCollection entityCollection = orgService.RetrieveMultiple(query);

            if (entityCollection != null && entityCollection.Entities != null && entityCollection.Entities.Count > 0)
            {
                List<ModelContact_Account_Service_CRM> modelContact_Account_Service = new List<ModelContact_Account_Service_CRM>();

                foreach (Entity entity in entityCollection.Entities)
                {
                    ModelContact_Account_Service_CRM modelContact_Account_Service_CRM = new ModelContact_Account_Service_CRM();

                    if (entity.Id != null)
                    {
                        var account_LogicalName = entity.LogicalName;
                        modelContact_Account_Service_CRM.LogicalName = account_LogicalName;
                    }
                    if (entity.Contains("accountid") && entity["accountid"] != null)
                    {
                        Guid Guid_account = (Guid)entity["accountid"];
                        modelContact_Account_Service_CRM.GetGuid_Contact_Account_Service_CRM = Guid_account;
                    }

                    if (entity.Contains("name") && entity["name"] != null)
                    {
                        string name_Account = entity.GetAttributeValue<string>("name");
                        modelContact_Account_Service_CRM.Name = name_Account;
                    }
                    if (entity.Contains("hiw_username") && entity["hiw_username"] != null)
                    {
                        string username_Account = entity.GetAttributeValue<string>("hiw_username");
                        modelContact_Account_Service_CRM.Username = username_Account;
                    }

                    if (entity.Contains("hiw_password") && entity["hiw_password"] != null)
                    {
                        string password_Account = entity.GetAttributeValue<string>("hiw_password");
                        modelContact_Account_Service_CRM.Password = password_Account;
                    }
                    if (entity.Contains("new_type") && entity["new_type"] != null)
                    {
                        OptionSetValue typeOptionSetValue = (OptionSetValue)entity["new_type"];
                        var Type_Account = typeOptionSetValue.Value;

                        switch (Type_Account)
                        {
                            case 1:
                                modelContact_Account_Service_CRM.Type = "Customer";
                                break;
                            case 2:
                                modelContact_Account_Service_CRM.Type = "B2C";
                                break;
                            case 3:
                                modelContact_Account_Service_CRM.Type = "B2B";
                                break;
                            case 4:
                                modelContact_Account_Service_CRM.Type = "Reseller";
                                break;
                            default:
                                break;
                        }
                    }
                    modelContact_Account_Service.Add(modelContact_Account_Service_CRM);
                }
                return modelContact_Account_Service;
            }
            else
                Console.WriteLine("Record not found.");
            return null;
        }

        // Get Value CustomerService
        public List<ModelContact_Account_Service_CRM> CustomerService(string Username, string Password)
        {

            orgService = Connetion_CRM.GetOrgService();
            QueryExpression query_CustomerService = new QueryExpression("hiw_customerservice");
            query_CustomerService.ColumnSet = new ColumnSet("hiw_name", "hiw_username", "hiw_password", "hiw_customer", "hiw_fcpprovider", "hiw_sit", "hiw_productserviceinfra");

            query_CustomerService.Criteria.AddCondition("hiw_username", ConditionOperator.Equal, Username);
            query_CustomerService.Criteria.AddCondition("hiw_password", ConditionOperator.Equal, Password);

            EntityCollection entityCollection_contact = orgService.RetrieveMultiple(query_CustomerService);

            if (entityCollection_contact != null && entityCollection_contact.Entities != null && entityCollection_contact.Entities.Count > 0)
            {
                List<ModelContact_Account_Service_CRM> modelContact_Account_Service = new List<ModelContact_Account_Service_CRM>();

                foreach (Entity entity in entityCollection_contact.Entities)
                {
                    ModelContact_Account_Service_CRM modelContact_Account_Service_CRM = new ModelContact_Account_Service_CRM();

                    if (entity.Id != null)
                    {
                        var CustomerService_LogicalName = entity.LogicalName;
                        modelContact_Account_Service_CRM.LogicalName = CustomerService_LogicalName;
                    }

                    if (entity.Contains("hiw_customerserviceid") && entity["hiw_customerserviceid"] != null)
                    {
                        Guid Guid_CustomerService = (Guid)entity["hiw_customerserviceid"];
                        modelContact_Account_Service_CRM.GetGuid_Contact_Account_Service_CRM = Guid_CustomerService;
                    }

                    if (entity.Contains("hiw_name") && entity["hiw_name"] != null)
                    {
                        string name_CustomerService = entity.GetAttributeValue<string>("hiw_name");
                        modelContact_Account_Service_CRM.Name = name_CustomerService;
                    }
                    if (entity.Contains("hiw_username") && entity["hiw_username"] != null)
                    {
                        string username_CustomerService = entity.GetAttributeValue<string>("hiw_username");
                        modelContact_Account_Service_CRM.Username = username_CustomerService;
                    }

                    if (entity.Contains("hiw_password") && entity["hiw_password"] != null)
                    {
                        string password_CustomerService = entity.GetAttributeValue<string>("hiw_password");
                        modelContact_Account_Service_CRM.Password = password_CustomerService;
                    }

                    if (entity.Contains("hiw_productserviceinfra") && entity["hiw_productserviceinfra"] != null)
                    {
                        EntityReference entityReference = (EntityReference)entity["hiw_productserviceinfra"];

                        var ProductServiceInfra_CustomerService = entityReference.Name;
                        modelContact_Account_Service_CRM.ProductServiceInfra = ProductServiceInfra_CustomerService;
                    }

                    if (entity.Contains("hiw_customer") && entity["hiw_customer"] != null)
                    {
                        EntityReference entityReference = (EntityReference)entity["hiw_customer"];

                        var customer_CustomerService_Customer = entityReference.Name;
                        var customer_CustomerService_LogicalName = entityReference.LogicalName;
                        var customer_CustomerService_Guid = entityReference.Id;

                        modelContact_Account_Service_CRM.Customer = customer_CustomerService_Customer;
                        modelContact_Account_Service_CRM.LogicalName = customer_CustomerService_LogicalName;
                        modelContact_Account_Service_CRM.GetGuid_CustomerService_Customer = customer_CustomerService_Guid;
                    }

                    if (entity.Contains("hiw_fcpprovider") && entity["hiw_fcpprovider"] != null)
                    {
                        EntityReference entityReference = (EntityReference)entity["hiw_fcpprovider"];
                        var fcpprovider_CustomerService = entityReference.Name;
                        modelContact_Account_Service_CRM.FcpProvider = fcpprovider_CustomerService;
                    }

                    if (entity.Contains("hiw_sit") && entity["hiw_sit"] != null)
                    {
                        OptionSetValue typeOptionSetValue = (OptionSetValue)entity["hiw_sit"];
                        var sit_CustomerService = typeOptionSetValue.Value;

                        switch (sit_CustomerService)
                        {
                            case 1:
                                modelContact_Account_Service_CRM.Sit = "ثبت نام - ADSL";
                                break;
                            case 2:
                                modelContact_Account_Service_CRM.Sit = "ثبت نام - واریز وجه - ADSL";
                                break;
                            case 3:
                                modelContact_Account_Service_CRM.Sit = "منتظر جواب رانژه";
                                break;
                            case 4:
                                modelContact_Account_Service_CRM.Sit = "رانژه ناموفق";
                                break;
                            case 5:
                                modelContact_Account_Service_CRM.Sit = "ثبت نام - فیبر";
                                break;
                            case 6:
                                modelContact_Account_Service_CRM.Sit = "واریز وجه - بررسی مدارک - فیبر";
                                break;
                            case 7:
                                modelContact_Account_Service_CRM.Sit = "منتظر نصب و فعالسازی - فیبر";
                                break;
                            case 8:
                                modelContact_Account_Service_CRM.Sit = "ثبت نام وایرلس";
                                break;
                            case 9:
                                modelContact_Account_Service_CRM.Sit = "در انتظار فعالساری";
                                break;
                            case 10:
                                modelContact_Account_Service_CRM.Sit = "عودت";
                                break;
                            case 11:
                                modelContact_Account_Service_CRM.Sit = "منتظر شاهکار - فیبر";
                                break;
                            case 12:
                                modelContact_Account_Service_CRM.Sit = "فعال";
                                break;
                            case 13:
                                modelContact_Account_Service_CRM.Sit = "عدم تمدید";
                                break;
                            case 14:
                                modelContact_Account_Service_CRM.Sit = "جلوگیری از ثبت نام";
                                break;
                            case 15:
                                modelContact_Account_Service_CRM.Sit = "ثبت نام - 4G";
                                break;
                            case 16:
                                modelContact_Account_Service_CRM.Sit = " منتظر تخصیص شماره تلفن - 4G";
                                break;
                            case 17:
                                modelContact_Account_Service_CRM.Sit = "منتظر بررسی مدارک  - 4G";
                                break;
                            case 18:
                                modelContact_Account_Service_CRM.Sit = "منتظر شاهکار  - 4G";
                                break;
                            case 19:
                                modelContact_Account_Service_CRM.Sit = "منتظر تخصیص سیمکارت - 4G";
                                break;
                            case 20:
                                modelContact_Account_Service_CRM.Sit = "منتظر ارسال سند - 4G";
                                break;
                            case 21:
                                modelContact_Account_Service_CRM.Sit = "منتظر ثبت سند - 4G";
                                break;
                            case 22:
                                modelContact_Account_Service_CRM.Sit = "مفقودی - 4G";
                                break;
                            case 23:
                                modelContact_Account_Service_CRM.Sit = "ثبت نام وایفای";
                                break;
                            case 24:
                                modelContact_Account_Service_CRM.Sit = "منتظر فعالسازی وایرلس";
                                break;
                            case 25:
                                modelContact_Account_Service_CRM.Sit = "منتظر شاهکار وایفای";
                                break;
                            case 26:
                                modelContact_Account_Service_CRM.Sit = "درانتظار فعالسازی وایفای";
                                break;
                            case 27:
                                modelContact_Account_Service_CRM.Sit = "ارسال تجهیزات - فیبر";
                                break;
                            case 28:
                                modelContact_Account_Service_CRM.Sit = "بررسی سیمکارت تخصیص یافته - 4G";
                                break;
                            case 29:
                                modelContact_Account_Service_CRM.Sit = "انصراف از ثبت نام";
                                break;
                            case 30:
                                modelContact_Account_Service_CRM.Sit = "منتظر شاهکار وایرلس";
                                break;
                            case 31:
                                modelContact_Account_Service_CRM.Sit = "در انتظار Change - VSAT";
                                break;
                            case 32:
                                modelContact_Account_Service_CRM.Sit = "در انتظار صورتجلسه - VSAT";
                                break;
                            case 33:
                                modelContact_Account_Service_CRM.Sit = "در انتظار فعالسازی - VSAT";
                                break;
                            case 34:
                                modelContact_Account_Service_CRM.Sit = "ثبت نام VPS";
                                break;
                            case 35:
                                modelContact_Account_Service_CRM.Sit = "در انتظار ارسال تجهیزات - ترانک";
                                break;
                            case 36:
                                modelContact_Account_Service_CRM.Sit = "در انتظار تعامل با مشتری - ترانک";
                                break;
                            case 37:
                                modelContact_Account_Service_CRM.Sit = "در انتظار Change - ترانک";
                                break;
                            case 38:
                                modelContact_Account_Service_CRM.Sit = "در انتظار صورتجلسه نصب - ترانک";
                                break;
                            case 39:
                                modelContact_Account_Service_CRM.Sit = "در انتظار فعالساری - ترانک";
                                break;
                            case 40:
                                modelContact_Account_Service_CRM.Sit = "منتظر امکان سنجی - فیبر";
                                break;
                            case 41:
                                modelContact_Account_Service_CRM.Sit = "در انتظار بررسی تجهیزات - فیبر";
                                break;
                            case 42:
                                modelContact_Account_Service_CRM.Sit = "عدم پوشش دهی - فیبر";
                                break;
                            case 50:
                                modelContact_Account_Service_CRM.Sit = "قطع دائم";
                                break;
                            default:
                                break;
                        }
                    }
                    modelContact_Account_Service.Add(modelContact_Account_Service_CRM);
                }
                return modelContact_Account_Service;
            }
            else
                Console.WriteLine("Record not found.");
            return null;
        }
    }
}