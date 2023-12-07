using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace DriveByBooking.Pages.Admin
{
    public class IndexModel : PageModel
    {
        //Bare lige en comment for at fiks merge
        // instans af kunde customer repository
        private ICustomerRepository _customerRepo;
        private ICarRepository _carRepo;

        //Dependency Injection
        public IndexModel(ICustomerRepository repository)
        {
            _customerRepo = repository;
        }

        public IndexModel(ICarRepository carRepository)
        {
            _carRepo = carRepository;
        }
       
        // property til View'et
        public List<CustomerClass> Customers { get; set; }

        public List<CarClass> Cars { get; set; }

        //Kunder

        [BindProperty]
        public int? SearchId { get; set; }
        [BindProperty]
        public string? SearchName { get; set; }
        [BindProperty]
        public string? SearchPhoneNumber { get; set; }
        [BindProperty]
        public string? SearchEmail { get; set; }

        //Biler

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
            Customers = _customerRepo.GetEverything();
            Cars = _carRepo.GetAllCars();
        }

        public IActionResult OnPostCustomer()
        {
            return RedirectToPage("NewCustomer");
        }

        public IActionResult OnPostCar()
        {
            return RedirectToPage("NewCars");
        }
       
    

    public IActionResult OnPostSearchCustomer()
        {
            Customers = _customerRepo.Search(SearchId, SearchName, SearchPhoneNumber, SearchEmail) ;
            return Page();
        }

        public IActionResult OnPostSearchCar()
        {
            Cars = _carRepo.Search(SearchLicensePlate, SearchCarName, SearchBrand, SearchPrice, SearchType, SearchCarType, SearchShiftType, SearchEngineType, SearchLocation);
            return Page();
        }

        public IActionResult OnPostSortId()
        {
            Customers = _customerRepo.SortId();
            return Page();
        }

        public IActionResult OnPostSortName()
        {
            Customers = _customerRepo.SortName();
            return Page();
        }

     
    }
}
