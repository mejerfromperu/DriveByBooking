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
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }
        public bool IsOwner
        {
            get { return _isOwner; }
            set { _isOwner = value; }
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
            _isAdmin = false;
            _isOwner = false;
        }
        // Constructor
        public CustomerClass(string email, string phonenumber, int customerId, string username, string password, string name, bool isAdmin, bool isOwner)
        {
            Email = email;
            PhoneNumber = phonenumber;
            CustomerId = customerId;
            Username = username;
            Password = password;
            Name = name;
            IsAdmin = isAdmin;
            IsOwner = isOwner;
        }

        public override string ToString()
        {
            return $"{{{nameof(Email)}={Email}, {nameof(PhoneNumber)}={PhoneNumber}, {nameof(CustomerId)}={CustomerId.ToString()}, {nameof(Username)}={Username}, {nameof(Password)}={Password}, {nameof(Name)}={Name}, {nameof(IsAdmin)}={IsAdmin.ToString()}, {nameof(IsOwner)}={IsOwner.ToString()}}}";
        }
    }
}
