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
        public string? SearchName { get; set; }

        [BindProperty]
        public double? SearchPrice { get; set; }

        [BindProperty]
        public string? SearchBrand { get; set; }

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
            Cars = _list.Search(SearchName, SearchPrice, SearchBrand);
            return Page();
        }




    }
}
