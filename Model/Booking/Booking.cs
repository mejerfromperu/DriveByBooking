using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DriveByBooking.Model.Booking
{
    public class Booking
    {

        private Date _dateTime;
        private CarClass _car;
        private CustomerClass _customer;
        

        public Date DateTime
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
            set {  _customer = value; } 
        }

        public Booking()
        {
            _car = null;
            _customer = null;
        }

        public Booking (CarClass car, CustomerClass customer)
        {
            _car = car;
            _customer = customer;
            
        }

        public override string ToString()
        {
            return $"{{{nameof(CarClass)}={CarClass}, {nameof(CustomerClass)}={CustomerClass}}}";
        }
    }
}
