using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Core.Entities;
using UserManagement.Core.Interfaces.Service;
using UserManagement.Request;
using UserManagement.Response;

namespace UserManagement.Controllers;
[Route("[controller]")]
[ApiController]
[Authorize]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult> Login(Login login)
    {
        var token = await _userService.Login(login.UserName, login.Password);

        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized();
        }

        return Ok(token);
    }
    [AllowAnonymous]
    [HttpGet("Posts")]
    public async Task<IActionResult> GetUserPost(int id)
    {
        var result =await _userService.GetUserPost(id);

        return Ok(result);  
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users.Adapt<IEnumerable<UserResponse>>());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user.Adapt<UserResponse>());
    }

    [AllowAnonymous]
    [HttpPost("CreateUser")]
    public async Task<ActionResult<User>> CreateUser(UserRequest user)
    {
        var id = await _userService.CreateUser(user.Adapt<User>());

        return Ok(id);
    }


    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }

        _userService.UpdateUser(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }
}
