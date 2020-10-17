using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking
{
    public class Booking
    {
        private int bookingId { get; set; }
        private String pickup_city { get; set; }
        private String pickup_location { get; set; }
        private String drop_location { get; set; }

        private Guid driverId { get; set; }
        private Guid customerId { get; set; }
        private DateTime pickup_time { get; set; }

        public Booking(String pickup_location, String pickup_city, String drop_location, Guid customerId, Guid driverId, DateTime pickup_time)
        {
            this.pickup_location = pickup_location;
            this.pickup_city = pickup_city;
            this.drop_location = drop_location;
            this.pickup_time = pickup_time;
            this.customerId = customerId;
            this.driverId = driverId;
        }

        public Booking()
        {
        }
        public Guid DriverId
        {
            get { return driverId; }
        }
        public Guid CustomerId
        {
            get { return customerId; }
        }

        public string Pickup_city
        {
            get { return pickup_city; }
            set
            {
                pickup_city = value;
            }
        }
        public DateTime Pickup_time
        {
            get { return pickup_time; }
            set
            {
                pickup_time = value;
            }
        }
        public string Pickup_location
        {
            get { return pickup_location; }
            set
            {
                pickup_location = value;
            }
        }
        public string Drop_location
        {
            get { return drop_location; }
            set
            {
                drop_location = value;
            }
        }
    }
}
