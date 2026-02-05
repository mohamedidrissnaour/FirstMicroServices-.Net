using ecom_web_app.Customers.Models;

namespace ecom_web_app.Customers.Services;

public interface ICustomerRepository
{
    Task<List<Customer>> getAllCustomers();
    Task<Customer?> getCustomerById(string id);
    Task<Customer?> CreateCustomer(Customer customer);
    Task<Customer?> UpdateCustomer(string id , Customer customer);
    Task DeleteCustomer(string id);
    
}