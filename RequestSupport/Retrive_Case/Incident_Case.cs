using RequestSupport.Connection;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using Microsoft.Xrm.Sdk;
using RequestSupport.Model;
using AngleSharp.Dom;
using System.Collections.Generic;
using System.Linq;

namespace RequestSupport.Retrive_Case
{
    public class Incident_Case
    {
        private OrganizationServiceProxy orgService;

        public List<ModelCaseCRM> GetIncidentCase_B2C(Guid CustomerServiceGuid, string ticketsubject)
        {
            orgService = Connetion_CRM.GetOrgService();
            QueryExpression query = new QueryExpression("incident");

            query.ColumnSet = new ColumnSet("incidentid", "title", "createdon", "statecode", "statuscode", "ticketnumber", "hiw_customerservice", "createdon", "hiw_ticketdepartment", "hiw_ticketsubject", "subjectid", "caseorigincode"); ;
            query.Criteria.FilterOperator = LogicalOperator.And;
            query.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            query.Criteria.AddCondition("hiw_customerservice", ConditionOperator.Equal, CustomerServiceGuid);
            query.Criteria.AddCondition("statuscode", ConditionOperator.Equal, 910340003);
            query.Criteria.AddCondition("caseorigincode", ConditionOperator.Equal, 3);
            query.AddOrder("createdon", OrderType.Descending);

            EntityCollection entityCollection = orgService.RetrieveMultiple(query);
            var entityCollection_OrderType = entityCollection.Entities.FirstOrDefault();

            if (entityCollection_OrderType != null)
            {
                //var entityCollection_OrderType = entityCollection.Entities.FirstOrDefault();

                List<ModelCaseCRM> incidentCases = new List<ModelCaseCRM>();
                ModelCaseCRM incidentCase = new ModelCaseCRM();

                if (entityCollection_OrderType.Contains("incidentid") && entityCollection_OrderType["incidentid"] != null)
                {
                    Guid GuidCaseRecord = (Guid)entityCollection_OrderType["incidentid"];
                    incidentCase.GetGuidCaseRecord = GuidCaseRecord;
                }

                if (entityCollection_OrderType.Contains("title") && entityCollection_OrderType["title"] != null)
                {
                    string title_Case = entityCollection_OrderType.GetAttributeValue<string>("title");
                    incidentCase.title_Case = title_Case;
                    string searchString = ticketsubject;
                    if (title_Case.Contains(searchString))
                    {
                        incidentCase.Extraction_title_Case = searchString;
                    }
                    else
                    {
                        incidentCase.Extraction_title_Case = title_Case;
                    }
                }
                if (entityCollection_OrderType.Contains("statecode") && entityCollection_OrderType["statecode"] != null)
                {
                    int statecode_Case = entityCollection_OrderType.GetAttributeValue<OptionSetValue>("statecode").Value;
                    incidentCase.statecode_Case = statecode_Case;
                }

                if (entityCollection_OrderType.Contains("statuscode") && entityCollection_OrderType["statuscode"] != null)
                {
                    int statuscode_Case = entityCollection_OrderType.GetAttributeValue<OptionSetValue>("statuscode").Value;
                    incidentCase.statuscode_Case = statuscode_Case;
                }

                if (entityCollection_OrderType.Contains("ticketnumber") && entityCollection_OrderType["ticketnumber"] != null)
                {
                    string ticketNumber_Case = entityCollection_OrderType.GetAttributeValue<string>("ticketnumber");
                    incidentCase.ticketNumber_Case = ticketNumber_Case;
                }

                if (entityCollection_OrderType.Contains("hiw_customerservice") && entityCollection_OrderType["hiw_customerservice"] != null)
                {
                    string customerService_Case = entityCollection_OrderType.GetAttributeValue<EntityReference>("hiw_customerservice").Name;
                    incidentCase.customerService_Case = customerService_Case;
                }

                if (entityCollection_OrderType.Contains("hiw_ticketdepartment") && entityCollection_OrderType["hiw_ticketdepartment"] != null)
                {
                    string ticketDepartemant_Case = entityCollection_OrderType.GetAttributeValue<EntityReference>("hiw_ticketdepartment").Name;
                    incidentCase.ticketDepartemant_Case = ticketDepartemant_Case;
                }

                if (entityCollection_OrderType.Contains("hiw_ticketsubject") && entityCollection_OrderType["hiw_ticketsubject"] != null)
                {
                    string ticketsubject_Case = entityCollection_OrderType.GetAttributeValue<EntityReference>("hiw_ticketsubject").Name;
                    incidentCase.ticketsubject_Case = ticketsubject_Case;
                }

                if (entityCollection_OrderType.Contains("subjectid") && entityCollection_OrderType["subjectid"] != null)
                {
                    string subjectid_case = entityCollection_OrderType.GetAttributeValue<EntityReference>("subjectid").Name;
                    incidentCase.subjectid_case = subjectid_case;
                }

                if (entityCollection_OrderType.Contains("createdon") && entityCollection_OrderType["createdon"] != null)
                {
                    string createdon_Case = entityCollection_OrderType.GetAttributeValue<DateTime>("createdon").ToString();
                    incidentCase.createdon_Case = createdon_Case;
                }
                incidentCases.Add(incidentCase);

                return incidentCases;
            }
            else
                Console.WriteLine("Record not found.");
            return null;
        }

