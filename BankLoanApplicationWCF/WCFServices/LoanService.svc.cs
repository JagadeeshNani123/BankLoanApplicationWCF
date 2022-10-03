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
    public class LoanService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        LoanDataContext lc = new LoanDataContext();
        [OperationContract]
        [WebInvoke(Method = "POST",
       UriTemplate = "/AddLoan",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Bare)]
        public void AddLoan(LoanModel loan)
        {
            lc.InsertLoan(loan);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/DeleteLoan/{id}")]
        public void DeleteLoan(string id)
        {
            var loanId = new Guid(id);
            lc.DeleteLoan(loanId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetAllLoans")]
        public List<LoanModel> GetAllLoans()
        {
            return lc.GetAllLoans();
        }

        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetLoanById/{Id}")]
        public LoanModel GetLoanById(string Id)
        {
            var loanId = new Guid(Id);
            return lc.GetLoanById(loanId);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT",
       UriTemplate = "/UpdateLoan/{id}",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Bare)]
        public void UpdateLoan(LoanModel loan, string id)
        {
            var loanId = new Guid(id);
            lc.UpdateLoanUsingId(loan, loanId);
        }
    }
}
