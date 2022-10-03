using BankLoanApplicationWCF.DataContext;
using BankLoanApplicationWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace BankLoanApplicationWCF.WCFServices
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CustomerService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        

        CustomerDataContext dc = new CustomerDataContext();

        [OperationContract]
        [WebInvoke(Method = "POST",
        UriTemplate = "/AddCustomer",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        public void AddCustomer(CustomerModel customer)
        {
            dc.InsertCustomer(customer);
        }


        [OperationContract]
        [WebInvoke(Method = "DELETE",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/DeleteCustomer/{id}")]

        public void DeleteCustomer(string id)
        {
            var customerId = new Guid(id);
            dc.DeleteCustomer(customerId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetAllCustomers")]
        public List<CustomerModel> GetAllCustomers()
        {
            return dc.GetAllCustomers();
        }


        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetCustomerById/{Id}")]
        public CustomerModel GetCustomerById(string Id)
        {
            var customerId = new Guid(Id);
            return dc.GetCustomerById(customerId);
        }


        [OperationContract]
        [WebInvoke(Method = "PUT",
        UriTemplate = "/UpdatedCustomer/{id}",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        public void UpdateCustomer(CustomerModel customer, string id)
        {
            var customerId = new Guid(id);
            dc.UpdateCustomerUsingId(customer, customerId);
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
