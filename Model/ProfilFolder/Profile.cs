namespace DriveByBooking.Model.ProfilFolder
{
    public class Profile
    {

        //
        // Instance field...
        //
        protected string _username;
        protected string _password;
        protected string _name;
        protected bool _isAdmin;
        protected bool _isOwner;
        //
        // Properties...
        //
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
        public Profile()
        {
            _username = string.Empty;
            _password = string.Empty;
            _name = string.Empty;
            _isAdmin = false;
            _isOwner = false;
        }
        // Constructor
        public Profile(string username, string password, string name, bool isadmin, bool isowner)
        {
            _username = username;
            _password = password;
            _name = name;
            _isAdmin = isadmin;
            _isOwner = isowner;
        }

        //
        // Methods...
        //

        

    }
}
