using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Retrive_Merge_AC_GetCustomerService
    {

        private OrganizationServiceProxy orgService;

        // Get Value Contact
        public List<ModelContact_Account_Service_CRM> Get_Contact_Account(Guid guid_Customer)
        {
            orgService = Connetion_CRM.GetOrgService();
            QueryExpression query_contact = new QueryExpression("contact");
            query_contact.ColumnSet = new ColumnSet("fullname", "contactid", "new_type");

            query_contact.Criteria.AddCondition("contactid", ConditionOperator.Equal, guid_Customer);

            EntityCollection entityCollection_contact = orgService.RetrieveMultiple(query_contact);

            if (entityCollection_contact.Entities.Count > 0)
            {
                if (entityCollection_contact != null && entityCollection_contact.Entities != null && entityCollection_contact.Entities.Count > 0)
                {
                    List<ModelContact_Account_Service_CRM> modelContact_Account = new List<ModelContact_Account_Service_CRM>();

                    foreach (Entity entity in entityCollection_contact.Entities)
                    {
                        ModelContact_Account_Service_CRM modelContact_Account_CRM = new ModelContact_Account_Service_CRM();

                        if (entity.Id != null)
                        {
                            var contact_LogicalName = entity.LogicalName;
                            modelContact_Account_CRM.LogicalName = contact_LogicalName;
                        }

                        if (entity.Contains("fullname") && entity["fullname"] != null)
                        {
                            string name_Contact = entity.GetAttributeValue<string>("fullname");
                            modelContact_Account_CRM.Name = name_Contact;
                        }

                        if (entity.Contains("new_type") && entity["new_type"] != null)
                        {
                            OptionSetValue typeOptionSetValue = (OptionSetValue)entity["new_type"];
                            var Type_Contact = typeOptionSetValue.Value;

                            switch (Type_Contact)
                            {
                                case 1:
                                    modelContact_Account_CRM.Type = "Customer";
                                    modelContact_Account_CRM.Type_id = 1;
                                    break;
                                case 2:
                                    modelContact_Account_CRM.Type = "B2C";
                                    modelContact_Account_CRM.Type_id = 2;
                                    break;
                                case 3:
                                    modelContact_Account_CRM.Type = "B2B";
                                    modelContact_Account_CRM.Type_id = 3;
                                    break;
                                case 4:
                                    modelContact_Account_CRM.Type = "Reseller";
                                    modelContact_Account_CRM.Type_id = 4;
                                    break;
                                default:
                                    break;
                            }
                        }
                        modelContact_Account.Add(modelContact_Account_CRM);
                    }
                    return modelContact_Account;
                }
                else
                {
                    Console.WriteLine("Record not found.");
                    return null;
                }
            }

            // Get Value Account
            if (entityCollection_contact.Entities.Count == 0)
            {
                QueryExpression query_account = new QueryExpression("account");
                query_account.ColumnSet = new ColumnSet("name", "accountid", "new_type");

                query_account.Criteria.FilterOperator = LogicalOperator.And;
                query_account.Criteria.AddCondition("accountid", ConditionOperator.Equal, guid_Customer);

                EntityCollection entityCollection_account = orgService.RetrieveMultiple(query_account);
                if (entityCollection_account.Entities.Count > 0)
                {
                    if (entityCollection_account != null && entityCollection_account.Entities != null && entityCollection_account.Entities.Count > 0)
                    {
                        List<ModelContact_Account_Service_CRM> modelContact_Account = new List<ModelContact_Account_Service_CRM>();

                        foreach (Entity entity in entityCollection_account.Entities)
                        {
                            ModelContact_Account_Service_CRM modelContact_Account_CRM = new ModelContact_Account_Service_CRM();

                            if (entity.Id != null)
                            {
                                var account_LogicalName = entity.LogicalName;
                                modelContact_Account_CRM.LogicalName = account_LogicalName;
                            }

                            if (entity.Contains("name") && entity["name"] != null)
                            {
                                string name_Account = entity.GetAttributeValue<string>("name");
                                modelContact_Account_CRM.Name = name_Account;
                            }
                            if (entity.Contains("new_type") && entity["new_type"] != null)
                            {
                                OptionSetValue typeOptionSetValue = (OptionSetValue)entity["new_type"];
                                var Type_Account = typeOptionSetValue.Value;

                                switch (Type_Account)
                                {
                                    case 1:
                                        modelContact_Account_CRM.Type = "Customer";
                                        modelContact_Account_CRM.Type_id = 1;
                                        break;
                                    case 2:
                                        modelContact_Account_CRM.Type = "B2C";
                                        modelContact_Account_CRM.Type_id = 2;
                                        break;
                                    case 3:
                                        modelContact_Account_CRM.Type = "B2B";
                                        modelContact_Account_CRM.Type_id = 3;
                                        break;
                                    case 4:
                                        modelContact_Account_CRM.Type = "Reseller";
                                        modelContact_Account_CRM.Type_id = 4;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            modelContact_Account.Add(modelContact_Account_CRM);
                        }
                        return modelContact_Account;
                    }
                    else
                    {
                        Console.WriteLine("Record not found.");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Record not found.");
                    return null;
                }
            }

            return null;
        }
    }
}