namespace DriveByBooking.Model.ProfilFolder
{
    public class CustomerClass : Profile
    {
        //
        // Instance fields...
        //
        private string _email;
        private string _phonenumber;
        private int _customerId;

        //
        // Properties
        //
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string PhoneNumber
        {
            get { return _phonenumber; }
            set { _phonenumber = value; }
        }
        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        //
        // Constructor...
        // Default
        public CustomerClass()
        {
            _email = string.Empty;
            _phonenumber = string.Empty;
            _customerId = 0;
            _username = string.Empty;
            _password = string.Empty;
            _name = string.Empty;
        }
        // Constructor
        public CustomerClass(string email, string phonenumber, int customerId, string username, string password, string name)
        {
            Email = email;
            PhoneNumber = phonenumber;
            CustomerId = customerId;
            Username = username;
            Password = password;
            Name = name;
        }
    }
}
