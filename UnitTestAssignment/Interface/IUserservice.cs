using System.Threading.Tasks;
using UserOrderSystem.Models;

namespace UserOrderSystem.Repositories
{
    public interface IUserservice
    {
        Task<User> GetUserByIdAsync(int id);
    }
}