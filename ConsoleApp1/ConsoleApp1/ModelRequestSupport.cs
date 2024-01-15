using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
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