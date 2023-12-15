using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DriveByBooking.Pages
{
    public class OpretBrugerModel : PageModel
    {
        // Dependency injection
        private ICustomerRepository _repo;

        // Constructor
        public OpretBrugerModel(ICustomerRepository repository)
        {
            _repo = repository;
        }

        // BindProperties
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

        // HTTP GET method. 
        public void OnGet()
        {
        }

        // HTTP POST method to handle the formsubmission:
        public IActionResult OnPost()
        {
            ErrorMessage = "Kunne ikke oprette kunde, da kundenummer er i brug. Vælg gerne et andet kundenummer";

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
            // Checking if customer exist 
            return _repo.CustomerExists(customerId);
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}

