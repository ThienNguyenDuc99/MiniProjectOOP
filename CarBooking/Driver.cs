using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking
{
    public class Driver : User
    {
        private Guid driverId { get; set; }
        private int isFree { get; set; }

        private String drivername { get; set; }
        private String password { get; set; }
        private String driverfullname { get; set; }
        private String phone { get; set; }
        private String address { get; set; }

        public Guid DriverId
        {
            get { return driverId; }
        }
        public string Driverfullname
        {
            get { return driverfullname; }
            set
            {
                driverfullname = value;
            }
        }

        public string Drivername
        {
            get { return drivername; }
            set
            {
                drivername = value;
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
        public int IsFree
        {
            get { return isFree; }
            set
            {
                isFree = value;
            }
        }
        public Driver() : base()
        {

        }

        public List<Driver> GetDriver()
        {
            sqlConnection.Open();
            var dataList = new List<Driver>();
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "Select * from Driver;";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var data = new Driver();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    var fiedName = sqlDataReader.GetName(i);
                    var fieldValue = sqlDataReader.GetValue(i);
                    var type = typeof(Driver);
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
        public List<Driver> GetDriver(String field, String condition)
        {
            sqlConnection.Open();
            var dataList = new List<Driver>();
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "Select * from Driver where " + field + " = '" + condition + "';";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var data = new Driver();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    var fiedName = sqlDataReader.GetName(i);
                    var fieldValue = sqlDataReader.GetValue(i);
                    var type = typeof(Driver);
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



