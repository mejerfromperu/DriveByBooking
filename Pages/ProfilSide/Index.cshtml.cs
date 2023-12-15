using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Text;

namespace DriveByBooking.Pages.ProfilSide
{

    //Vi kunne ikke få siden til at vise den logged ind bruger men det her er noget af det vi prøvet af

    public class IndexModel : PageModel
    {
        private ICustomerRepository _customerRepo;

        public IndexModel(ICustomerRepository repository)
        {
            _customerRepo = repository;
        }
        public List<CustomerClass> Customers { get; set; }


        public void OnGet()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return;
            }

            if (!int.TryParse(userIdClaim.Value, out int userId))
            {
                return;
            }

            Customers = _customerRepo.GetEverything();
            var currentCustomer = Customers.FirstOrDefault(c => c.CustomerId == userId);

            Customers = currentCustomer != null ? new List<CustomerClass> { currentCustomer } : new List<CustomerClass>();
        }



        public IActionResult OnPostCustomer()
        {
            return RedirectToPage("ManageProfil");
        }
    }
    }

