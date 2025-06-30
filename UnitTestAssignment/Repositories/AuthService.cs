using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnitTestAssignment.Interface;
using UserOrderSystem.Repositories;

namespace UserOrderSystem.Services
{
    public class AuthService : IAuthService
    {
        //private readonly IAuthService _authService;
        

        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
           
            return email.Contains("@");
        }

        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit) &&
                   password.Any(ch => !char.IsLetterOrDigit(ch)); // special character
        }
    }

}