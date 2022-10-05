using BankLoanApplicationWCF.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BankLoanApplicationWCF.DataContext
{
    public class BankDetailsDataContext
    {
        SqlConnection con = null;
        public BankDetailsDataContext()
        {
            con = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = BankLoanApplication; Trusted_Connection = True");
            con.Open();
        }
        public void InsertBankDetails(BankDetails bankDetails)
        {
            var id = Guid.NewGuid();

            var query = "Insert into BankDetails values('" + id + "','" + bankDetails.CustomerId + "','" + bankDetails.BankAccountNumber + "','" + bankDetails.BankName + "','" + bankDetails.IFSCCode + "')";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }


        public void UpdateBankDetailsUsingId(BankDetails bankDetails, Guid Id)
        {
            var updatedQuery = "Update BankDetails Set CustomerId='" + bankDetails.CustomerId + "', BankAccountNumber='" + bankDetails.BankAccountNumber + "', BankName='" + bankDetails.BankName + "', IFSCCode='" + bankDetails.IFSCCode + "' Where BankId='" + Id + "'";
            SqlCommand cmd = new SqlCommand(updatedQuery, con);

            cmd.ExecuteNonQuery();
        }

        public void DeleteBankDetails(Guid Id)
        {
            SqlCommand cmd = new SqlCommand("Delete from BankDetails Where BankId='" + Id + "'", con);
            cmd.ExecuteNonQuery();
        }

        public BankDetails GetBankDetailsById(Guid Id)
        {
            var bankDetailssList = GetAllBankDetails();
            var requestedbankDetails = bankDetailssList.FirstOrDefault(x => x.BankId == Id);
            return requestedbankDetails;
        }

        public List<BankDetails> GetAllBankDetails()
        {

            SqlCommand cmd = new SqlCommand("Select * from BankDetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("bankDetailsTable");
            da.Fill(dt);
            List<BankDetails> bankDetailsList = new List<BankDetails>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BankDetails bankDetails = new BankDetails();
                bankDetails.BankId = new Guid(dt.Rows[i]["BankId"].ToString());
                bankDetails.CustomerId = new Guid(dt.Rows[i]["CustomerId"].ToString());
                bankDetails.BankAccountNumber = dt.Rows[i]["BankAccountNumber"].ToString();
                bankDetails.BankName = dt.Rows[i]["BankName"].ToString();
                bankDetails.IFSCCode = dt.Rows[i]["IFSCCode"].ToString();
                bankDetailsList.Add(bankDetails);
            }
            return bankDetailsList;
        }
    }
}
