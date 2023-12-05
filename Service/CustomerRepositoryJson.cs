using DriveByBooking.Model.ProfilFolder;
using System.Text.Json;

namespace DriveByBooking.Service
{
    public class CustomerRepositoryJson : ICustomerRepository
    {
        // instans felt (customer list)
        private List<CustomerClass> _repo = new List<CustomerClass>();

        public CustomerClass? CustomerLoggedIn { get; private set; }

        // en prop
        public List<CustomerClass> customerRepo
        { get { return _repo; } set { _repo = value; } }

        // Konstrukter
        public CustomerRepositoryJson(bool mocdata = false)
        {
            _repo = ReadFromJson();

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
            WriteToJson();
        }

        public List<CustomerClass> GetEverything()
        {
            return _repo;
        }

        public CustomerClass Delete(int id)
        {
            int index = _repo.FindIndex(CustomerClass => CustomerClass.CustomerId == id);
            if (index >= 0)
            {
                CustomerClass DeleteCustomer = _repo[index];
                _repo.RemoveAt(index);
                WriteToJson();
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
            WriteToJson();
            return UpdatePerson;
        }

        public bool CheckCustomer(string username, string password)
        {
            CustomerClass? foundCustomer = _repo.Find(u => u.Username == username && u.Password == password);

            if (foundCustomer != null)
            {
                CustomerLoggedIn = foundCustomer;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LogoutCustomer()
        {
            CustomerLoggedIn = null;
        }

        public override string ToString()
        {
            return $"{{{nameof(CustomerLoggedIn)}={CustomerLoggedIn}, {nameof(customerRepo)}={customerRepo}}}";
        }

        public List<CustomerClass> Search(int? id, string? name, string? phoneNumber, string? email)
        {
            throw new NotImplementedException();
        }

        public List<CustomerClass> Search(int id, string name, string phoneNumber, string email)
        {
            throw new NotImplementedException();
        }

        public List<CustomerClass> SortId()
        {
            throw new NotImplementedException();
        }

        public List<CustomerClass> SortName()
        {
            throw new NotImplementedException();
        }



    // Json

        private const string FILENAME = "CustomerRepository.json";

        private List<CustomerClass>? ReadFromJson()
        {
            if (File.Exists(FILENAME))
            {
                StreamReader sr = File.OpenText(FILENAME);
                List<CustomerClass>? CustomerClass = JsonSerializer.Deserialize<List<CustomerClass>>(sr.ReadToEnd());
                sr.Close();
                return CustomerClass;
            }
            else
            {
                return new List<CustomerClass>();
            }
        }


        // HAck quick fix - burde lave en metode Edit
        public void WriteToJson()
        {
            FileStream fs = new FileStream(FILENAME, FileMode.Create);
            Utf8JsonWriter writer = new Utf8JsonWriter(fs);
            JsonSerializer.Serialize(writer, _repo);
            fs.Close();
        }


    }
}
