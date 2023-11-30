using Microsoft.EntityFrameworkCore;
using UserManagement.Core.Entities;
using UserManagement.Core.Interfaces.Repository;
using UserManagement.Infastructure;


public class UserProfileRepository : IUserProfileRepository
{
    private readonly AppDbContext _context;

    public UserProfileRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateUserProfile(UserProfile userProfile)
    {
        if (userProfile == null)
            throw new ArgumentNullException(nameof(userProfile));

        await _context.AddAsync(userProfile);

        return await _context.SaveChangesAsync();
    }

    public async Task DeleteUserProfileAsync(int id)
    {
        var userProfile = await _context.Profiles.SingleOrDefaultAsync(x => x.Id == id);

        _context.Profiles.Remove(userProfile);

        await _context.SaveChangesAsync();
    }

    public async Task<List<UserProfile>> GetAllUserProfilesAsync()
    {
        return await _context.Profiles.ToListAsync();
    }

    public async Task<UserProfile> GetUserProfileByIdAsync(int id)
    {
        return await _context.Profiles.SingleOrDefaultAsync(x => x.Id == id);
    }

    public void UpdateUserProfile(UserProfile userProfile)
    {
        _context.Profiles.Update(userProfile);

        _context.SaveChanges();
    }
}
