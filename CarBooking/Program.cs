using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking
{
    public class Program
    {
        public static String username;
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Login();
            Menu();
            Driver driver = new Driver();
            driver.GetDriver();
            driver.GetDriver("drivername", "LX01");
            Customer cus = new Customer();
            cus.GetCustomer("customername", "KH01");
            cus.GetBooking("drivername", "LX02");
        }

        public static void Login()
        {
            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            Customer customer = new Customer();
            if (customer.Login("Customer", username, password))
            {
                Console.WriteLine("Login successful!");
            }
            else
            {
                Console.WriteLine("Login failed!");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Re-login: ");
                Login();
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }

        public static void Menu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Booking");
            Console.WriteLine("2. Show infor");
            Console.WriteLine("3. Show booking:");
            Console.WriteLine("4. Get Free Driver:");
            Console.WriteLine("5. Logout:");
            Console.WriteLine("-----------------------");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Booking();
                Menu();
            }
            if (input == "2")
            {
                ShowInfor();
                Menu();
            }
            if (input == "3")
            {
                ShowBooking();
                Menu();
            }
            if (input == "4")
            {
                GetFreeDriver();
                Menu();
            }
            if (input == "5")
            {
                Logout();
                Menu();
            }
        }

        public static void Booking()
        {
            Driver driver = new Driver();
            GetFreeDriver();
            Console.Write("Choose driver:");
            var drivername = Console.ReadLine();
            Console.Write("Choose city:");
            var pickup_city = Console.ReadLine();
            Console.Write("Choose pickup location:");
            var pickup_location = Console.ReadLine();
            Console.Write("Chọn drop location:");
            var drop_location = Console.ReadLine();
            Console.Write("Choose pickup time:");
            var pickup_time = DateTime.Parse(Console.ReadLine());
            Customer customer = new Customer();
            var cusdata = customer.GetCustomer("customername", username);
            var dridata = driver.GetDriver("drivername", drivername);
            User user = new User();
            var BookingId = user.GetCountBooking() + 1;
            var customerId = cusdata[0].CustomerId;
            var driverId = dridata[0].DriverId;
            Booking booking = new Booking(pickup_location, pickup_city, drop_location, cusdata[0].CustomerId, dridata[0].DriverId, pickup_time);
            user.AddBooking(booking);
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }

        public static void ShowInfor()
        {
            Console.WriteLine("------------------------------------");
            Customer customer = new Customer();
            var data = customer.GetCustomer( "customername", username);
            Console.Write("No");
            Console.Write("     _____    ");
            Console.Write("Username");
            Console.Write("     _____    ");
            Console.Write("Fullname");
            Console.Write("     _____    ");
            Console.Write("Phone");
            Console.Write("     _____    ");
            Console.WriteLine("Address");
            Console.Write(1);
            Console.Write("     ______    ");
            Console.Write(data[0].Customername);
            Console.Write("     ______    ");
            Console.Write(data[0].Customerfullname);
            Console.Write("     _____    ");
            Console.Write(data[0].Phone);
            Console.Write("     _____    ");
            Console.WriteLine(data[0].Address);
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }

        public static void ShowBooking()
        {
            Console.WriteLine();
            Customer customer = new Customer();
            Driver driver = new Driver();
            var data = customer.GetBooking("customername", username);
            Console.Write("No");
            Console.Write("    _____   ");
            Console.Write("DriverName");
            Console.Write("    _____    ");
            Console.Write("DriverPhone");
            Console.Write("    _____    ");
            Console.Write("pickup_city");
            Console.Write("    _____    ");
            Console.Write("pickup_location");
            Console.Write("    ____   ");
            Console.Write("drop_location");
            Console.Write("     _____    ");
            Console.WriteLine("pickup_time");
            for (int i = 0; i < data.Count; i++)
            {
                var driverdata = driver.GetDriver("driverId", data[i].DriverId.ToString());
                Console.WriteLine($"{1}     _____    {driverdata[0].Driverfullname}     ______    {driverdata[0].Phone}     ______    {data[i].Pickup_city}      ______    {data[i].Pickup_location}     ______    {data[i].Drop_location}     ______     {data[i].Pickup_time}");
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }

        public static void GetFreeDriver()
        {
            Console.WriteLine("-----------------------");
            Driver driver = new Driver();
            var data = driver.GetDriver("isFree", "1");
            Console.Write("No");
            Console.Write("     _____    ");
            Console.Write("Username");
            Console.Write("     _____    ");
            Console.Write("Fullname");
            Console.Write("     _____    ");
            Console.Write("Phone");
            Console.Write("     _____    ");
            Console.Write("Address");
            Console.Write("     _____    ");
            Console.WriteLine("IsFree  ");
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine($"{1}     _____    {data[i].Drivername}     _____    {data[i].Driverfullname}     _____    {data[i].Phone}     _____    {data[i].Address}     _____    {data[i].IsFree}");
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }
        public static void Logout()
        {
            username = "";
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Login();
        }
    }
}


