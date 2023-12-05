using DriveByBooking.Model.ProfilFolder;
using System.Text;

namespace DriveByBooking.Service
{
    public interface ICustomerRepository
    {
        CustomerClass? CustomerLoggedIn { get; }
        List<CustomerClass> customerRepo { get; set; }
        void AddCustomer(CustomerClass customer);
        CustomerClass Delete(int id);
        CustomerClass GetCustomer(int id);
        List<CustomerClass> GetEverything();
        string ToString();
        CustomerClass Update(CustomerClass customer);
        public bool CheckCustomer(string username, string password);
        public void LogoutCustomer();
        void WriteToJson();
        List<CustomerClass> Search(int? id, string? name, string? phoneNumber, string? email);
        List<CustomerClass> SortId();
        List<CustomerClass> SortName();
    }
}
