namespace DriveByBooking.ProfilFolder
{
    public class AdminClass : Profile
    {

        //
        // Instance field...
        //
        private bool _admin;

        //
        // Properties...
        //
        public bool Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        //
        // Constructor...
        // Default
        public AdminClass()
        {
            _admin = false;
            _username = string.Empty; 
            _password = string.Empty;
            _name = string.Empty;
        }
        // Constructor
        public AdminClass(bool admin, string username, string password, string name)
        {
            _admin=admin;
            _username=username;
            _password=password;
            _name=name;
        }
    }
}
