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
        List<CarClass> CollectFromLocation(string? location);
        List<CarClass> CollectFromPrice(double price);
        List<CarClass> CollectFromShiftType(string shiftType);
        List<CarClass> CollectFromType(string type);
        public CarClass Remove(string licensePlate);
        public List<CarClass> GetAllCars();
        public void WriteToJson();
        public List<CarClass> SortLicensePlate();
        public List<CarClass> SortName();
        List<CarClass> Search(string? licensePlate, string? name, string? brand, double? price, string? type, string? carType, string? shiftType, string? engineType, string? location);
        List<CarClass> SearchPrice(double? price);
    }
}