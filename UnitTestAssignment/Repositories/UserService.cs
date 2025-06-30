using System.Threading.Tasks;
using UserOrderSystem.Models;
using UserOrderSystem.Repositories;

namespace UserOrderSystem.Services
{
    public class UserService : IUserservice
    {

        public virtual Task<User> GetUserByIdAsync(int id)
        {
            // In actual code, you may connect to DB
            return Task.FromResult<User>(null);
        }

        public Task<User> GetUserById(int id)
        {
            return GetUserByIdAsync(id);
        }  
        
    }
}