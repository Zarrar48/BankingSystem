using BankingSystem.application.DTOs;
using BankingSystem.domian.Interfaces;
using BankingSystem.domian.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.webapi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDTO accountDto)
        {
            var customer = await _accountRepository.GetCustomerByEmail(accountDto.Email);
            if (customer == null)
                return NotFound("Customer not found with the provided email.");

            var account = new Accounts
            {
                CustomerID = customer.CustomerID,
                Balance = accountDto.Balance,
                AccountStatus = accountDto.AccountStatus,
                LastTransactionDate = null,
                CreatedAt = DateTime.Now
            };

            await _accountRepository.AddAccount(account);
            return CreatedAtAction(nameof(GetAccountById), new { id = account.AccountID }, account);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Accounts>> GetAccountById(int id)
        {
            var account = await _accountRepository.GetAccountById(id);
            if (account == null)
                return NotFound("Account not found.");

            return Ok(account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] AccountDTO accountDto)
        {
            var account = await _accountRepository.GetAccountById(id);
            if (account == null)
                return NotFound("Account not found.");

            account.Balance = accountDto.Balance;
            account.AccountStatus = accountDto.AccountStatus;
            await _accountRepository.UpdateAccount(account);

            return NoContent();
        }
    }

}
