using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace DriveByBooking.Pages.Admin
{
    public class DeleteCustomerModel : PageModel
    {
        // instans af kunde repository
        private ICustomerRepository _repo;

        //Dependency Injection
        public DeleteCustomerModel(ICustomerRepository repository)
        {
            _repo = repository;
        }

        // property til View'et
        public CustomerClass CustomerClass { get; private set; }

        // Få den rigtige kunde ud fra kundenummer
        public IActionResult OnGet(int id)
        {
            CustomerClass = _repo.GetCustomer(id);


            return Page();
        }

        //Sletter Kunden ud fra kundenummer
        public IActionResult OnPostDelete(int id)
        {
            _repo.Delete(id);

            return RedirectToPage("Index");
        }

        //Får en tilbage til index, hvis man fortryder
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
