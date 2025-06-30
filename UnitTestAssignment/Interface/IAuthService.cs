namespace UnitTestAssignment.Interface
{
    public interface IAuthService
    {
        Task<bool> IsEmailRegisteredAsync(string email);
        bool IsValidPassword(string password);
    }
}
