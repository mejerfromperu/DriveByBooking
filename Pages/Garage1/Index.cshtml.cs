using DriveByBooking.Model.CarFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages.Garage1
{
    public class IndexModel : PageModel
    {
        private ICarRepository _list;

        public IndexModel(ICarRepository list)
        {
            _list = list;
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
            Cars = _list.GetAllCars();
        }

        public RedirectToPageResult OnPost()
        {
            return RedirectToPage("Index");
        }

        public IActionResult OnPostSearch()
        {
            Cars = _list.Search(SearchLicensePlate, SearchCarName, SearchBrand, SearchPrice, SearchType, SearchCarType, SearchShiftType, SearchEngineType, SearchLocation);
            return Page();
        }

        public RedirectToPageResult OnPostOrder()
        {
            return RedirectToPage("Index");
        }




    }
}
