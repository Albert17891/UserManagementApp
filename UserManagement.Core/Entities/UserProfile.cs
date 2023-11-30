using System.ComponentModel.DataAnnotations;

namespace UserManagement.Core.Entities;

public class UserProfile
{
    public int Id { get; set; } 
    public string FirstName {  get; set; }  
    public string LastName { get; set; }   
    public string PersonalNumber {  get; set; }

    //Relations
    public User User { get; set; }
}
