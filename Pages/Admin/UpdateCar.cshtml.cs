using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DriveByBooking.Pages.Admin
{
    public class UpdateCarModel : PageModel
    {
        // instans af bil repository
        private ICarRepository _repo;

        //Dependency Injection
        public UpdateCarModel(ICarRepository repository)
        {
            _repo = repository;
        }

        //Property til nye værdier
        [BindProperty]
        public string NewLicensePlate { get; set; }
        [BindProperty]
        public string NewCarName { get; set; }
        [BindProperty]
        public string NewBrand { get; set; }
        [BindProperty]
        public double NewPrice { get; set; }
        [BindProperty]
        public string NewType { get; set; }
        [BindProperty]
        public string NewCarType { get; set; }
        [BindProperty]
        public string NewShiftType { get; set; }
        [BindProperty]
        public string NewEngineType { get; set; }
        [BindProperty]
        public string NewLocation { get; set; }

        // Property til fejl besked
        public string ErrorMessage { get; private set; }
        public bool Error { get; private set; }

        //Gør vi kan få de spefikke oplysninger om bilen
        public void OnGet(string licensePlate)
        {
            ErrorMessage = "";
            Error = false;

            try
            {
                CarClass car = _repo.GetCar(licensePlate);

                NewLicensePlate = car.LicensePlate;
                NewCarName = car.Name;
                NewBrand = car.Brand;
                NewPrice = car.Price;
                NewType = car.Type;
                NewCarType = car.CarType;
                NewShiftType = car.ShiftType;
                NewEngineType = car.EngineType;
                NewLocation = car.Location;
            }
            catch (KeyNotFoundException knfe)
            {
                ErrorMessage = knfe.Message;
                Error = true;
            }
        }

        //Gør vi kan lave værdierne om til de nye ændrede værdier
        public IActionResult OnPostChange()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CarClass car = _repo.GetCar(NewLicensePlate);

            car.LicensePlate = NewLicensePlate;
            car.Name = NewCarName;
            car.Brand = NewBrand;
            car.Price = NewPrice;
            car.Type = NewType;
            car.CarType = NewCarType;
            car.ShiftType = NewShiftType;
            car.EngineType = NewEngineType;
            car.Location = NewLocation;

            _repo.WriteToJson();

            return RedirectToPage("CarIndex");
        }

        // Gør man kommer tilbage til CarIndex, hvis man fortryder
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("CarIndex");
        }
    }

}
