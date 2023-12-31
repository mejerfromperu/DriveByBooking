﻿namespace DriveByBooking.Model.CarFolder
{
    public class CarClass
    {
        //
        // Instance fields...
        //
        private string _licensePlate;
        private string _name;
        private string _brand;
        private double _price;
        private string _type;
        private string _carType;
        private string _shiftType;
        private string _engineType;
        private string _location;
        private bool _isBooked;

        //
        //propertieas...
        //
        public string LicensePlate
        {
            get { return _licensePlate; }
            set { _licensePlate = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string CarType
        {
            get { return _carType; }
            set { _carType = value; }
        }
        public string ShiftType
        {
            get { return _shiftType; }
            set { _shiftType = value; }
        }
        public string EngineType
        {
            get { return _engineType; }
            set { _engineType = value; }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public bool IsBooked
        {
            get { return _isBooked; }
            set { _isBooked = value; }
        }


        //
        // Constructor...
        // Default
        public CarClass()
        {
            _licensePlate = string.Empty;
            _name = string.Empty;
            _brand = string.Empty;
            _price = 0;
            _type = string.Empty;
            _carType = string.Empty;
            _shiftType = string.Empty;
            _engineType = string.Empty;
            _location = string.Empty;
            _isBooked = false;
        }
        // Constructor...
        public CarClass(string licensePlate, string name, string brand, double price, string type, string carType, string shiftType, string engineType, string location, bool isbooked)
        {
            _licensePlate = licensePlate;
            _name = name;
            _brand = brand;
            _price = price;
            _type = type;
            _carType = carType;
            _shiftType = shiftType;
            _engineType = engineType;
            _location = location;
            _isBooked = isbooked;
        }

        public override string ToString()
        {
            return $"{{{nameof(LicensePlate)}={LicensePlate}, {nameof(Name)}={Name}, {nameof(Brand)}={Brand}, {nameof(Price)}={Price.ToString()}, {nameof(Type)}={Type}, {nameof(CarType)}={CarType}, {nameof(ShiftType)}={ShiftType}, {nameof(EngineType)}={EngineType}, {nameof(Location)}={Location}, {nameof(IsBooked)}={IsBooked.ToString()}}}";
        }

        //
        //ToString...
        //


        internal static List<CarClass> where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
