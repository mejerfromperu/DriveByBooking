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

        // Repositories for data (dependency injection)
        private ICarRepository _carrepo;
        private ICustomerRepository _customerrepo;
        private IBookingRepository _bookrepo;

        // Properties
        public CustomerClass CustomerClass { get; set; }
        public CarClass Cars { get; set; }
        public loginModel login { get; set; }
        public List<Booking> Books { get; set; }

        // Constructor
        public ConfirmModel(IBookingRepository bookrepo, ICustomerRepository customerRepo, ICarRepository carRepo)
        {
            _bookrepo = bookrepo;
            _customerrepo = customerRepo;
            _carrepo = carRepo;
        }

        // Bindproperty
        [BindProperty]
        public string OrderCustomerUsername { get; set; }

        public string ErrorMessage { get; private set; }

        public IActionResult OnGet(string licensplate, string username)
        {
            Books = _bookrepo.GetAllbookings();
            Cars = _carrepo.GetCar(licensplate); // Adjust this based on your repository method to get a list of cars
            CustomerClass = _customerrepo.CustomerLoggedIn;

            return Page();
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Booking newBooking = new Booking(Cars, CustomerClass, DateTime.Now);

            try
            {
                //KundeRepository repo = new KundeRepository(true);
                _bookrepo.AddBooking(newBooking);
                TempData["SuccessMessage"] = $"Booking {newBooking} added successfully";
            }
            catch (ArgumentException ae)
            {
                ErrorMessage = ae.Message;
                return Page();
            }

            return RedirectToPage("Index");

        }
    }
}