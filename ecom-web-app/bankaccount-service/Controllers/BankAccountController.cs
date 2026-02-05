using ecom_web_app.bankaccount_service.Models;
using ecom_web_app.bankaccount_service.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ecom_web_app.bankaccount_service.Controllers;


[ApiController]
[Route("/bankaccount")]
public class BankAccountController : ControllerBase
{
    private readonly IbankAccountRepository bankAccountRepository;

    public BankAccountController(IbankAccountRepository bankAccountRepository)
    {
        this.bankAccountRepository = bankAccountRepository;
    }

    [HttpGet] //Getmapping
    public async Task<ActionResult<IEnumerable<BankAccount>>> getAllBankAccounts()
    {
        var bankaccounts = await bankAccountRepository.GetAllBankAccounts();
        return Ok(bankaccounts);
    }

    [HttpGet("/bankaccount/{id}")]
    public async Task<ActionResult<BankAccount>> getBankAccountById(string id)
    {
        var bankAccount = bankAccountRepository.GetBankAccountById(id);
        if (bankAccount == null)
        {
            return NotFound();
        }
        return Ok(bankAccount);
    }

    [HttpPost("/bankaccount/create")]
    public async Task<ActionResult<BankAccount>> CreateBankAccount(BankAccount bankAccount)
    {
        var created = await bankAccountRepository.CreateBankAccount(bankAccount);
        return CreatedAtAction(
            nameof(getBankAccountById),
            new { id = created.Id }, created);
    }

    [HttpPut("/bankaccount/update/{id}")]
    public async Task<ActionResult<BankAccount>> UpdateBankAccount(string id, BankAccount bankAccount)
    {
        var updated = await bankAccountRepository.UpdateBankAccount(id, bankAccount);

        if (updated == null)
        {
            return null;
        }

        return Ok(updated);
    }

    [HttpDelete("/bankaccount/delete/{id}")]
    public async Task<IActionResult> DeleteAccount(string id)
    {
        await bankAccountRepository.DeleteBankAccount(id);
        return NoContent();
    }
}