using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using BankLoanApplicationWCF.Models;

namespace BankLoanApplicationWCF.DataContext
{
    public class CustomerDataContext
    {
        SqlConnection con = null;
        public CustomerDataContext()
        {
            con = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = BankLoanApplication; Trusted_Connection = True");
            con.Open();
        }
        public void InsertCustomer(CustomerModel customer)
        {
            var id = Guid.NewGuid();

            var query = "Insert into Customer values('" + id + "','" + customer.FirstName + "','" + customer.LastName + "','" + customer.EmailAddress + "','" + customer.Password + "','" + customer.EmploymentType + "','" + customer.MaritialStatus + "','" + customer.Income + "','" + customer.DateOfBirth + "','" + customer.AddressProof + "','" + customer.AddressProofNumber + "','" + customer.PanCardNumber + "','" + customer.PhoneNumber + "')";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }


        public void UpdateCustomerUsingId(CustomerModel customer, Guid Id)
        {
            var updatedQuery = "Update Customer Set FirstName='" + customer.FirstName + "', LastName='" + customer.LastName + "', EmailAddress='" + customer.EmailAddress + "', Password='" + customer.Password + "', EmploymentType='" + customer.EmploymentType + "', Income='" + customer.Income + "', DateOfBirth='" + customer.DateOfBirth + "', AddressProof='" + customer.AddressProof + "',AddressProofNumber='" + customer.AddressProofNumber + "', PanCardNumber='" + customer.PanCardNumber + "', PhoneNumber='" + customer.PhoneNumber + "' Where Id='" + Id + "'";
            SqlCommand cmd = new SqlCommand(updatedQuery, con);

            cmd.ExecuteNonQuery();
        }

        public void DeleteCustomer(Guid Id)
        {
            SqlCommand cmd = new SqlCommand("Delete from Customer Where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
        }

        public CustomerModel GetCustomerById(Guid Id)
        {
            var customersList = GetAllCustomers();
            var requestedCustomer = customersList.FirstOrDefault(x => x.Id == Id);
            return requestedCustomer;
        }

        public List<CustomerModel> GetAllCustomers()
        {

            SqlCommand cmd = new SqlCommand("Select * from Customer", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("CustomerTable");
            da.Fill(dt);
            List<CustomerModel> customerList = new List<CustomerModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerModel customer = new CustomerModel();
                customer.Id = new Guid(dt.Rows[i]["Id"].ToString());
                customer.FirstName = dt.Rows[i]["FirstName"].ToString();
                customer.LastName = dt.Rows[i]["LastName"].ToString();
                customer.EmailAddress = dt.Rows[i]["EmailAddress"].ToString();
                customer.Password = dt.Rows[i]["Password"].ToString();
                customer.EmploymentType = dt.Rows[i]["EmploymentType"].ToString();
                customer.MaritialStatus = dt.Rows[i]["MaritialStatus"].ToString();
                customer.Income = Convert.ToDecimal(dt.Rows[i]["Income"].ToString());
                customer.DateOfBirth = dt.Rows[i]["DateOfBirth"].ToString();
                customer.AddressProof = dt.Rows[i]["AddressProof"].ToString();
                customer.AddressProofNumber = dt.Rows[i]["AddressProofNumber"].ToString();
                customer.PanCardNumber = dt.Rows[i]["PanCardNumber"].ToString();
                customer.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
                customerList.Add(customer);
            }
            return customerList;
        }
    }
}