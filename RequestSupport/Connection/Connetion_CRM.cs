using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk.Client;

namespace RequestSupport.Connection
{
    public class Connetion_CRM
    {
        public static OrganizationServiceProxy GetOrgService()
        {
            Uri url = new Uri("http://portal.hiweb.ir/Hiweb/XRMServices/2011/Organization.svc");
            ClientCredentials clientCredentials = new ClientCredentials();
            clientCredentials.UserName.UserName = @"hiweb\m.eftekhari";
            clientCredentials.UserName.Password = "M@hammadEF7100";

            //clientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential("*****", "*****", "hiweb");
            //Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy orgService = new Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy(url, null, clientCredentials, null);
            OrganizationServiceProxy orgService = new OrganizationServiceProxy(url, null, clientCredentials, null);
            orgService.Timeout = new TimeSpan(0, 5, 0);
            
            return orgService;
        }

        public static OrganizationServiceProxy GetOrgServiceDemo()
        {
            Uri url = new Uri("http://dynamicv9/Demo/XRMServices/2011/Organization.svc");
            ClientCredentials clientCredentials = new ClientCredentials();
            clientCredentials.UserName.UserName = @"hiweb\m.eftekhari";
            clientCredentials.UserName.Password = "M@hammadEF7100";
            OrganizationServiceProxy orgService_Demo = new OrganizationServiceProxy(url, null, clientCredentials, null);
            orgService_Demo.Timeout = new TimeSpan(0, 5, 0);

            return orgService_Demo;
        }
    }
}
