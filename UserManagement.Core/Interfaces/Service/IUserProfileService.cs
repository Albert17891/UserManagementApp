using UserManagement.Core.Entities;

namespace UserManagement.Core.Interfaces.Service;

public interface IUserProfileService
{
    Task<UserProfile> GetUserProfileByIdAsync(int id);
    Task<List<UserProfile>> GetAllUserProfilesAsync();
    Task<int> CreateUserProfile(UserProfile user);
    Task DeleteUserProfileAsync(int id);
    void UpdateUserProfile(UserProfile user);
}
