using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {

            //retriveCACS retriveCACS = new retriveCACS();
            //retrive_Merge_CACS retrive_Merge_CACS = new retrive_Merge_CACS();
            //retrive_Merge_CA retrive_Merge_CA = new retrive_Merge_CA();

            //retrive_Merge_CA.Contact_Account("5294021", "162867"); // contact
            //retrive_Merge_CA.Contact_Account("8034444", "650357"); // account

            //retrive_Merge_CACS.Contact_Account_CustomerService("1572046", "791757"); // customerservice
            //retrive_Merge_CACS.Contact_Account_CustomerService("5294021", "162867"); // contact
            //retrive_Merge_CACS.Contact_Account_CustomerService("8034444", "650357"); // account

            //retriveCACS.Contact("5294021", "162867");
            //retriveCACS.Account("8034742", "784933");
            //retriveCACS.CustomerService("6343867", "841231");

            try
            {
                retrive_Merge_CACS retrive_Merge_CACS = new retrive_Merge_CACS();
                List<ModelContact_Account_Service_CRM> retrive_Account_Contact_CustomerService = retrive_Merge_CACS.Contact_Account_CustomerService("1572046", "791757");
                if (retrive_Account_Contact_CustomerService != null && retrive_Account_Contact_CustomerService.Count > 0)
                {
                    foreach (var data in retrive_Account_Contact_CustomerService)
                    {
                        if(data.LogicalName == "contact")
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

                            Guid Create_Contact_id = orgService_Demo.Create(entity);
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

                            Guid Create_Account_id = orgService_Demo.Create(entity);
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

                            Retrive_Merge_AC_GetCustomerService retrive_Merge_AC_GetCustomerService = new Retrive_Merge_AC_GetCustomerService();
                            List<ModelContact_Account_Service_CRM> retrive_Account_Contact = retrive_Merge_AC_GetCustomerService.Get_Contact_Account(guid_customer_CS);
                            if(retrive_Account_Contact != null && retrive_Account_Contact.Count > 0)
                            {
                                foreach (var data_Type in retrive_Account_Contact)
                                {
                                    switch (data_Type.Type_id)
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
                            Guid Create_CustomerService_id = orgService_Demo.Create(entity);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
