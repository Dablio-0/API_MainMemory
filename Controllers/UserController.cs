using API_MainMemory.Entity;
using API_MainMemory.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_MainMemory.Controllers
{
    [Controller]
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
        public IActionResult CreateUser(User usuario)
        {
            _usersRepository.CreateUser(usuario);
            return Ok("User Created Successfully");
        }

        [HttpPut]
        public IActionResult EditUser(User usuario)
        {
            _usersRepository.EditUser(usuario);
            return Ok("User Updated Successfully!");
        }

        [HttpDelete]
        public IActionResult RemoveUser(int id)
        {
            _usersRepository.RemoveUser(id);
            return Ok("User Removed Successfully!");
        }
    }
}

