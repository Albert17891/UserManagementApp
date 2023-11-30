using System.ComponentModel.DataAnnotations;

namespace UserManagement.Core.Entities;

public class UserProfile
{
    public int Id { get; set; } 
    public string FirstName {  get; set; }  
    public string LastName { get; set; }
    [Required]
    [RegularExpression("^d{11}$",ErrorMessage ="Personal Number Must be 11")]
    public string PersonalNumber {  get; set; }

    //Relations
    public User User { get; set; }
}
