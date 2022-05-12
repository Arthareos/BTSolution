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

    [HttpPost]
    public async Task<ActionResult<List<User>>> AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        return Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        return Ok(await _context.Users.ToListAsync());
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<List<User>>> Get(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            return BadRequest("User not found.");

        return Ok(user);
    }

    [HttpDelete("{userId}")]
    public async Task<ActionResult<List<User>>> RemoveUser(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            return BadRequest("User not found.");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return Ok("User removed.");
    }

    [HttpPut]
    public async Task<ActionResult<List<User>>> UpdateUser(User requestUser)
    {
        var user = await _context.Users.FindAsync(requestUser.UserId);

        if (user == null)
            return BadRequest("User not found.");

        user.UserName = requestUser.UserName;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return Ok(user);
    }

    #endregion
}