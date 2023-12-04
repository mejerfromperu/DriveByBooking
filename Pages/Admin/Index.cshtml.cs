using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace DriveByBooking.Pages.Admin
{
    public class IndexModel : PageModel
    {

        private ICustomerRepository _repo;

        public IndexModel(ICustomerRepository repository)
        {
            _repo = repository;
        }

        public List<CustomerClass> Customers { get; set; }

        [BindProperty]
        public int? SearchId { get; set; }
        [BindProperty]
        public string? SearchName { get; set; }
        [BindProperty]
        public string? SearchPhoneNumber { get; set; }
        [BindProperty]
        public string? SearchEmail { get; set; }

        public void OnGet()
        {
            Customers = _repo.GetEverything();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("NewCustomer");
        }

        public IActionResult OnPostSearch()
        {
            Customers = _repo.Search(SearchId, SearchName, SearchPhoneNumber, SearchEmail);
            return Page();
        }

        public IActionResult OnPostSortId()
        {
            Customers = _repo.SortId();
            return Page();
        }

        public IActionResult OnPostSortName()
        {
            Customers = _repo.SortName();
            return Page();
        }
    }
}
