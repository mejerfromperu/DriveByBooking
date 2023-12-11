using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DriveByBooking.Pages.ProfilSide
{
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
            // Retrieve the user's ID from the claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                // Handle the case where the user is not authenticated
                return;
            }

            // Convert the user's ID to an integer (assuming it's an integer)
            if (!int.TryParse(userIdClaim.Value, out int userId))
            {
                // Handle the case where the user ID is not a valid integer
                return;
            }

            // Retrieve all customers using the repository
            Customers = _customerRepo.GetEverything();

            // Find the specific customer based on the user's ID
            var currentCustomer = Customers.FirstOrDefault(c => c.CustomerId == userId);

            // Set the current customer in the property for further use in the page
            // You might also want to handle the case when currentCustomer is null
            Customers = currentCustomer != null ? new List<CustomerClass> { currentCustomer } : new List<CustomerClass>();
        }



            public IActionResult OnPostCustomer()
        {
            return RedirectToPage("ManageProfil");
        }
    }
    }

