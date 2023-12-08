using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DriveByBooking.Pages
{
    public class OpretBrugerModel : PageModel
    {
        private ICustomerRepository _repo;

        public OpretBrugerModel(ICustomerRepository repository)
        {
            _repo = repository;
        }


        [BindProperty]
        public int NewCustomerId { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Der skal være et navn")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Der skal være mindst to tegn i et navn")]
        public string NewCustomerName { get; set; }


        [BindProperty]
        public string NewCustomerPhoneNumber { get; set; }

        [BindProperty]
        public string NewCustomerUsername { get; set; }

        [BindProperty]
        public string NewCustomerPassword { get; set; }

        [BindProperty]
        public string NewCustomerEmail { get; set; }

        [BindProperty]
        public bool IsAdmin { get; set; }

        [BindProperty]
        public bool IsOwner { get; set; }


        public string ErrorMessage { get; private set; }

        public void OnGet()
        {
        }



        public IActionResult OnPost()
        {
            ErrorMessage = "";

            if (!ModelState.IsValid)
            {
                return Page();
            }
            CustomerClass newCustomer = new CustomerClass(NewCustomerEmail, NewCustomerPhoneNumber, NewCustomerId, NewCustomerUsername, NewCustomerPassword, NewCustomerName, IsAdmin, IsOwner);

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

