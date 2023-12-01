namespace DriveByBooking.ProfilFolder
{
    public class OwnerClass : Profile
    {
        //
        // Instance fields...
        //
        private bool _owner;

        //
        // Properties...
        //
        public bool Owner
        { 
            get { return _owner; } 
            set {  _owner = value; } 
        }

        //
        // Constructor...
        // Default
        public OwnerClass()
        {
            _owner = false;
            _username = string.Empty; 
            _password = string.Empty;
            _name = string.Empty;
        }
        // Constructor
        public OwnerClass(bool owner, string username, string password, string name)
        {
            _owner = owner;
            _username = username;
            _password = password;
            _name = name;
        }


    }
}
