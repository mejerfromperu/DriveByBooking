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
            ErrorMessage = "Kunne ikke oprette kunde, da kundenummer er i brug. V�lg gerne et andet kundenummer";

            if (!ModelState.IsValid)
            {
                return Page();
            }
            CustomerClass newCustomer = new CustomerClass(NewCustomerEmail, NewCustomerPhoneNumber, NewCustomerId, NewCustomerUsername, NewCustomerPassword, NewCustomerName, IsAdmin, IsOwner);

            if (CustomerExists(NewCustomerId))
            {
                ModelState.AddModelError("NewCustomer.CustomerId", $"Customer with ID {NewCustomerId} already exists.");
                return Page();
            }

            try
            {
                //KundeRepository repo = new KundeRepository(true);
                _repo.AddCustomer(newCustomer);
                TempData["SuccessMessage"] = $"Customer {NewCustomerName} added successfully with ID {NewCustomerId}.";
            }
            catch (ArgumentException ae)
            {
                ErrorMessage = ae.Message;
                return Page();
            }

            return RedirectToPage("Index");

        }

        private bool CustomerExists(int customerId)
        {
            // Check if the customer ID already exists in the list
            return _repo.CustomerExists(customerId);
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
