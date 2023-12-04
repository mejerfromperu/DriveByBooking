using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DriveByBooking.Pages.Admin
{
    public class NewCustomerModel : PageModel
    {

        private ICustomerRepository _repo;

        public NewCustomerModel(ICustomerRepository repository)
        {
            _repo = repository;
        }


        [BindProperty]
        public int NewCustomerId { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Der skal v�re et navn")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Der skal v�re mindst to tegn i et navn")]
        public string NewCustomerName { get; set; }


        [BindProperty]
        public string NewCustomerPhoneNumber { get; set; }

        [BindProperty]
        public string NewCustomerUsername { get; set; }

        [BindProperty]
        public string NewCustomerPassword { get; set; }

        [BindProperty]
        public string NewCustomerEmail { get; set; }


        public string ErrorMessage { get; private set; }

        public void OnGet()
        {
        }

        //string email, string phonenumber, int customerId, string username, string password, string name

        public IActionResult OnPost()
        {
            ErrorMessage = "";

            if (!ModelState.IsValid)
            {
                return Page();
            }
            CustomerClass newCustomer = new CustomerClass(NewCustomerEmail, NewCustomerPhoneNumber, NewCustomerId, NewCustomerUsername, NewCustomerPassword, NewCustomerName);

            try
            {
                //KundeRepository repo = new KundeRepository(true);
                _repo.AddCustomer(newCustomer);
            }
            catch (ArgumentException ae)
            {
                ErrorMessage = ae.Message;
                return Page();
            }

            return RedirectToPage("Index");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
