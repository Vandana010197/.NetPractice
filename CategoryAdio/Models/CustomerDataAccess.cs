using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace CategoryAdio.Models
{
    public class CustomerDataAccess
    {
        DBConnection DBConnection;
        public CustomerDataAccess()
        {
            DBConnection = new DBConnection();
        }
        public List<Customer> GetCustomers()
        {
            string Sp = "Customers";
            SqlCommand Sql = new SqlCommand(Sp, DBConnection.Connection);
            Sql.CommandType = System.Data.CommandType.StoredProcedure;

            Sql.Parameters.AddWithValue("@action", "SELECT JOIN");

            if (DBConnection.Connection.State == System.Data.ConnectionState.Closed)
            {
                DBConnection.Connection.Open();
            }
            SqlDataReader dr = Sql.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            while (dr.Read())
            {
                Customer Cust = new Customer();
                Cust.Id = (int)dr["Id"];
                Cust.CustomerName = dr["CustomerName"].ToString();
                Cust.Email = dr["Email"].ToString();
                Cust.Contact = dr["Contact"].ToString();
                Cust.ProductId = (int)dr["ProductId"];
                /*Cust.PName = dr["Pname"].ToString();*/
                customers.Add(Cust);

            }
            DBConnection.Connection.Close();
            return customers;
        }
    }
}
