using System;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using RequestSupport.Model;
using RequestSupport.Connection;

namespace RequestSupport.Retrive_Contact_Account_CS
{
    public class Ritrive_CustomerService
    {
        private OrganizationServiceProxy orgService;

        // Get Value CustomerService
        public List<ModelContact_Account_Service_CRM> CustomerService(Guid Guid_CustomerService)
        {

            orgService = Connetion_CRM.GetOrgService();
            QueryExpression query_CustomerService = new QueryExpression("hiw_customerservice");
            query_CustomerService.ColumnSet = new ColumnSet("hiw_name", "hiw_customer", "hiw_fcpprovider", "hiw_customerserviceid");

            query_CustomerService.Criteria.AddCondition("hiw_customerserviceid", ConditionOperator.Equal, Guid_CustomerService);

            EntityCollection entityCollection_contact = orgService.RetrieveMultiple(query_CustomerService);

            if (entityCollection_contact != null && entityCollection_contact.Entities != null && entityCollection_contact.Entities.Count > 0)
            {
                List<ModelContact_Account_Service_CRM> modelCustomerService = new List<ModelContact_Account_Service_CRM>();

                foreach (Entity entity in entityCollection_contact.Entities)
                {
                    ModelContact_Account_Service_CRM modelCustomerService_CRM = new ModelContact_Account_Service_CRM();
                    if (entity.Id != null)
                    {
                        var CustomerService_LogicalName = entity.LogicalName;
                        modelCustomerService_CRM.LogicalName = CustomerService_LogicalName;
                    }

                    if (entity.Contains("hiw_customerserviceid") && entity["hiw_customerserviceid"] != null)
                    {
                        Guid Guid_CSID = (Guid)entity["hiw_customerserviceid"];
                        modelCustomerService_CRM.GetGuid_Contact_Account_Service_CRM = Guid_CSID;
                    }
                    if (entity.Contains("hiw_fcpprovider") && entity["hiw_fcpprovider"] != null)
                    {
                        EntityReference entityReference = (EntityReference)entity["hiw_fcpprovider"];
                        var fcpprovider_CustomerService = entityReference.Name;
                        modelCustomerService_CRM.FcpProvider = fcpprovider_CustomerService;
                        var fcpprovider_CustomerService_GUID = entityReference.Id;
                        modelCustomerService_CRM.FcpProvider_Guid = fcpprovider_CustomerService_GUID;
                    }
                    modelCustomerService.Add(modelCustomerService_CRM);
                }
                return modelCustomerService;
            }
            else
                Console.WriteLine("Record not found.");
            return null;
        }
    }
}