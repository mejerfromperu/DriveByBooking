using DriveByBooking.Model.CarFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages.Admin
{
    public class CarIndexModel : PageModel
    {
        // instans af bil repository
        private ICarRepository _carRepo;

        //Dependency Injection
        public CarIndexModel(ICarRepository repository)
        {
            _carRepo = repository;
        }

        // property til View'et
        public List<CarClass> Cars { get; set; }

        // BindProperty til search funktion
        [BindProperty]
        public string? SearchLicensePlate { get; set; }
        [BindProperty]
        public string? SearchCarName { get; set; }
        [BindProperty]
        public string? SearchBrand { get; set; }
        [BindProperty]
        public double? SearchPrice { get; set; }
        [BindProperty]
        public string? SearchType { get; set; }
        [BindProperty]
        public string? SearchCarType { get; set; }
        [BindProperty]
        public string? SearchShiftType { get; set; }
        [BindProperty]
        public string? SearchEngineType { get; set; }
        [BindProperty]
        public string? SearchLocation { get; set; }


        //Hent alle biler når siden læses
        public void OnGet()
        {
            Cars = _carRepo.GetAllCars();
        }

        //Gør at man kan komme til NewCar siden
        public IActionResult OnPostCar()
        {
            return RedirectToPage("NewCar");
        }

        //Gør at man søger når man trykker på knappen
        public IActionResult OnPostSearch()
        {
            Cars = _carRepo.Search(SearchLicensePlate, SearchCarName, SearchBrand, SearchPrice, SearchType, SearchCarType, SearchShiftType, SearchEngineType, SearchLocation);
            return Page();
        }

        //Kalder Sort efter Nummerplade
        public IActionResult OnPostSortLicensePlate()
        {
            Cars = _carRepo.SortLicensePlate();
            return Page();
        }

        //Kalder sort efter navn
        public IActionResult OnPostSortName()
        {
            Cars = _carRepo.SortName();
            return Page();
        }

    }
}
