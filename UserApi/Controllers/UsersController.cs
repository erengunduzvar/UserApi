using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookAPI.Repositories;
using System.Threading.Tasks;
using BookAPI.Models;
using System.Collections;
using System.Collections.Generic;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers() //tum kayıtlı kullanıcıları dondurme metodum
        {
            return await _userRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(int id) //idye gore dondurme metodum
        {
            return await _userRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody]User user) //Ekleme metodum
        {
            var newUser = await _userRepository.Create(user);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser.Id }, newUser);
        }

        [HttpPut]
        public async Task<ActionResult> PutUsers(int id,[FromBody] User user) //uptade metodum
        {
            if(id != user.Id)
            {
                return BadRequest();
            }
            await _userRepository.Uptade(user);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var bookToDelete = await _userRepository.Get(id);
            if(bookToDelete != null)
            {
                await _userRepository.Delete(bookToDelete.Id);
                return NoContent();
            }
            else
                return NotFound();
        }

    }
}
