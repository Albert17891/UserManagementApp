namespace UserManagement.Core.Interfaces.Service;

public interface IJwtService
{
    string CreateToken(string userName);
}
