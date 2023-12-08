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
        private ICarRepository _carrepo;
        private ICustomerRepository _customerrepo;
        private IBookingRepository _bookrepo;

        public CustomerClass CustomerClass { get; set; }
        public CarClass Cars { get; set; }
        public loginModel login { get; set; }
        public List<Booking> Books { get; set; }


        public ConfirmModel(IBookingRepository bookrepo)
        {
            _bookrepo = bookrepo;

        }

        public void OnGet()
        {
            Books = _bookrepo.GetAllbookings(); 

        }

    }
}
