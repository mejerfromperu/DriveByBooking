using DriveByBooking.Model.ProfilFolder;
using DriveByBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DriveByBooking.Pages.Admin
{
    public class UpdateCustomerModel : PageModel
    {
        // instans af kunde repository
        private ICustomerRepository _repo;

        //Dependency Injection
        public UpdateCustomerModel(ICustomerRepository repository)
        {
            _repo = repository;
        }

        //Property til nye værdier
        [BindProperty]
        public int NewCustomerId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der skal være et navn")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Der skal være mindst to tegn i et navn")]
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

        //Property til fejl besked
        public string ErrorMessage { get; private set; }
        public bool Error { get; private set; }


        //Gør vi kan få de spefikke oplysninger om kunden
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


        //public IActionResult OnPostChange()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    CustomerClass customer = _repo.Update(new CustomerClass(NewCustomerEmail, NewCustomerPhoneNumber, NewCustomerId, NewCustomerUsername, NewCustomerPassword, NewCustomerName, IsAdmin, IsOwner));

        //    return RedirectToPage("Index");
        //}

        //Gør vi kan lave værdierne om til de nye ændrede værdier
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

        // Gør man kommer tilbage til Index, hvis man fortryder
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
