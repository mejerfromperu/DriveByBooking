using DriveByBooking.Model.Booking;
using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages.Admin
{
    public class BookingIndexModel : PageModel
    {
        //Bare lige en comment for at fiks merge
        // instans af kunde customer repository
        private ICustomerRepository _customerRepo;
        private ICarRepository _carRepo;
        private IBookingRepository _bookRepo;

        //Dependency Injection
        public BookingIndexModel(IBookingRepository repository)
        {
            _bookRepo = repository;
        }

        // property til View'et
        public List<Booking> Books { get; set; }

        //Henter alle bookinger ned
        public void OnGet()
        {
            Books = _bookRepo.GetAllbookings();
        }
    }
}
