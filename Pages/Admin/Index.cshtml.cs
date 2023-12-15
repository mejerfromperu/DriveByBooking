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
        // instans af kunde repository
        private ICustomerRepository _customerRepo;

        //Dependency Injection
        public IndexModel(ICustomerRepository repository)
        {
            _customerRepo = repository;
        }

        // property til View'et
        public List<CustomerClass> Customers { get; set; }

        // BindProperty til search funktion

        [BindProperty]
        public int? SearchId { get; set; }
        [BindProperty]
        public string? SearchName { get; set; }
        [BindProperty]
        public string? SearchPhoneNumber { get; set; }
        [BindProperty]
        public string? SearchEmail { get; set; }


        //Hent alle kunder når siden læses
        public void OnGet()
        {
            Customers = _customerRepo.GetEverything();
        }

        //Gør at man kan komme til NewCustomer siden
        public IActionResult OnPostCustomer()
        {
            return RedirectToPage("NewCustomer");
        }

        //Gør at man søger når man trykker på knappen
        public IActionResult OnPostSearchCustomer()
        {
            Customers = _customerRepo.Search(SearchId, SearchName, SearchPhoneNumber, SearchEmail);
            return Page();
        }

        //Kalder Sort efter ID
        public IActionResult OnPostSortId()
        {
            Customers = _customerRepo.SortId();
            return Page();
        }

        //Kalder sort efter navn
        public IActionResult OnPostSortName()
        {
            Customers = _customerRepo.SortName();
            return Page();
        }


    }
}
