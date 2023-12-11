using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Model.Booking;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System;

namespace DriveByBooking.Pages.Garage1
{
    public class BestillingModel : PageModel
    {
        private loginModel loginModel;
        private ICarRepository _carrepo;
        private ICustomerRepository _customerrepo;
        private IBookingRepository _bookrepo;

        public CarClass Cars { get; private set; }
        public CustomerClass Customer { get; private set; }

        public Booking booking { get; private set; }

        public BestillingModel(ICarRepository carRepository)
        {
            _carrepo = carRepository;
        }


         
        public IActionResult OnGet(string licensplate)
        {
            Cars = _carrepo.GetCar(licensplate); // Adjust this based on your repository method to get a list of cars

            return Page();
        }
        public void OnPost()
        {

            if (!ModelState.IsValid)
            {

            }

            Booking newBooking = new Booking(Cars, Customer, DateTime.Now);

            try
            {
                //KundeRepository repo = new KundeRepository(true);
                _bookrepo.AddBooking(newBooking);
            }
            catch (ArgumentException ae)
            {

            }

        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}

