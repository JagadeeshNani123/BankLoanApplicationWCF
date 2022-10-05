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
    public class BankAccountDetailsService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        BankDetailsDataContext dc = new BankDetailsDataContext();

        [OperationContract]
        [WebInvoke(Method = "POST",
        UriTemplate = "/AddBankDetails",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        public void AddBankDetails(BankDetails bankDetails)
        {
            dc.InsertBankDetails(bankDetails);
        }


        [OperationContract]
        [WebInvoke(Method = "DELETE",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/DeleteBankDetails/{id}")]

        public void DeleteBankDetails(string id)
        {
            var bankDetailsId = new Guid(id);
            dc.DeleteBankDetails(bankDetailsId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetAllBankDetails")]
        public List<BankDetails> GetAllBankDetails()
        {
            return dc.GetAllBankDetails();
        }


        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetBankDetailsById/{Id}")]
        public BankDetails GetBankDetailsById(string Id)
        {
            var bankDetailsId = new Guid(Id);
            return dc.GetBankDetailsById(bankDetailsId);
        }


        [OperationContract]
        [WebInvoke(Method = "PUT",
        UriTemplate = "/UpdatedCustomer/{id}",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        public void UpdateBankDetails(BankDetails bankDetails, string id)
        {
            var bankDetailsId = new Guid(id);
            dc.UpdateBankDetailsUsingId(bankDetails, bankDetailsId);
        }

    }
}
