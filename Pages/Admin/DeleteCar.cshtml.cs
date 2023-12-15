using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages.Admin
{
    public class DeleteCarModel : PageModel
    {
        // instans af bil repository
        private ICarRepository _repo;

        //Dependency Injection
        public DeleteCarModel(ICarRepository repository)
        {
            _repo = repository;
        }

        // property til View'et
        public CarClass CarClass { get; private set; }

        // Gør man får den rigtige bil udfra nummerpladen
        public IActionResult OnGet(string licensePlate)
        {
            CarClass = _repo.GetCar(licensePlate);
            return Page();
        }

        // Sletter den korrekte bil udfra nummerpladen
        public IActionResult OnPostDelete(string licensePlate)
        {
            _repo.Remove(licensePlate);
            return RedirectToPage("CarIndex");
        }

        // Gør man kommer tilbage til carindex hvis man vil fortryde
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("CarIndex");
        }
    }
}
