using DriveByBooking.Model.ProfilFolder;
using System.Numerics;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public CustomerClass GetCustomer(int customerid)
        {
            var foundCustomer = _repo.FirstOrDefault(k => k.CustomerId == customerid);

            if (foundCustomer != null)
            {
                return foundCustomer;
            }
            else
            {
                // Opdaget en fejl
                throw new KeyNotFoundException($"Kundenummer {customerid} findes ikke");
            }
        }

        public void AddCustomer(CustomerClass customer)
        {
            // Check if the customer ID already exists
            if (CustomerExists(customer.CustomerId))
            {
                Console.WriteLine($"Error: Customer with ID {customer.CustomerId} already exists.");
                return;
            }

            // If the customer ID is unique, add the customer to the list
            _repo.Add(customer);
            WriteToJson();
        }

        public bool CustomerExists(int customerId)
        {
            // Check if the customer ID already exists in the list
            return customerRepo.Any(c => c.CustomerId == customerId);
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
            CustomerClass existingCustomer = GetCustomer(customer.CustomerId);

            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found for update.");
            }

            if (existingCustomer != null)
            {
                _repo[customer.CustomerId] = customer;
                WriteToJson();
            }


            return existingCustomer;
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
            List<CustomerClass> retCustomers = new List<CustomerClass>(GetEverything());

            if (id != null)
            {
                retCustomers = retCustomers.FindAll(c => c.CustomerId == id);
            }

            if (name != null)
            {
                retCustomers = retCustomers.FindAll(c => c.Name.Contains(name));
            }


            if (phoneNumber != null)
            {
                retCustomers = retCustomers.FindAll(c => c.PhoneNumber.Contains(phoneNumber));
            }

            if (email != null)
            {
                retCustomers = retCustomers.FindAll(c => c.Email.Contains(email));
            }

            return retCustomers;
        }

        public List<CustomerClass> Search(int id, string name, string phoneNumber, string email)
        {
            throw new NotImplementedException();
        }


        private bool NumberASC = true;
        public List<CustomerClass> SortId()
        {
            List<CustomerClass> retCustomers = GetEverything();

            retCustomers.Sort(new SortById());

            if (!NumberASC)
            {
                retCustomers.Reverse();
            }
            NumberASC = !NumberASC;

            return retCustomers;
        }

        private class SortById : IComparer<CustomerClass>
        {
            public int Compare(CustomerClass? x, CustomerClass? y)
            {
                if (x == null || y == null)
                {
                    return 0;
                }

                //if (x.KundeNummer > y.KundeNummer)
                //{
                //    return 1;
                //}
                //else
                //{
                //    return -1;
                //}

                return x.CustomerId - y.CustomerId;
            }
        }


        private bool NameASC = true;
        public List<CustomerClass> SortName()
        {
            List<CustomerClass> retCustomers = GetEverything();

            //retKunder.Sort(new SortByName());

            retCustomers.Sort((x, y) => x.Name.CompareTo(y.Name));

            if (!NameASC)
            {
                retCustomers.Reverse();
            }
            NameASC = !NameASC;

            return retCustomers;
        }

        private class SortByName : IComparer<CustomerClass>
        {
            public int Compare(CustomerClass? x, CustomerClass? y)
            {
                if (x == null || y == null)
                {
                    return 0;
                }

                return x.Name.CompareTo(y.Name);
            }
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
