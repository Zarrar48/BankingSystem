using BankingSystem.domian.Interfaces;
using BankingSystem.application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankingSystem.domian.Entities;

namespace BankingSystem.webapi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;

       public LoanController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateLoan([FromBody] LoanRequestDto loanRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bool result = await _loanRepository.CreateLoan(loanRequest.CustomerId, loanRequest.Amount);
                if (!result)
                {
                    return BadRequest("Unable to create loan");
                }
                return Ok("Loan created successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("repay")]
        public async Task<IActionResult> RepayLoan([FromBody] RepaymentDto repayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _loanRepository.RepayLoan(repayment.LoanId, repayment.Amount);
                return Ok("Loan repayment successful");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("repayMultiple")]
        public async Task<IActionResult> RepayMultipleLoans([FromBody] List<RepaymentDto> repayments)
        {
            try
            {
                var payments = repayments.ToDictionary(r => r.LoanId, r => r.Amount);
                await _loanRepository.RepayMultipleLoans(payments);
                return Ok("Multiple loans repayment successful");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("current/{customerId}")]
        public async Task<ActionResult<Loans>> GetCurrentLoan(int customerId)
        {
            var loan = await _loanRepository.GetCurrentLoan(customerId);
            if (loan == null)
                return NotFound("No active loan found for this customer.");
            return Ok(loan);
        }

        [HttpGet("history/{customerId}")]
        public async Task<ActionResult<List<Loans>>> GetLoanHistory(int customerId)
        {
            var loans = await _loanRepository.GetLoanHistory(customerId);
            if (loans == null || !loans.Any())
                return NotFound("No historical loans found for this customer.");
            return Ok(loans);
        }
    }
}
