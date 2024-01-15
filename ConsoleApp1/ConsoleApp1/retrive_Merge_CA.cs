using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class retrive_Merge_CA
    {
        private OrganizationServiceProxy orgService;

        // Get Value Contact
        public List<ModelContact_Account_Service_CRM> Contact_Account(string Username, string Password)
        {

            orgService = Connetion_CRM.GetOrgService();
            QueryExpression query_contact = new QueryExpression("contact");
            query_contact.ColumnSet = new ColumnSet("fullname", "hiw_username", "hiw_password", "new_type");

            query_contact.Criteria.AddCondition("hiw_username", ConditionOperator.Equal, Username);
            query_contact.Criteria.AddCondition("hiw_password", ConditionOperator.Equal, Password);

            EntityCollection entityCollection_contact = orgService.RetrieveMultiple(query_contact);

            if (entityCollection_contact.Entities.Count > 0)
            {
                if (entityCollection_contact != null && entityCollection_contact.Entities != null && entityCollection_contact.Entities.Count > 0)
                {
                    List<ModelContact_Account_Service_CRM> modelContact_Account_Service = new List<ModelContact_Account_Service_CRM>();

                    foreach (Entity entity in entityCollection_contact.Entities)
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
            if (entityCollection_contact.Entities.Count == 0)
            {
                QueryExpression query_account = new QueryExpression("account");
                query_account.ColumnSet = new ColumnSet("hiw_username", "hiw_password", "name", "new_type");

                query_account.Criteria.FilterOperator = LogicalOperator.And;
                query_account.Criteria.AddCondition("hiw_username", ConditionOperator.Equal, Username);
                query_account.Criteria.AddCondition("hiw_password", ConditionOperator.Equal, Password);

                EntityCollection entityCollection_account = orgService.RetrieveMultiple(query_account);

                if (entityCollection_account != null && entityCollection_account.Entities != null && entityCollection_account.Entities.Count > 0)
                {
                    List<ModelContact_Account_Service_CRM> modelContact_Account_Service = new List<ModelContact_Account_Service_CRM>();

                    foreach (Entity entity in entityCollection_account.Entities)
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
            }
            else
                Console.WriteLine("Record not found.");
            return null;
        }
    }
}
