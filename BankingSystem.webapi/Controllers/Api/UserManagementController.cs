using BankingSystem.application.DTOs;
using BankingSystem.domian.Interfaces;
using BankingSystem.domian.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.webapi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly ICustomerRepository _customerRepository;

        public UserManagementController(IUserRepository userRepository, IUserProfileRepository userProfileRepository, ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _userProfileRepository = userProfileRepository;
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserManagementDTO dto)
        {
            // Create User
            string EPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var user = new User { Email = dto.Email , PasswordHash = EPassword};
            await _userRepository.AddUser(user);

            // Create UserProfile
            var userProfile = new UserProfile
            {
                UserID = user.UserID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                CreatedAt = DateTime.UtcNow
                // Assume RoleID resolved inside the repository method
            };
            await _userProfileRepository.AddUserProfile(userProfile, dto.RoleName);

            // Create Customer
            var customer = new Customer
            {
                UserID = user.UserID,
                DateOfBirth = dto.DateOfBirth,
                Status = "Active"
            };
            await _customerRepository.AddCustomer(customer);

            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            var userProfile = await _userProfileRepository.GetUserProfileById(id);
            var customer = await _customerRepository.GetCustomerById(id);

            if (user == null || userProfile == null || customer == null)
                return NotFound();

            return Ok(new { User = user, UserProfile = userProfile, Customer = customer });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserManagementDTO dto)
        {
            // Retrieve existing entities
            var user = await _userRepository.GetUserById(id);
            var userProfile = await _userProfileRepository.GetUserProfileById(id);
            var customer = await _customerRepository.GetCustomerById(id);

            if (user == null || userProfile == null || customer == null)
                return NotFound("Related user, profile, or customer not found.");

            // Update User
            user.Email = dto.Email; // Assuming Email can be updated
            await _userRepository.UpdateUser(user);

            // Update UserProfile
            userProfile.FirstName = dto.FirstName;
            userProfile.LastName = dto.LastName;
            userProfile.PhoneNumber = dto.PhoneNumber;
            // Update role if role management is handled within UserProfile repository
            await _userProfileRepository.UpdateUserProfile(userProfile, dto.RoleName);

            // Update Customer
            customer.DateOfBirth = dto.DateOfBirth;
            customer.Status = dto.CustomerStatus;
            await _customerRepository.UpdateCustomer(customer);

            return NoContent(); // 204 No Content indicates successful update without returning data
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // You may need to consider the order of deletions depending on the database constraints
            var customer = await _customerRepository.GetCustomerById(id);
            var userProfile = await _userProfileRepository.GetUserProfileById(id);
            var user = await _userRepository.GetUserById(id);

            if (customer == null && userProfile == null && user == null)
                return NotFound("User and associated data not found.");

            // Delete Customer first if necessary
            if (customer != null)
                await _customerRepository.DeleteCustomer(id);

            // Delete UserProfile
            if (userProfile != null)
                await _userProfileRepository.DeleteUserProfile(id);

            // Finally, delete User
            if (user != null)
                await _userRepository.DeleteUser(id);

            return NoContent(); // 204 No Content for successful deletion
        }
    }

}
