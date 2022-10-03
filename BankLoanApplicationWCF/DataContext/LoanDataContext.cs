using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using BankLoanApplicationWCF.Models;

namespace BankLoanApplicationWCF.DataContext
{
    public class LoanDataContext
    {
        SqlConnection con = null;
        public LoanDataContext()
        {
            con = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = BankLoanApplication; Trusted_Connection = True");
            con.Open();
        }
        public void InsertLoan(LoanModel loan)
        {
            var id = Guid.NewGuid();

            var query = "Insert into Loan values('" + id + "','" + loan.CustomerId + "','" + loan.LoanType + "','" + loan.LoanAmount + "','" + loan.LoanApprovedDate + "','" + loan.LoanTenure + "','" + loan.IsActive + "')";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }


        public void UpdateLoanUsingId(LoanModel loan, Guid Id)
        {
            SqlCommand cmd = new SqlCommand("Update Loan Set  CustomerId='" + loan.CustomerId + "', LoanType='" + loan.LoanType + "', LoanAmount='" + loan.LoanAmount + "', LoanApprovedDate='" + loan.LoanApprovedDate + "', LoanTenure='" + loan.LoanTenure + "', IsActive='" + loan.IsActive + "' Where LoanId='" + Id + "'", con);

            cmd.ExecuteNonQuery();
        }

        public void DeleteLoan(Guid Id)
        {
            SqlCommand cmd = new SqlCommand("Delete from Loan Where LoanId='" + Id + "'", con);
            cmd.ExecuteNonQuery();
        }

        public LoanModel GetLoanById(Guid Id)
        {
            var loansList = GetAllLoans();
            var requestedLoan = loansList.FirstOrDefault(x => x.LoanId == Id);
            return requestedLoan;
        }

        public List<LoanModel> GetAllLoans()
        {

            SqlCommand cmd = new SqlCommand("Select * from Loan", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("LoanTable");
            da.Fill(dt);
            List<LoanModel> loanList = new List<LoanModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoanModel loan = new LoanModel();
                loan.LoanId = new Guid(dt.Rows[i]["LoanId"].ToString());
                loan.CustomerId = new Guid(dt.Rows[i]["CustomerId"].ToString());
                loan.LoanType = dt.Rows[i]["LoanType"].ToString();
                loan.LoanAmount = Convert.ToDecimal(dt.Rows[i]["LoanAmount"].ToString());
                loan.LoanApprovedDate = dt.Rows[i]["LoanApprovedDate"].ToString();
                loan.LoanTenure = Convert.ToInt32(dt.Rows[i]["LoanTenure"].ToString());
                loan.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"].ToString());
                loanList.Add(loan);
            }
            return loanList;
        }
    }
}