using UserManagement.Core.Entities;
using UserManagement.Core.Interfaces.Repository;
using UserManagement.Core.Interfaces.Service;

namespace UserManagement.Core.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IUserProfileRepository _repository;

    public UserProfileService(IUserProfileRepository repository)
    {
        _repository = repository;
    }
    public async Task<int> CreateUserProfile(UserProfile userProfile)
    {
        return await _repository.CreateUserProfile(userProfile);
    }

    public async Task DeleteUserProfileAsync(int id)
    {
        await _repository.DeleteUserProfileAsync(id);
    }

    public async Task<List<UserProfile>> GetAllUserProfilesAsync()
    {
        return await _repository.GetAllUserProfilesAsync();
    }

    public async Task<UserProfile> GetUserProfileByIdAsync(int id)
    {
        return await _repository.GetUserProfileByIdAsync(id);
    }

    public void UpdateUserProfile(UserProfile userProfile)
    {
        _repository.UpdateUserProfile(userProfile);
    }
}
