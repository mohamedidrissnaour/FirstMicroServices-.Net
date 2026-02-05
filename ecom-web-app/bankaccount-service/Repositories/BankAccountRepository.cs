using ecom_web_app.bankaccount_service.Models;
using ecom_web_app.bankaccount_service.Configurations;
using ecom_web_app.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ecom_web_app.bankaccount_service.Repositories;

public class BankAccountRepository : IbankAccountRepository
{
    private readonly IMongoCollection<BankAccount> bankAccounts;

    public BankAccountRepository(IOptions<MongoDBSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        bankAccounts = database.GetCollection<BankAccount>(settings.Value.BankAccountCollection);
    }

    public async Task<List<BankAccount>> GetAllBankAccounts()
    {
        return await bankAccounts.Find(bankAccounts => true).ToListAsync();
    }

    public async Task<BankAccount?> GetBankAccountById(string id)
    {
        return await bankAccounts.Find(banckAccounts => banckAccounts.Id == id).FirstOrDefaultAsync();
    }

    public async Task<BankAccount?> CreateBankAccount(BankAccount bankAccount)
    {
        await bankAccounts.InsertOneAsync(bankAccount);
        return bankAccount;
    }

    public async Task<BankAccount> UpdateBankAccount(string id, BankAccount bankAccount)
    {
        bankAccount.Id = id;
        var result = await bankAccounts.ReplaceOneAsync(bankAccount => bankAccount.Id == id, bankAccount);

        if (result.MatchedCount == 0)
        {
            return null; 
        }

        return bankAccount;
    }

    public async Task DeleteBankAccount(string id)
    {
        await bankAccounts.DeleteOneAsync(bankAccount => bankAccount.Id == id);
    }
}