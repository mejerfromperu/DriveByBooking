using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;

namespace DriveByBooking.Service
{
    public class AdminRepository
    {
        private List<CarClass> _carRepo;

        private List<CustomerClass> _customerRepo;

        public CustomerClass? CustomerLoggedIn { get; private set; }

        public List<CarClass> CarRepo
        {
            get { return _carRepo; }
            set { _carRepo = value; }
        }

        public List<CustomerClass> CustomerRepo
        {
            get { return _customerRepo; }
            set { _customerRepo = value; }
        }
    }
}
