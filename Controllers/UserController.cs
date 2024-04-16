using API_MainMemory.Entity;
using API_MainMemory.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_MainMemory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserRepository _usersRepository;

        public UserController(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public IActionResult ShowAllUsers()
        {
            return Ok(_usersRepository.ShowAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult ShowUserById(int id)
        {
            return Ok(_usersRepository.ShowUserById(id));
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _usersRepository.CreateUser(user);
            return Ok("User Created Successfully");
        }

        [HttpPut]
        public IActionResult EditUser(User user)
        {
            _usersRepository.EditUser(user);
            return Ok("User Updated Successfully!");
        }

        [HttpDelete]
        public IActionResult RemoveUser(int id)
        {
            _usersRepository.RemoveUser(id);
            return Ok("User Removed Successfully!");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(User user)
        {
            var allUser = _usersRepository.ShowAllUsers();

            var userlogin = allUser.FirstOrDefault(user =>
                (user.email == user.email || user.name == user.name) &&
                user.password == user.password);

            if (userlogin == null)
                return NotFound("User not found");

            return Ok("User logged in successfully");
        }
    }
}

