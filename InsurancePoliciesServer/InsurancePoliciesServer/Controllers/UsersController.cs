using InsurancePoliciesServer.Entities;
using InsurancePoliciesServer.Interfaces;
using InsurancePoliciesServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePoliciesServer.Controllers
{
    [Route("UsersController")]
    [ApiController]
    public class UsersController : Controller
    {

        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<Users> Tasks = _userRepository.GetAllUsers();
                return Ok(Tasks);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] Users user)
        {
            try
            {
                await _userRepository.AddUser(user);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] Users user)
        {
            try
            {
                await _userRepository.UpdateUser(user);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteUser/{userId}")]

        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                await _userRepository.DeleteUser(userId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetUserById/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                Users user = _userRepository.GetUserById(userId);
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
