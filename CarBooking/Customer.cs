using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking
{
    public class Customer: User
    {
        private Guid customerId { get; set; }
        private String customername { get; set; }
        private String password { get; set; }
        private String customerfullname { get; set; }
        private String phone { get; set; }
        private String address { get; set; }
        public Customer(): base()
        {

        }
        public Guid CustomerId
        {
            get { return customerId; }
        }

        public string Customerfullname
        {
            get { return customerfullname; }
            set
            {
                customerfullname = value;
            }
        }

        public string Customername
        {
            get { return customername; }
            set
            {
                customername = value;
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
            }
        }


        public List<Customer> GetCustomer(String field, String condition)
        {
            sqlConnection.Open();
            var dataList = new List<Customer>();
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "Select * from Customer where " + field + " = '" + condition + "';";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var data = new Customer();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    var fiedName = sqlDataReader.GetName(i);
                    var fieldValue = sqlDataReader.GetValue(i);
                    var type = typeof(Customer);
                    var property = type.GetProperty(fiedName, BindingFlags.NonPublic | BindingFlags.Instance);
                    if (property != null && fieldValue != DBNull.Value)
                    {
                        property.SetValue(data, fieldValue);
                    }
                }
                dataList.Add(data);
            }
            sqlConnection.Close();
            return dataList;
        }
       
    }

}
