using DriveByBooking.Model.CarFolder;

namespace DriveByBooking.Service
{
    public interface ICarRepository
    {
        List<CarClass> List { get; set; }

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

        List<CarClass> Search(string? licensePlate, string? name, string? brand, double? price, string? type, string? carType, string? shiftType, string? engineType, string? location);
    }
}