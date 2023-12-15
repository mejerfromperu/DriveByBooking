using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages
{
    public class loginModel : PageModel
    {

        // Denpendency injection
        private ICustomerRepository _customerRepository;

        // Constructor
        public loginModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        // BindProperties
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        // HTTP GET method for loading page handle:
        public void OnGet()
        {
        }

        // HTTP POST method for form submission handle:
        public IActionResult OnPost()
        {
            if (Username == null || Password == null)
            {
                return Page();
            }

            if (!_customerRepository.CheckCustomer(Username, Password))
            {

                return Page();
            }

            return RedirectToPage("index");
        }
    }
}