// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using BTSolution.API.Models;
using BTSolution.API.Services;

using Microsoft.AspNetCore.Mvc;


namespace BTSolution.API.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    #region Members

    private readonly UserService _userService;
    private readonly AccessTokenService _accessTokenService;

    #endregion

    #region Constructors

    public UserController(UserService userService, AccessTokenService accessTokenService)
    {
        _userService = userService;
        _accessTokenService = accessTokenService;
    }

    #endregion

    #region Methods - Public

    /// <summary>
    ///     Adds the user to the db
    /// </summary>
    /// <param name="user">user object to be added</param>
    [HttpPost("{userName}")]
    public async Task<IActionResult> AddUser(string userName)
    {
        if (string.IsNullOrEmpty(userName)) {
            return BadRequest();
        }

        _userService.AddUser(userName);
        return Ok();
    }

    /// <summary>
    ///     Returns all the users from the db
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var userList = await _userService.GetUsers();
        return Ok(userList);
    }

    /// <summary>
    ///     Removes the user from the db including his accessTokens
    /// </summary>
    /// <param name="userId"></param>
    [HttpDelete("{userId}")]
    public async Task<ActionResult<List<User>>> RemoveUser(int userId)
    {
        if (userId < 0)
            return BadRequest();

        _userService.RemoveUser(userId);
        _accessTokenService.RemoveUserAccessTokens(userId);

        return Ok();
    }

    #endregion
}