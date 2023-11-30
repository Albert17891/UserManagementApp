using UserManagement.Core.Entities;
using UserManagement.Core.Interfaces.Repository;
using UserManagement.Core.Interfaces.Service;

namespace UserManagement.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IJwtService _jwtService;

    public UserService(IUserRepository repository, IJwtService jwtService)
    {
        _repository = repository;
        _jwtService = jwtService;
    }
    public async Task<int> CreateUser(User user)
    {
        return await _repository.CreateUser(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _repository.DeleteUserAsync(id);
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _repository.GetAllUsersAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _repository.GetUserByIdAsync(id);
    }

    public async Task<string> Login(string username, string password)
    {
        var result = await _repository.Login(username, password);

        if (result == false)
        {
            return string.Empty;
        }

        var token = _jwtService.CreateToken(username);

        return token;
    }

    public void UpdateUser(User user)
    {
        _repository.UpdateUser(user);
    }
}
