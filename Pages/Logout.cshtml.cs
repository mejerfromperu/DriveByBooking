using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages
{
    public class LogoutModel : PageModel
    {

        private ICustomerRepository _customerRepository;

        public LogoutModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult OnGet()
        {
            _customerRepository.LogoutCustomer();   

            return RedirectToPage("Index");
        }
    }
}
