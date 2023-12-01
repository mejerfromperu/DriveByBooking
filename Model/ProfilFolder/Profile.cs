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

        //
        // Constructor...
        // Default
        public Profile()
        {
            _username = string.Empty;
            _password = string.Empty;
            _name = string.Empty;
        }
        // Constructor
        public Profile(string username, string password, string name)
        {
            _username = username;
            _password = password;
            _name = name;
        }

        //
        // Methods...
        //
    }
}