        //********************************************************** B2B *************************************************************
        public List<ModelCaseCRM> GetIncidentCase_B2B(Guid caseGuid)
        {
            orgService = Connetion_CRM.GetOrgService();

            ColumnSet columnSet = new ColumnSet("incidentid", "title", "statecode", "statuscode", "ticketnumber", "hiw_customerservice", "createdon", "hiw_ticketdepartment", "hiw_ticketsubject", "subjectid", "caseorigincode");

            Microsoft.Xrm.Sdk.Entity entity = orgService.Retrieve("incident", caseGuid, columnSet);

            if (entity != null)
            {
                List<ModelCaseCRM> incidentCases = new List<ModelCaseCRM>();

                ModelCaseCRM incidentCase = new ModelCaseCRM();

                if (entity.Contains("incidentid") && entity["incidentid"] != null)
                {
                    Guid GuidCaseRecord = (Guid)entity["incidentid"];
                    incidentCase.GetGuidCaseRecord = GuidCaseRecord;
                }

                if (entity.Contains("title") && entity["title"] != null)
                {
                    incidentCase.title_Case = entity.GetAttributeValue<string>("title");
                }

                if (entity.Contains("statecode") && entity["statecode"] != null)
                {
                    int statecode_Case = entity.GetAttributeValue<OptionSetValue>("statecode").Value;
                    incidentCase.statecode_Case = statecode_Case;
                }

                if (entity.Contains("statuscode") && entity["statuscode"] != null)
                {
                    int statuscode_Case = entity.GetAttributeValue<OptionSetValue>("statuscode").Value;
                    incidentCase.statuscode_Case = statuscode_Case;
                }

                if (entity.Contains("ticketnumber") && entity["ticketnumber"] != null)
                {
                    string ticketNumber_Case = entity.GetAttributeValue<string>("ticketnumber");
                    incidentCase.ticketNumber_Case = ticketNumber_Case;
                }

                if (entity.Contains("hiw_customerservice") && entity["hiw_customerservice"] != null)
                {
                    string customerService_Case = entity.GetAttributeValue<EntityReference>("hiw_customerservice").Name;
                    incidentCase.customerService_Case = customerService_Case;
                }

                if (entity.Contains("hiw_ticketdepartment") && entity["hiw_ticketdepartment"] != null)
                {
                    string ticketDepartemant_Case = entity.GetAttributeValue<EntityReference>("hiw_ticketdepartment").Name;
                    incidentCase.ticketDepartemant_Case = ticketDepartemant_Case;
                }

                if (entity.Contains("hiw_ticketsubject") && entity["hiw_ticketsubject"] != null)
                {
                    string ticketsubject_Case = entity.GetAttributeValue<EntityReference>("hiw_ticketsubject").Name;
                    incidentCase.ticketsubject_Case = ticketsubject_Case;
                }

                if (entity.Contains("subjectid") && entity["subjectid"] != null)
                {
                    string subjectid_case = entity.GetAttributeValue<EntityReference>("subjectid").Name;
                    incidentCase.subjectid_case = subjectid_case;
                }

                if (entity.Contains("createdon") && entity["createdon"] != null)
                {
                    string createdon_Case = entity.GetAttributeValue<DateTime>("createdon").ToString();
                    incidentCase.createdon_Case = createdon_Case;
                }
                incidentCases.Add(incidentCase);
                return incidentCases;
            }
            else
            {
                Console.WriteLine("Record not found.");
                return null;
            }
        }

    }
}