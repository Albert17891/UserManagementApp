using System.ComponentModel.DataAnnotations;

namespace UserManagement.Request;

public class UserProfileRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required]
    [RegularExpression("^d{11}$", ErrorMessage = "Personal Number Must be 11")]
    public string PersonalNumber { get; set; }
}
