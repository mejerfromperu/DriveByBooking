using DriveByBooking.Model.ProfilFolder;
using System.Xml.Linq;

namespace DriveByBooking.Service
{
    public class CustomerRepository
    {
        // instans felt (customer list)
        private List<CustomerClass> _repo;

        // en prop
        public List<CustomerClass> customerRepo
        { get { return _repo; } set { _repo = value; } }

        // Konstrukter
        public CustomerRepository(bool mocdata = false)
        {
            _repo = new List<CustomerClass>();

            if (mocdata)
            {
                ShowMocDataRepository();
            }

        }
        private void ShowMocDataRepository()
        {
            _repo.Clear();
            _repo.Add(new CustomerClass("Christianmejer7@gmail.com", "11223344", 1, "MidgetSlayer", "hundogcat", "chris"));
            _repo.Add(new CustomerClass("Christiane23@gmail.com", "83728390", 2, "MidgetHunter", "missecat", "chrissi"));
            _repo.Add(new CustomerClass("starshipcaptain@emailgalaxy.org", "98982626", 3, "MidgetFucker", "katapult", "mejer"));
            _repo.Add(new CustomerClass("pixieprogrammer@emailmagic.com", "44667728", 4, "MidgetFinder", "YESSIR", "mejerfromperu"));
            _repo.Add(new CustomerClass("codingwizard42@techfantasy.net", "87653542", 5, "MidgetTaker", "taxi", "christian"));
        }

        // Metoder

        public CustomerClass GetCustomer(int id)
        {
            foreach (var customer in _repo)
            {
                if (customer.CustomerId == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public void AddCustomer(CustomerClass customer)
        {
            _repo.Add(customer);
        }

        public List<CustomerClass> GetEverything()
        {
            return _repo;
        }

        public CustomerClass Delete(int id)
        {
            int index = _repo.FindIndex(CustomerClass => CustomerClass.CustomerId == id);
            if(index >= 0)
            {
                CustomerClass DeleteCustomer  = _repo[index];
                _repo.RemoveAt(index);
                return DeleteCustomer;
            }
            else
            {
                return null;    
            }
        }

        public CustomerClass Update(CustomerClass customer)
        {
            CustomerClass UpdatePerson = GetCustomer(customer.CustomerId);
            _repo[customer.CustomerId] = customer;
            return UpdatePerson;
        }

        public override string ToString()
        {
            return $"{{{nameof(customerRepo)}={customerRepo}}}";
        }
    }
}
