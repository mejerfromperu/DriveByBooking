using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DriveByBooking.Pages.Admin
{
    public class NewCarModel : PageModel
    {
        private ICarRepository _repo;

        public NewCarModel(ICarRepository repository)
        {
            _repo = repository;
        }


        [BindProperty]
        public string NewLicensePlate { get; set; }
        [BindProperty]
        public string NewCarName { get; set; }
        [BindProperty]
        public string NewBrand { get; set; }
        [BindProperty]
        public double NewPrice { get; set; }
        [BindProperty]
        public string NewType { get; set; }
        [BindProperty]
        public string NewCarType { get; set; }
        [BindProperty]
        public string NewShiftType { get; set; }
        [BindProperty]
        public string NewEngineType { get; set; }
        [BindProperty]
        public string NewLocation { get; set; }

        public string ErrorMessage { get; private set; }

        public void OnGet()
        {
        }



        public IActionResult OnPost()
        {
            ErrorMessage = "";

            if (!ModelState.IsValid)
            {
                return Page();
            }
            CarClass newCar = new CarClass(NewLicensePlate, NewCarName, NewBrand, NewPrice, NewType, NewCarType, NewShiftType, NewEngineType, NewLocation);

            try
            {
                //KundeRepository repo = new KundeRepository(true);
                _repo.Add(newCar);
            }
            catch (ArgumentException ae)
            {
                ErrorMessage = ae.Message;
                return Page();
            }

            return RedirectToPage("CarIndex");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("CarIndex");
        }
    }
}
