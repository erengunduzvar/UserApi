using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleContext _context;
        public RoleRepository(RoleContext context)
        {
            _context = context;
        }

        public async Task<Role> Create(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task Delete(int id)
        {
            var roleToDelete = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(roleToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> Get()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> Get(int id)
        {
            return await _context.Roles.FindAsync(id);
        }
        public async Task Update(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
