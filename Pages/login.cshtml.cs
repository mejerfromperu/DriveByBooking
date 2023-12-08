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

        public string CurrentUser { get; set; }

        string loggedName;
        string loggedPassword;

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
                loggedName = Username;
                loggedPassword = Password;
                return Page();
            }

            // Assuming you have some authentication mechanism, set the current user.
            SetCurrentUser(Username);

            return RedirectToPage("index");
        }

        // Method to get the currently logged-in customer.
        public string GetLoggedinCustomer()
            {
                // You might want to retrieve the information from your authentication system or session.
                return $"{loggedName} - {loggedPassword}";
            }

            // Set the current user in your authentication or session mechanism.
            private void SetCurrentUser(string username)
            {
                // Implement your logic to set the current user, whether it's using cookies, session, etc.
                CurrentUser = username;
            }
    }
}