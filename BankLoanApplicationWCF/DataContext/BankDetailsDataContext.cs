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
        //SqlConnection con = null;
        //public BankDetailsDataContext()
        //{
        //    con = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = BankLoanApplication; Trusted_Connection = True");
        //    con.Open();
        //}
        //public void InsertBankDetails(BankDetails bankDetails)
        //{
        //    var id = Guid.NewGuid();

        //    var query = "Insert into BankDetails values('" + id + "','" + bankDetails.FirstName + "','" + bankDetails.LastName + "','" + bankDetails.EmailAddress + "','" + bankDetails.Password + "','" + bankDetails.EmploymentType + "','" + bankDetails.MaritialStatus + "','" + bankDetails.Income + "','" + bankDetails.DateOfBirth + "','" + bankDetails.AddressProof + "','" + bankDetails.AddressProofNumber + "','" + bankDetails.PanCardNumber + "','" + bankDetails.PhoneNumber + "')";

        //    SqlCommand cmd = new SqlCommand(query, con);
        //    cmd.ExecuteNonQuery();
        //}


        //public void UpdateBankDetailsUsingId(BankDetails bankDetails, Guid Id)
        //{
        //    var updatedQuery = "Update BankDetails Set FirstName='" + bankDetails.FirstName + "', LastName='" + bankDetails.LastName + "', EmailAddress='" + bankDetails.EmailAddress + "', Password='" + bankDetails.Password + "', EmploymentType='" + bankDetails.EmploymentType + "', Income='" + bankDetails.Income + "', DateOfBirth='" + bankDetails.DateOfBirth + "', AddressProof='" + bankDetails.AddressProof + "',AddressProofNumber='" + bankDetails.AddressProofNumber + "', PanCardNumber='" + bankDetails.PanCardNumber + "', PhoneNumber='" + bankDetails.PhoneNumber + "' Where Id='" + Id + "'";
        //    SqlCommand cmd = new SqlCommand(updatedQuery, con);

        //    cmd.ExecuteNonQuery();
        //}

        //public void DeleteBankDetails(Guid Id)
        //{
        //    SqlCommand cmd = new SqlCommand("Delete from BankDetails Where Id='" + Id + "'", con);
        //    cmd.ExecuteNonQuery();
        //}

        //public BankDetails GetBankDetailsById(Guid Id)
        //{
        //    var bankDetailssList = GetAllBankDetails();
        //    var requestedbankDetails = bankDetailssList.FirstOrDefault(x => x.Id == Id);
        //    return requestedbankDetails;
        //}

        //public List<BankDetails> GetAllBankDetails()
        //{

        //    SqlCommand cmd = new SqlCommand("Select * from BankDetails", con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable("bankDetailsTable");
        //    da.Fill(dt);
        //    List<BankDetails> bankDetailsList = new List<BankDetails>();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        BankDetails bankDetails = new BankDetails();
        //        //bankDetails.Id = new Guid(dt.Rows[i]["Id"].ToString());
        //        //bankDetails.FirstName = dt.Rows[i]["FirstName"].ToString();
        //        //bankDetails.LastName = dt.Rows[i]["LastName"].ToString();
        //        //bankDetails.EmailAddress = dt.Rows[i]["EmailAddress"].ToString();
        //        //bankDetails.Password = dt.Rows[i]["Password"].ToString();
        //        //bankDetails.EmploymentType = dt.Rows[i]["EmploymentType"].ToString();
        //        //bankDetails.MaritialStatus = dt.Rows[i]["MaritialStatus"].ToString();
        //        //bankDetails.Income = Convert.ToDecimal(dt.Rows[i]["Income"].ToString());
        //        //bankDetails.DateOfBirth = dt.Rows[i]["DateOfBirth"].ToString();
        //        //bankDetails.AddressProof = dt.Rows[i]["AddressProof"].ToString();
        //        //bankDetails.AddressProofNumber = dt.Rows[i]["AddressProofNumber"].ToString();
        //        //bankDetails.PanCardNumber = dt.Rows[i]["PanCardNumber"].ToString();
        //        //bankDetails.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
        //        //bankDetailsList.Add(bankDetails);
        //    }
        //    return bankDetailsList;
        //}
    //}
}
}