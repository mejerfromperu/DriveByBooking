using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace DriveByBooking.Pages.Admin
{
    public class DeleteCustomerModel : PageModel
    {
        private ICustomerRepository _repo;

        public DeleteCustomerModel(ICustomerRepository repository)
        {
            _repo = repository;
        }



        public CustomerClass CustomerClass { get; private set; }



        public IActionResult OnGet(int id)
        {
            CustomerClass = _repo.GetCustomer(id);


            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            _repo.Delete(id);

            return RedirectToPage("Index");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
