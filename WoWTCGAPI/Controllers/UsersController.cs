// Controllers/UsersController.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/user")]
public class UsersController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public UsersController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    //[HttpPost("register")]
    //public async Task<IActionResult> Register([FromBody] RegisterModel model)
    //{
    //    var user = new User { UserName = model.Username, Email = model.Email };
    //    var result = await _userManager.CreateAsync(user, model.Password);

    //    if (result.Succeeded)
    //    {
    //        return Ok();
    //    }

    //    return BadRequest(result.Errors);
    //}

    // Additional actions for login, etc.
}

// Additional controllers for Collections, Decks, and Prices