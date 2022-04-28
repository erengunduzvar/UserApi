using BookAPI.Models;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RolesController(IRoleRepository roleReposxitory)
        {
            _roleRepository = roleReposxitory;
        }

        [HttpGet]
        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _roleRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoles(int id)
        {
            return await _roleRepository.Get(id);
        }
        
        [HttpPost]
        public async Task<ActionResult<Role>> PostRoles([FromBody]Role role)
        {
            var newRole = await _roleRepository.Create(role);
            return CreatedAtAction(nameof(GetRoles), new { id = newRole.roleID }, newRole);

        }
    }
}
