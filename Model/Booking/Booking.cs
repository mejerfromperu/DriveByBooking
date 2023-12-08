using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DriveByBooking.Model.Booking
{
    public class Booking
    {
        //
        // Instance fields...
        //
        private DateTime _dateTime;
        private CarClass _car;
        private CustomerClass _customer;
        private int _bookingId;

        //
        //propertieas...
        //

        public int BookingId
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }

        public DateTime DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        public CarClass CarClass
        {
            get { return _car; }
            set { _car = value; }
        }

        public CustomerClass CustomerClass
        {
            get { return _customer; }
            set { _customer = value; }
        }


        //
        // Constructor...
        // Default
        public Booking()
        {
            _car = null;
            _customer = null;
            _bookingId = 0;
            _dateTime = DateTime.MinValue;
        }

        // Constructor...
        public Booking(CarClass car, CustomerClass customer, int bookingid, DateTime dateTime)
        {
            _car = car;
            _customer = customer;
            _bookingId = bookingid;
            _dateTime = dateTime;
        }

        
        public Booking(CarClass car, CustomerClass customer, DateTime datetime)
        {
            _car = car;
            _customer = customer;
            _dateTime = datetime;
        }
        //
        //ToString...
        //
        public override string ToString()
        {
            return $"{{{nameof(BookingId)}={BookingId.ToString()}, {nameof(DateTime)}={DateTime}, {nameof(CarClass)}={CarClass}, {nameof(CustomerClass)}={CustomerClass}}}";
        }
    }
}
