using DriveByBooking.Model.CarFolder;
using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DriveByBooking.Pages.Admin
{
    public class DeleteCarModel : PageModel
    {
        private ICarRepository _repo;

        public DeleteCarModel(ICarRepository repository)
        {
            _repo = repository;
        }
        public CarClass CarClass { get; private set; }

        public IActionResult OnGet(string licensePlate)
        {
            CarClass = _repo.GetCar(licensePlate);
            return Page();
        }

        public IActionResult OnPostDelete(string licensePlate)
        {
            _repo.Remove(licensePlate);
            return RedirectToPage("CarIndex");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("CarIndex");
        }
    }
}
