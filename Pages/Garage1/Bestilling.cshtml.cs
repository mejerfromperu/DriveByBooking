using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages.Garage1
{
    public class BestillingModel : PageModel
    {
        private ICarRepository _carrepo;
        private ICustomerRepository _customerrepo;

        public CarClass Cars { get; private set; }

        public BestillingModel(ICarRepository carRepository)
        {
            _carrepo = carRepository;
        }

        public IActionResult OnGet(string licensplate)
        {
            Cars = _carrepo.GetCar(licensplate); // Adjust this based on your repository method to get a list of cars

            return Page();
        }


        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}

