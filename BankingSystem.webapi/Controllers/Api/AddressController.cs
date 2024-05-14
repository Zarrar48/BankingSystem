using BankingSystem.application.DTOs;
using BankingSystem.domian.Interfaces;
using BankingSystem.domian.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.webapi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICustomerAddressRepository _customerAddressRepository;

        public AddressController(IAddressRepository addressRepository, ICustomerAddressRepository customerAddressRepository)
        {
            _addressRepository = addressRepository;
            _customerAddressRepository = customerAddressRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress([FromBody] AddressDTO addressDto)
        {
            var address = new Address
            {
                Street = addressDto.Street,
                City = addressDto.City,
                State = addressDto.State,
                Country = addressDto.Country,
                PostalCode = addressDto.PostalCode
            };
            await _addressRepository.AddAddress(address);

            var customerAddress = new CustomerAddress
            {
                CustomerID = addressDto.CustomerID,
                AddressID = address.AddressID,
                AddressType = addressDto.AddressType
            };
            await _customerAddressRepository.AddCustomerAddress(customerAddress);

            return CreatedAtAction(nameof(GetAddressById), new { id = address.AddressID }, address);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddressById(int id)
        {
            var address = await _addressRepository.GetAddressById(id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody] AddressDTO addressDto)
        {
            if (id != addressDto.AddressID)
            {
                return BadRequest("Mismatch between URL ID and body ID");
            }

            var address = new Address
            {
                AddressID = id,
                Street = addressDto.Street,
                City = addressDto.City,
                State = addressDto.State,
                Country = addressDto.Country,
                PostalCode = addressDto.PostalCode
            };
            await _addressRepository.UpdateAddress(address);

            return NoContent();
        }
    }

}
