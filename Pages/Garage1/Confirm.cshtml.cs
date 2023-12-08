using DriveByBooking.Model.Booking;
using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages.Garage1
{
    public class ConfirmModel : PageModel
    {
        private loginModel loginModel;
        private ICarRepository _carrepo;
        private ICustomerRepository _customerrepo;
        private IBookingRepository _bookrepo;


        
        public CustomerClass CustomerClass { get; set; }
        public CarClass Cars { get; set; }
        public Booking book { get; set; }
        public loginModel login { get; set; }





        public IActionResult OnGet(string licensplate)
        {
            Cars = _carrepo.GetCar(licensplate); // Adjust this based on your repository method to get a list of cars

            return Page();
        }
    }
}
