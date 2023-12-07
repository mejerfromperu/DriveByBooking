using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;
using Microsoft.AspNetCore.Components.Routing;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace DriveByBooking.Service
{
    public class CarRepository : ICarRepository
    {
        //
        // Instance Field...
        //
        private List<CarClass> _list;

        //
        // Properties...
        //
        public List<CarClass> List
        {
            get { return _list; }
            set { _list = value; }
        }

        //
        // Constructor...
        //
        public CarRepository(bool mockdata = false)
        {
            _list = new List<CarClass>();
            if (mockdata)
            {
                _list.Add(new CarClass("YH40393", "AMG", "Mercedes", 4999.99, "Privat", "Cabriolet", "Automat gear", "Benzin", "søborg"));
                _list.Add(new CarClass("AH40393", "Aygo", "Toyota", 4999.99, "Privat", "Cabriolet", "Automat gear", "Benzin", "søborg"));
                _list.Add(new CarClass("YB40393", "206", "Peugeot", 4999.99, "Privat", "Cabriolet", "Automat gear", "Benzin", "søborg"));
                _list.Add(new CarClass("CH40393", "206cc", "Peugeot", 4999.99, "Privat", "Cabriolet", "Automat gear", "Benzin", "søborg"));
                _list.Add(new CarClass("YG40393", "500", "Fiat", 4999.99, "Privat", "Cabriolet", "Automat gear", "Benzin", "søborg"));
                _list.Add(new CarClass("AB40393", "AMG", "Mercedes", 4999.99, "Privat", "Cabriolet", "Automat gear", "Benzin", "søborg"));
            }
        }

        //
        // Methods...
        // Add new Car
        public void Add(CarClass car)
        {
            _list.Add(car);
        }
        // Remove old Car
        public void Remove(CarClass car)
        {
            _list.Remove(car);
        }
        // Clear the CarList
        public void Clear()
        {
            _list.Clear();
        }


        public List<CarClass> GetAllCars()
        {
            return _list;
        }
        // Collecting from Garage Location
        public List<CarClass> CollectFromLocation(string location)
        {
            List<CarClass> resultList = new List<CarClass>();
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].Location == location)
                {
                    resultList.Add(_list[i]);
                }
            }
            return resultList;
        }
        // Collecting from Cars Type
        public List<CarClass> CollectFromType(string type)
        {
            List<CarClass> resultList = new List<CarClass>();
            for (int i = 0; i < _list.Count; i++)
            {
                if (type == _list[i].Type)
                {
                    resultList.Add(_list[i]);
                }
            }
            return resultList;
        }
        // Collecting from Cars carType
        public List<CarClass> CollectFromCarType(string carType)
        {
            List<CarClass> resultList = new List<CarClass>();
            for (int i = 0; i < _list.Count; i++)
            {
                if (carType == _list[i].CarType)
                {
                    resultList.Add(_list[i]);
                }
            }
            return resultList;
        }
        //collecting from Cars Price
        public List<CarClass> CollectFromPrice(double price)
        {
            List<CarClass> resultList = new List<CarClass>();
            for (int i = 0; i < _list.Count; i++)
            {
                if (price == _list[i].Price)
                {
                    resultList.Add(_list[i]);
                }
            }
            return resultList;
        }
        // Collecting from Cars Brand
        public List<CarClass> CollectFromBrand(string brand)
        {
            List<CarClass> resultlist = new List<CarClass>();
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].Brand == brand)
                {
                    resultlist.Add(_list[i]);
                }
            }
            return resultlist;
        }
        // Collecting from Cars gear shift
        public List<CarClass> CollectFromShiftType(string shiftType)
        {
            List<CarClass> resultlist = new List<CarClass>();
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].ShiftType == shiftType)
                {
                    resultlist.Add(_list[i]);
                }
            }
            return resultlist;
        }
        //Collecting from Cars Engine Type
        public List<CarClass> CollectFromEngineType(string engineType)
        {
            List<CarClass> resultlist = new List<CarClass>();
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].EngineType == engineType)
                {
                    resultlist.Add(_list[i]);
                }
            }
            return resultlist;
        }
        public List<CarClass> Search(string? licensePlate, string? name, string? brand, double? price, string? type, string? carType, string? shiftType, string? engineType, string? location)
        {
            throw new NotImplementedException();
        }

    }
}
