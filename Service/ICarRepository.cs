using DriveByBooking.Model.CarFolder;

namespace DriveByBooking.Service
{
    public interface ICarRepository
    {
        List<CarClass> List { get; set; }

        public CarClass GetCar(string LicensePlate);

        void Add(CarClass licensePlate);
        void Clear();
        List<CarClass> CollectFromBrand(string brand);
        List<CarClass> CollectFromCarType(string carType);
        List<CarClass> CollectFromEngineType(string engineType);
        List<CarClass> CollectFromLocation(string location);
        List<CarClass> CollectFromPrice(double price);
        List<CarClass> CollectFromShiftType(string shiftType);
        List<CarClass> CollectFromType(string type);
        void Remove(CarClass licensePlate);
        public List<CarClass> GetAllCars();

        List<CarClass> Search(string? location, double? price, string? name);
    }
}