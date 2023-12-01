﻿using DriveByBooking.Model.ProfilFolder;

namespace DriveByBooking.Service
{
    public interface ICustomerRepository
    {
        List<CustomerClass> customerRepo { get; set; }

        void AddCustomer(CustomerClass customer);
        CustomerClass Delete(int id);
        CustomerClass GetCustomer(int id);
        List<CustomerClass> GetEverything();
        string ToString();
        CustomerClass Update(CustomerClass customer);
    }
}