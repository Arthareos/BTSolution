//   --------------------------------------------------------------------------------------------
//   <Copyright>
//       Copyright © 2022 Simone Di Fonzo. All rights reserved.
//   </Copyright>
//   --------------------------------------------------------------------------------------------

using BTSolution.API.Data;
using BTSolution.API.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BTSolution.API.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    #region Members

    private readonly DataContext _context;

    #endregion

    #region Constructors

    public UserController(DataContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods - Public

    /// <summary>
    ///     Adds the user to the db
    /// </summary>
    /// <param name="user">user object to be added</param>
    [HttpPost]
    public async Task<ActionResult<List<User>>> AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }

    /// <summary>
    ///     Returns all the users from the db
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        return Ok(await _context.Users.ToListAsync());
    }

    /// <summary>
    ///     Returns only the requested user
    /// </summary>
    /// <param name="userId">id for the requested user</param>
    [HttpGet("{userId}")]
    public async Task<ActionResult<List<User>>> GetUser(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            return BadRequest("User not found.");

        return Ok(user);
    }


    /// <summary>
    ///     Removes the user from the db including his accessTokens
    /// </summary>
    /// <param name="userId"></param>
    [HttpDelete("{userId}")]
    public async Task<ActionResult<List<User>>> RemoveUser(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            return BadRequest("User not found.");

        RemoveAllUserAccessTokens(userId);

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return Ok();
    }

    /// <summary>
    ///     Updates the user using the data provided
    /// </summary>
    /// <param name="requestUser">new user object</param>
    [HttpPut]
    public async Task<ActionResult<List<User>>> UpdateUser(User requestUser)
    {
        var user = await _context.Users.FindAsync(requestUser.UserId);

        if (user == null)
            return BadRequest("User not found.");

        user.UserName = requestUser.UserName;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return Ok();
    }

    #endregion

    #region Methods - Private

    /// <summary>
    ///     Removes all the AccessTokens assigned to a user
    /// </summary>
    private void RemoveAllUserAccessTokens(int userId)
    {
        var user = _context.Users.FindAsync(userId).Result;

        if (user == null)
            return;

        var userAccessTokenList = _context.AccessTokens.Where(token => token.UserId == userId).ToListAsync().Result;

        _context.AccessTokens.RemoveRange(userAccessTokenList);
        _context.SaveChanges();
    }

    #endregion
}