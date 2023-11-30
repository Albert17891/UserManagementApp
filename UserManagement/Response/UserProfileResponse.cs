using System.ComponentModel.DataAnnotations;

namespace UserManagement.Response;

public class UserProfileResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }   

    public string PersonalNumber { get; set; }
}
