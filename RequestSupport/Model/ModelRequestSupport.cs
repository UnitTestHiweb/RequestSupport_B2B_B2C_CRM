using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestSupport.Model
{
    public class ModelRequestSupport
    {
        public string CustomerService { get; set; }
        public int IndexCustomerService { get; set; }
    }
    public class ModelGetTableFirstRequestSupport
    {
        
        public string Service_Table_First { get; set; }
        public string Tittle_Table_First { get; set; }
        public string Discription_Table_First { get; set; }
        public string CreateOn_Table_First { get; set; }
        public string Status_Table_First { get; set; }
        public string TrackingCode_Table_First { get; set; }
        public string Guid_Create_Request_Support_First { get; set; }
        public string Guid_Table_First { get; set; }

    }
    public class ModelGetTableSecondRequestSupport
    {
        public string Service_Table_Second { get; set; }
        public string Tittle_Table_Second { get; set; }
        public string Discription_Table_Second { get; set; }
        public string CreateOn_Table_Second { get; set; }
        public string Status_Table_Second { get; set; }
        public string TrackingCode_Table_Second { get; set; }
        public string Guid_Create_Request_Support_Second { get; set; }
        public string Guid_Table_Second { get; set; }

    }
    public class ModelCaseCRM
    {
        public string title_Case { get; set; }
        public string Extraction_title_Case { get; set; }
        public int statecode_Case { get; set; }
        public int statuscode_Case { get; set; }
        public string ticketNumber_Case { get; set; }
        public string customerService_Case { get; set; }
        public string ticketDepartemant_Case { get; set; }
        public string ticketsubject_Case { get; set; }
        public string createdon_Case { get; set; }
        public string subjectid_case { get; set; }
        public Guid GetGuidCaseRecord { get; set; }
    }
    public class ModelContact_Account_Service_CRM
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public int Type_id { get; set; }
        public string Customer { get; set; }

        public string Customer_CS { get; set; }
        public string LogicalName_CS { get; set; }
        public Guid GetGuid_CS_Customer { get; set; }

        public string FcpProvider { get; set; }
        public string InfrastructureProvider { get; set; }
        public string LogicalName { get; set; }
        public string ProductServiceInfra { get; set; }
        public string Sit { get; set; }
        public Guid GetGuid_Contact_Account_Service_CRM { get; set; }
        public Guid GetGuid_CustomerService_Customer { get; set; }
        public Guid FcpProvider_Guid { get; set; }
    }
}
