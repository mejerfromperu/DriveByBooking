using DriveByBooking.Model.CarFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages.Booking
{
    public class IndexModel : PageModel
    {

        private ICarRepository _carRepo;

        public IndexModel(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }

        public List<CarClass> Cars { get; set; }





        public void OnGet()
        {
        }
    }
}
