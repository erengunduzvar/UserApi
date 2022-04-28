using BookAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace BookAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task <User> Get(int id);
        Task <User> Create(User user);
        Task Uptade(User user);
        Task Delete(int id); 
        
    }
}
