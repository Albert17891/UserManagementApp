﻿namespace UserManagement.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsActived { get; set; }

    public UserProfile UserProfile { get; set; }
}
