// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using BTSolution.API.Data;
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

    #endregion

    #region Constructors

    public UserController(DataContext context, UserService service)
    {
        _userService = service;
    }

    #endregion

    #region Methods - Public

    /// <summary>
    ///     Adds the user to the db
    /// </summary>
    /// <param name="user">user object to be added</param>
    [HttpPost]
    public async Task<IActionResult> AddUser(User user)
    {
        if (string.IsNullOrEmpty(user.UserName)) {
            return BadRequest();
        }

        await _userService.AddUser(user);
        return Ok();
    }

    /// <summary>
    ///     Returns all the users from the db
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var userList = await _userService.GetAllUsers();
        return Ok(userList);
    }

    /// <summary>
    ///     Returns only the requested user
    /// </summary>
    /// <param name="userId">id for the requested user</param>
    [HttpGet("{userId}")]
    public async Task<ActionResult<User>> GetUser(int userId)
    {
        if (userId < 0)
            return BadRequest();

        var user = await _userService.GetUser(userId);

        if (user == null)
            return BadRequest();

        return Ok(user);
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

        return Ok();
    }

    /// <summary>
    ///     Updates the user using the data provided
    /// </summary>
    /// <param name="requestUser">new user object</param>
    [HttpPut]
    public async Task<ActionResult<List<User>>> UpdateUser(User requestUser)
    {
        if (string.IsNullOrEmpty(requestUser.UserName))
            return BadRequest();

        try {
            _userService.UpdateUser(requestUser);
            return Ok();
        } catch {
            return BadRequest();
        }
    }

    #endregion
}