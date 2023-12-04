using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages
{
    public class loginModel : PageModel
    {
        private ICustomerRepository _customerRepository;

        public loginModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }


        public void OnGet()
        {
        }


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

