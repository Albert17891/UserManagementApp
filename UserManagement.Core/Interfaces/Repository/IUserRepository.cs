using UserManagement.Core.Entities;

namespace UserManagement.Core.Interfaces.Repository;

public interface IUserRepository
{
    Task<bool> Login(string userName,string password);
    Task<User> GetUserByIdAsync(int id); 
    Task<List<User>> GetAllUsersAsync();
    Task<int> CreateUser(User user);
    Task DeleteUserAsync(int id);   
    void UpdateUser(User user); 

}
