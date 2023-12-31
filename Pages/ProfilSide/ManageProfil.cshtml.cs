using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DriveByBooking.Pages.ProfilSide
{
    public class ManageProfilModel : PageModel
    {
        private ICustomerRepository _repo;

        public ManageProfilModel(ICustomerRepository repository)
        {
            _repo = repository;
        }

        [BindProperty]
        public int NewCustomerId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der skal v�re et navn")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Der skal v�re mindst to tegn i et navn")]
        public string NewCustomerName { get; set; }

        [BindProperty]
        public string NewCustomerPhoneNumber { get; set; }

        [BindProperty]
        public string NewCustomerEmail { get; set; }

        [BindProperty]
        public string NewCustomerUsername { get; set; }

        [BindProperty]
        public string NewCustomerPassword { get; set; }

        [BindProperty]
        public bool IsAdmin { get; set; }

        [BindProperty]
        public bool IsOwner { get; set; }

        public string ErrorMessage { get; private set; }
        public bool Error { get; private set; }


        public void OnGet(int id)
        {
            ErrorMessage = "";
            Error = false;

            try
            {
                CustomerClass customer = _repo.GetCustomer(id);

                NewCustomerId = customer.CustomerId;
                NewCustomerName = customer.Name;
                NewCustomerPhoneNumber = customer.PhoneNumber;
                NewCustomerEmail = customer.Email;
                NewCustomerUsername = customer.Username;
                NewCustomerPassword = customer.Password;
            }
            catch (KeyNotFoundException knfe)
            {
                ErrorMessage = knfe.Message;
                Error = true;
            }
        }

        public IActionResult OnPostChange()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CustomerClass customer = _repo.GetCustomer(NewCustomerId);

            customer.CustomerId = NewCustomerId;
            customer.Name = NewCustomerName;
            customer.PhoneNumber = NewCustomerPhoneNumber;
            customer.Email = NewCustomerEmail;
            customer.Username = NewCustomerUsername;
            customer.Password = NewCustomerPassword;
            customer.IsAdmin = IsAdmin;
            customer.IsOwner = IsOwner;

            _repo.WriteToJson();
            return RedirectToPage("Index");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
