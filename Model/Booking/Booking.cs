using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;

namespace DriveByBooking.Model.Booking
{
    public class Booking
    {

        private CarClass _car;
        private CustomerClass _customer;


        public CarClass Car
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


    }
}
