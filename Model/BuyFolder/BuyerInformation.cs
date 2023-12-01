namespace DriveByBooking.Model.BuyFolder
{
    public class BuyerInformation
    {
        //
        // Istance fields...
        //
        private string _firstName;
        private string _lastName;
        private string _cardnumber;
        private int _month;
        private int _year;
        private int _cvcNumber;
        private string _addresse;
        private string _country;
        private string _cityNumber;

        //
        // Properties...
        //
        public string FirstName 
        { 
            get { return _firstName; } 
            set { _firstName = value; } 
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string CardNumber
        {
            get { return _cardnumber; }
            set { _cardnumber = value; }
        }
        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        public int CVC
        {
            get { return _cvcNumber; }
            set { _cvcNumber = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string Addresse
        {
            get { return _addresse; }
            set { _addresse = value; }
        }
        public string CityNumber
        {
            get { return _cityNumber; }
            set { _cityNumber = value; }
        }

        //
        // Constructor...
        // Default
        public BuyerInformation()
        {
            _firstName = string.Empty;
            _lastName = string.Empty;
            _cardnumber = string.Empty;
            _month = 0;
            _year = 0;
            _cvcNumber = 0;
            _country = string.Empty;
            _addresse = string.Empty;
            _cityNumber = string.Empty;
        }
        // Constructor
        public BuyerInformation(string firstName, string lastName, string cardNumber, int month, int year, int cvcNumber, string country, string addresse, string cityNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _cardnumber = cardNumber;
            _month = month;
            _year = year;
            _cvcNumber = cvcNumber;
            _country = country;
            _addresse = addresse;
            _cityNumber = cityNumber;
        }
    }
}
