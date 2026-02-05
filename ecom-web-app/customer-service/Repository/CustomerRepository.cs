using ecom_web_app.Configurations;
using ecom_web_app.Customers.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ecom_web_app.Customers.Services;

    
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> customers;
        

        public CustomerRepository(IOptions<MongoDBSettings> settings)
        {
            // creation du client MongoDB
            var client = new MongoClient(settings.Value.ConnectionString);
            //selectionner la base de donnees
            var database = client.GetDatabase(settings.Value.DatabaseName);
            //selectionner la collection
            customers = database.GetCollection<Customer>(settings.Value.CustomerCollection);
            
            

        }
        
        

        public async Task<List<Customer>> getAllCustomers()
        {
            return await customers.Find(c => true).ToListAsync();
        }

        public async Task<Customer?> getCustomerById(string id)
        {
            return await customers.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Customer?> CreateCustomer(Customer customer)
        {
            await customers.InsertOneAsync(customer);
            return customer;
        }
        
        public async Task<Customer?> UpdateCustomer(string id, Customer customer)
        {

            customer.Id = id; 
            var result = await customers.ReplaceOneAsync(customer => customer.Id == id, customer);
                
            if (result.MatchedCount == 0)
            {
                return null;
            }

            return customer;
        }

        public async Task DeleteCustomer(string id)
        {
            await customers.DeleteOneAsync(c => c.Id == id);
        }
        
            
        
    }
    


