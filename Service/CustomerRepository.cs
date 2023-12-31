﻿using DriveByBooking.Model.ProfilFolder;
using System.Text;
using System.Xml.Linq;

namespace DriveByBooking.Service
{
    public class CustomerRepository : ICustomerRepository
    {
        // instans felt (customer list)
        private List<CustomerClass> _repo = new List<CustomerClass>();

        public CustomerClass? CustomerLoggedIn { get; private set; }

        // en prop
        public List<CustomerClass> customerRepo
        { get { return _repo; } set { _repo = value; } }

        // Konstrukter
        public CustomerRepository(bool mocdata = false)
        {
            _repo = new List<CustomerClass>();

            if (mocdata)
            {
                _repo.Add(new CustomerClass("Christianmejer7@gmail.com", "11223344", 1, "MidgetSlayer", "hundogcat", "chris", false, false));
                _repo.Add(new CustomerClass("Christiane23@gmail.com", "83728390", 2, "MidgetHunter", "missecat", "chrissi", true, true));
                _repo.Add(new CustomerClass("starshipcaptain@emailgalaxy.org", "98982626", 3, "MidgetFucker", "katapult", "mejer", false, false));
                _repo.Add(new CustomerClass("pixieprogrammer@emailmagic.com", "44667728", 4, "MidgetFinder", "YESSIR", "mejerfromperu", false, false));
                _repo.Add(new CustomerClass("codingwizard42@techfantasy.net", "87653542", 5, "MidgetTaker", "taxi", "christian", false, false));
            }

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
                throw new ArgumentException($"Kundenummer {customer.CustomerId} findes i forvejen");
                
            }
            

            // If the customer ID is unique, add the customer to the list
            _repo.Add(customer);
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

        public void WriteToJson()
        {
            throw new NotImplementedException();
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

        public List<CustomerClass> SortId()
        {
            throw new NotImplementedException();
        }

        public List<CustomerClass> SortName()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{{{nameof(CustomerLoggedIn)}={CustomerLoggedIn}, {nameof(customerRepo)}={customerRepo}}}";
        }
    }
}
