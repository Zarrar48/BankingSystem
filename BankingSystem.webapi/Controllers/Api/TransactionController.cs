using BankingSystem.domian.Interfaces;
using BankingSystem.application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace BankingSystem.webapi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferMoney([FromBody] TransferDTO transfer)
        {
            var success = await _transactionRepository.TransferMoney(transfer.FromAccountId, transfer.ToAccountId, transfer.Amount, transfer.Description);
            if (!success)
                return BadRequest("Transfer failed due to invalid accounts or insufficient balance.");
            return Ok("Transfer successful.");
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] TransactionDto transaction)
        {
            var success = await _transactionRepository.Deposit(transaction.AccountId, transaction.Amount, transaction.Description);
            if (!success)
                return BadRequest("Deposit failed due to invalid account.");
            return Ok("Deposit successful.");
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] TransactionDto transaction)
        {
            var success = await _transactionRepository.Withdraw(transaction.AccountId, transaction.Amount, transaction.Description);
            if (!success)
                return BadRequest("Withdrawal failed due to invalid account or insufficient balance.");
            return Ok("Withdrawal successful.");
        }


        [HttpGet("history/{accountId}")]
        public async Task<IActionResult> GetTransactionHistory(int accountId)
        {
            var transactions = await _transactionRepository.GetTransactionHistory(accountId);
            return Ok(transactions);
        }
    }
}
