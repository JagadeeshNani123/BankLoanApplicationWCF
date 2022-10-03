using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using BankLoanApplicationWCF.Models;

namespace BankLoanApplicationWCF.DataContext
{
    public class LoanEMIDataContext
    {
        SqlConnection con = null;
        public LoanEMIDataContext()
        {
            con = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = BankLoanApplication; Trusted_Connection = True");
            con.Open();
        }
        public void InsertLoanEMI(LoanEMIModel loanEMI)
        {
            var id = Guid.NewGuid();

            var query = "Insert into LoanEMI values('" + id + "','" + loanEMI.LoanId + "','" + loanEMI.EMIAmout + "','" + loanEMI.EMIPaymentDate + "','" + loanEMI.EMINo + "')";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }


        public void UpdateLoanEMIUsingId(LoanEMIModel loanEMI, Guid Id)
        {
            SqlCommand cmd = new SqlCommand("Update LoanEMI Set LoanId='+" + loanEMI.LoanId + "', EMIAmout=" + loanEMI.EMIAmout + "', EMIPaymentDate='" + loanEMI.EMIPaymentDate + "', EMINo='" + loanEMI.EMINo + "' Where Id='" + Id + "'", con);

            cmd.ExecuteNonQuery();
        }

        public void DeleteLoanEMI(Guid Id)
        {
            SqlCommand cmd = new SqlCommand("Delete from LoanEMI Where LoanId='" + Id + "'", con);
            cmd.ExecuteNonQuery();
        }

        public LoanEMIModel GetLoanEMIById(Guid Id)
        {
            var loanEMIsList = GetAllLoanEMIs();
            var requestedLoanEMI = loanEMIsList.FirstOrDefault(x => x.LoanId == Id);
            return requestedLoanEMI;
        }

        public List<LoanEMIModel> GetAllLoanEMIs()
        {

            SqlCommand cmd = new SqlCommand("Select * from LoanEMI", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("LoanEMITable");
            da.Fill(dt);
            List<LoanEMIModel> loanEMIList = new List<LoanEMIModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoanEMIModel loanEMI = new LoanEMIModel();
                loanEMI.EMIId = new Guid(dt.Rows[i]["EMIId"].ToString());
                loanEMI.LoanId = new Guid(dt.Rows[i]["LoanId"].ToString());
                loanEMI.EMIAmout = Convert.ToDecimal(dt.Rows[i]["EMIAmount"].ToString());
                loanEMI.EMIPaymentDate = dt.Rows[i]["EMIPaymentDate"].ToString();
                loanEMI.EMINo = Convert.ToInt32(dt.Rows[i]["EMINo"].ToString());
                loanEMIList.Add(loanEMI);
            }
            return loanEMIList;
        }
    }
}