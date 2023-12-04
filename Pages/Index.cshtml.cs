using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ICustomerRepository _repo;
            
        public IndexModel(ILogger<IndexModel> logger, ICustomerRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult OnGet()
        {
            if (_repo == null || _repo.CustomerLoggedIn == null)
            {
                return RedirectToPage("/login");
            }
            return Page();
        }



    }
}