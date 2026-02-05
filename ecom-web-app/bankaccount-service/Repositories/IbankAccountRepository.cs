using ecom_web_app.bankaccount_service.Models;

namespace ecom_web_app.bankaccount_service.Repositories;

public interface IbankAccountRepository
{
    Task<List<BankAccount>> GetAllBankAccounts();
    Task<BankAccount?> GetBankAccountById(string id);
    Task<BankAccount?> CreateBankAccount(BankAccount bankAccount);
    Task<BankAccount> UpdateBankAccount(string id , BankAccount bankAccount);
    Task DeleteBankAccount(string id);
 }