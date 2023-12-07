using DriveByBooking.Model.CarFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages.Admin
{
    public class CarIndexModel : PageModel
    {
        private ICarRepository _carRepo;

        public CarIndexModel(ICarRepository repository)
        {
            _carRepo = repository;
        }

        public List<CarClass> Cars { get; set; }


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



        public void OnGet()
        {
            Cars = _carRepo.GetAllCars();
        }

        public IActionResult OnPostCar()
        {
            return RedirectToPage("NewCar");
        }

        public IActionResult OnPostSearch()
        {
            Cars = _carRepo.Search(SearchLicensePlate, SearchCarName, SearchBrand, SearchPrice, SearchType, SearchCarType, SearchShiftType, SearchEngineType, SearchLocation);
            return Page();
        }

        public IActionResult OnPostSortLicensePlate()
        {
            Cars = _carRepo.SortLicensePlate();
            return Page();
        }

        public IActionResult OnPostSortName()
        {
            Cars = _carRepo.SortName();
            return Page();
        }

    }
}
