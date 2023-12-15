using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages
{
    public class LogoutModel : PageModel
    {
        // Dependency injection
        private ICustomerRepository _customerRepository;

        // Constructor
        public LogoutModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        // HTTP GET method to handle LogOut 
        public IActionResult OnGet()
        {
            _customerRepository.LogoutCustomer();   
            return RedirectToPage("Index");
        }
    }
}
