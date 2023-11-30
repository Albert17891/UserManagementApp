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

public class UsersProfileController : ControllerBase
{
    private readonly IUserProfileService _userProfileService;

    public UsersProfileController(IUserProfileService userProfileService)
    {
        _userProfileService = userProfileService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserProfile>>> GetAllUserProfiles()
    {
        var userProfiles = await _userProfileService.GetAllUserProfilesAsync();
        return Ok(userProfiles.Adapt<UserProfileResponse>());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserProfile>> GetUserProfileById(int id)
    {
        var userProfile = await _userProfileService.GetUserProfileByIdAsync(id);

        if (userProfile == null)
        {
            return NotFound();
        }

        return Ok(userProfile.Adapt<UserProfileResponse>());
    }

    [HttpPost]
    public async Task<ActionResult<UserProfile>> CreateUserProfile(UserProfileRequest userProfile)
    {
        var id = await _userProfileService.CreateUserProfile(userProfile.Adapt<UserProfile>());
        return Ok(id);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUserProfile(int id, UserProfile userProfile)
    {
        if (id != userProfile.Id)
        {
            return BadRequest();
        }

        _userProfileService.UpdateUserProfile(userProfile);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserProfile(int id)
    {
        await _userProfileService.DeleteUserProfileAsync(id);
        return NoContent();
    }
}
