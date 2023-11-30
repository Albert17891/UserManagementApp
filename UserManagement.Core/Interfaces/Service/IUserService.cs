using UserManagement.Core.Entities;
using UserManagement.Core.Entities.PlaceHolderModels;

namespace UserManagement.Core.Interfaces.Service;

public interface IUserService
{
    Task<string> Login(string username, string password);
    Task<User> GetUserByIdAsync(int id);
    Task<List<User>> GetAllUsersAsync();
    Task<int> CreateUser(User user);
    Task DeleteUserAsync(int id);
    void UpdateUser(User user);

    Task<List<Post>> GetUserPost(int id);
}
