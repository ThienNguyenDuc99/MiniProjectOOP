using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking
{
    public class User
    {
        protected static string connectString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=CarBooking;Integrated Security=True";
        protected static SqlConnection sqlConnection;
        protected static SqlCommand sqlCommand;

        public User()
        {
            sqlConnection = new SqlConnection(connectString);
            sqlCommand = sqlConnection.CreateCommand();
        }

        public List<Booking> GetBooking(String  field, String condition)
        {
            sqlConnection.Open();
            var dataList = new List<Booking>();
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "select Booking.*, Customer.customername, Customer.customerfullname, Driver.drivername, Driver.driverfullname, Driver.phone " +
            "from Booking INNER JOIN Customer On Booking.customerId = Customer.customerId INNER JOIN Driver On Booking.driverId = Driver.driverId Where " + field + " = '" + condition + "'  ;";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var data = new Booking();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    var fiedName = sqlDataReader.GetName(i);
                    var fieldValue = sqlDataReader.GetValue(i);
                    var type = typeof(Booking);
                    var property = type.GetProperty(fiedName, BindingFlags.NonPublic | BindingFlags.Instance);
                    if (property != null && fieldValue != DBNull.Value)
                    {
                        property.SetValue(data, fieldValue);
                        var x = 1;
                    }
                }
                dataList.Add(data);
            }
            sqlConnection.Close();
            return dataList;
        }
        public bool Login(String field, String username, String password)
        {
            sqlConnection.Open();
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "Select * from Customer Where customername = '" + username + "' And password = '" + password + "'";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                return true;
            }
            else
            {
                sqlConnection.Close();
                return false;
            }
        }
        public int GetCountBooking()
        {
            sqlConnection.Open();
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "SELECT Max(BookingId) FROM Booking;";
            var sqlData = sqlCommand.ExecuteScalar();
            var a = int.Parse(sqlData.ToString());
            sqlConnection.Close();
            return a;
        }

        public void AddBooking(Booking booking)
        {
            sqlConnection.Open();
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = " INSERT INTO Booking (pickup_city, pickup_location,drop_location,driverId, customerId, pickup_time)"
            + "VALUES(N'"+ booking.Pickup_city +"', N'"+ booking.Pickup_location +"', N'"+ booking.Drop_location +"', '"+ booking.DriverId +"', '"+booking.CustomerId+"', '"+booking.Pickup_time+"'); ";
            var sqlDataReader = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
