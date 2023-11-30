using Microsoft.EntityFrameworkCore;
using UserManagement.Core.Entities;
using UserManagement.Core.Interfaces.Repository;

namespace UserManagement.Infastructure;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<int> CreateUser(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        await _context.AddAsync(user);

        return await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> Login(string userName, string password)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == userName && x.Password == password);

        if (user != null)
        {
            return true;
        }

        else { return false; }
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);

        _context.SaveChanges();
    }
}
