using System.ComponentModel.DataAnnotations;
using UserManagement.Core.Entities;
using UserManagement.Core.Entities.PlaceHolderModels;
using UserManagement.Core.Interfaces.Repository;
using UserManagement.Core.Interfaces.Service;

namespace UserManagement.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IJwtService _jwtService;
    private readonly IHttpClientService _httpClientService;

    public UserService(IUserRepository repository, IJwtService jwtService, IHttpClientService httpClientService)
    {
        _repository = repository;
        _jwtService = jwtService;
        _httpClientService = httpClientService;
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

    public async Task<List<Post>> GetUserPost(int id)
    {
        var isExist = await _repository.GetUserByIdAsync(id);

        if (isExist == null)
        {
            throw new Exception( "Canawer ar moiwebna");
        }

        var content = await _httpClientService.GetPosts();

        var filteredResuld =content.Where(x => x.UserId == id).ToList();

        return filteredResuld;

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
