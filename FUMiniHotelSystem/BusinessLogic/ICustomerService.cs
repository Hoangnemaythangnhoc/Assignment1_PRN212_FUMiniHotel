using FUMiniHotelSystem.Models;
using System.Collections.Generic;

namespace FUMiniHotelSystem.BusinessLogic
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer GetCustomerByEmail(string email);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        List<Customer> SearchCustomers(string searchTerm);
        bool ValidateCustomer(Customer customer);
    }
}
