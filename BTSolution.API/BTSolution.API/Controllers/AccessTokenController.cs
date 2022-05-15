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

    private const int MaxDurationInSeconds = 60;

    private const int MinDurationInSeconds = 1;

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
    public async Task<IActionResult> GenerateAccessToken(int userId, int durationInSeconds)
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
            CreationDate = DateTime.UtcNow,
            Token = Guid.NewGuid().ToString(),
            Duration = durationInSeconds,
            UserId = userId,
        };

        _context.AccessTokens.Add(token);
        await _context.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (expired included)
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<AccessTokenForTransfer>>> GetAllAccessTokens()
    {
        var accessTokens = await _context.AccessTokens.ToListAsync();
        var validAccessTokensForTransfer = AccessTokenForTransfer.ConvertForTransfer(accessTokens);
        return Ok(validAccessTokensForTransfer);
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (expired included) owned by the user
    /// </summary>
    /// <param name="userId">userId of the owner</param>
    [HttpGet("{userId}")]
    public async Task<ActionResult<List<AccessTokenForTransfer>>> GetAllUserAccessTokens(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            return BadRequest("User not found.");

        var accessTokens = await _context.AccessTokens.Where(token => token.UserId == userId).ToListAsync();

        var validAccessTokensForTransfer = AccessTokenForTransfer.ConvertForTransfer(accessTokens);
        validAccessTokensForTransfer = await FillUserNameField(validAccessTokensForTransfer);

        return Ok(validAccessTokensForTransfer);
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (expired excluded)
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<AccessTokenForTransfer>>> GetValidAccessTokens()
    {
        var validAccessTokens = await _context.AccessTokens
            .Where(token => token.CreationDate.AddSeconds(token.Duration) > DateTime.UtcNow).ToListAsync();

        var validAccessTokensForTransfer = AccessTokenForTransfer.ConvertForTransfer(validAccessTokens);
        validAccessTokensForTransfer = await FillUserNameField(validAccessTokensForTransfer);

        return Ok(validAccessTokensForTransfer);
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (expired excluded) owned by the user
    /// </summary>
    /// <param name="userId">userId of the owner</param>
    [HttpGet("{userId}")]
    public async Task<ActionResult<List<AccessTokenForTransfer>>> GetValidUserAccessTokens(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            return BadRequest("User not found.");

        var validAccessTokens = await _context.AccessTokens
            .Where(token => token.CreationDate.AddSeconds(token.Duration) > DateTime.UtcNow && token.UserId == userId).ToListAsync();

        var validAccessTokensForTransfer = AccessTokenForTransfer.ConvertForTransfer(validAccessTokens);
        validAccessTokensForTransfer = await FillUserNameField(validAccessTokensForTransfer);

        return Ok(validAccessTokensForTransfer);
    }

    #endregion

    #region Methods - Private

    /// <summary>
    ///     Fills the "UserName" field for each AccessToken
    /// </summary>
    /// <param name="accessTokensForTransfer">AccessTokens to be filled</param>
    private async Task<IEnumerable<AccessTokenForTransfer>> FillUserNameField(IEnumerable<AccessTokenForTransfer> accessTokensForTransfer)
    {
        foreach (var accessTokenForTransfer in accessTokensForTransfer) {
            var user = await _context.Users.FindAsync(accessTokenForTransfer.UserId);
            accessTokenForTransfer.UserName = user.UserName;
        }

        return accessTokensForTransfer;
    }

    /// <summary>
    ///     Fills the "UserName" field for the AccessToken
    /// </summary>
    /// <param name="accessTokenForTransfer">AccessToken to be filled</param>
    private async Task<AccessTokenForTransfer> FillUserNameField(AccessTokenForTransfer accessTokenForTransfer)
    {
        var user = await _context.Users.FindAsync(accessTokenForTransfer.UserId);
        accessTokenForTransfer.UserName = user.UserName;

        return accessTokenForTransfer;
    }

    #endregion
}