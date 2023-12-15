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
        // instans af bil repository
        private ICarRepository _repo;

        //Dependency Injection
        public NewCarModel(ICarRepository repository)
        {
            _repo = repository;
        }

        //Property til nye værdier
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
        [BindProperty]
        public bool NewIsBooked { get; set; }

        //Property til fejl besked
        public string ErrorMessage { get; private set; }

        public void OnGet()
        {

        }


        //Når man laver ændringerne tager den alle de nye værdier og ændre dem med de gamle til den specifikke bil
        public IActionResult OnPost()
        {
            ErrorMessage = "";

            if (!ModelState.IsValid)
            {
                return Page();
            }
            CarClass newCar = new CarClass(NewLicensePlate, NewCarName, NewBrand, NewPrice, NewType, NewCarType, NewShiftType, NewEngineType, NewLocation, NewIsBooked);

            try
            {
                //KundeRepository repo = new KundeRepository(true);
                _repo.Add(newCar);
            }
            //fejlbesked, hvis noget går galt
            catch (ArgumentException ae)
            {
                ErrorMessage = ae.Message;
                return Page();
            }
            return RedirectToPage("CarIndex");
        }

        //Gør man kommer tilbage til CarIndex, hvis man fortryder
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("CarIndex");
        }
    }
}
