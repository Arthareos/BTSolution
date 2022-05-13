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
public class AccessTokenController : ControllerBase
{
    #region Static Members

    private const int MinDurationInSeconds = 1;
    private const int MaxDurationInSeconds = 60;

    #endregion

    #region Members

    private readonly DataContext _context;

    #endregion

    #region Constructors

    public AccessTokenController(DataContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods - Public

    /// <summary>
    ///     Generate an AccessToken
    /// </summary>
    /// <param name="userId">userId to assign the token to</param>
    /// <param name="durationInSeconds">duration of the token</param>
    [HttpPost("{userId}/{durationInSeconds}")]
    public async Task<ActionResult<List<AccessToken>>> GenerateAccessToken(int userId, int durationInSeconds)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            return BadRequest("User not found.");

        switch (durationInSeconds) {
            case < MinDurationInSeconds:
                return BadRequest($@"Duration smaller than {MinDurationInSeconds}, this is not permitted under current policy.");
            case > MaxDurationInSeconds:
                return BadRequest($@"Duration greater than {MaxDurationInSeconds}, this is not permitted under current policy.");
        }

        var token = new AccessToken {
            CreationDate = DateTime.Now,
            Token = Guid.NewGuid().ToString(),
            Duration = durationInSeconds,
            UserId = userId
        };

        _context.AccessTokens.Add(token);
        await _context.SaveChangesAsync();
        return Ok(token);
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (expired included)
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<AccessToken>>> GetAllAccessTokens()
    {
        return Ok(await _context.AccessTokens.ToListAsync());
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (expired included) owned by the user
    /// </summary>
    /// <param name="userId">userId of the owner</param>
    [HttpGet("{userId}")]
    public async Task<ActionResult<List<User>>> GetAllUserAccessToken(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            return BadRequest("User not found.");

        var accessTokens = await _context.AccessTokens.Where(token => token.UserId == userId).ToListAsync();

        return Ok(accessTokens);
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (expired excluded)
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<AccessToken>>> GetValidAccessTokens()
    {
        var validAccessTokens = await _context.AccessTokens
            .Where(token => token.CreationDate.AddSeconds(token.Duration) > DateTime.Now).ToListAsync();

        return Ok(validAccessTokens);
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (expired excluded) owned by the user
    /// </summary>
    /// <param name="userId">userId of the owner</param>
    [HttpGet("{userId}")]
    public async Task<ActionResult<List<User>>> GetValidUserAccessToken(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            return BadRequest("User not found.");

        var validAccessTokens = await _context.AccessTokens
            .Where(token => token.CreationDate.AddSeconds(token.Duration) > DateTime.Now && token.UserId == userId).ToListAsync();

        return Ok(validAccessTokens);
    }

    #endregion
}