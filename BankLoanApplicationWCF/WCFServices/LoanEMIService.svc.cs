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
    public class LoanEMIService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        LoanEMIDataContext ledc = new LoanEMIDataContext();

        [OperationContract]
        [WebInvoke(Method = "POST",
      UriTemplate = "/AddLoanEMI",
      RequestFormat = WebMessageFormat.Json,
      ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Bare)]
        public void AddLoanEMI(LoanEMIModel loanEMI)
        {
            ledc.InsertLoanEMI(loanEMI);
        }


        [OperationContract]
        [WebInvoke(Method = "PUT",
       UriTemplate = "/UpdateLoanEMI/{id}",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Bare)]
        public void UpdateLoanEMI(LoanEMIModel loanEMI, string id)
        {
            var loanEMIId = new Guid(id);
            ledc.UpdateLoanEMIUsingId(loanEMI, loanEMIId);
        }

        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetAllLoansEMIs")]
        public List<LoanEMIModel> GetAllLoansEMIs()
        {
            return ledc.GetAllLoanEMIs();
        }

        [OperationContract]
        [WebInvoke(Method = "GET",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetLoanEMIById/{Id}")]
        public LoanEMIModel GetLoanEMIById(string Id)
        {
            var loanEMIId = new Guid(Id);
            return ledc.GetLoanEMIById(loanEMIId);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/DeleteLoanEMI/{id}")]
        public void DeleteLoanEMI(string id)
        {
            var loanEMIId = new Guid(id);
            ledc.DeleteLoanEMI(loanEMIId);
        }
    }
}
