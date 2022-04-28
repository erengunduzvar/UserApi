using BookAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> Get();
        Task<Role> Get(int id);
        Task<Role> Create(Role role);
        Task Update(Role role);
        Task Delete(int id);

    }
}
