// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using System.Data;

using BTSolution.API.Data;
using BTSolution.API.Interfaces;
using BTSolution.API.Models;

using Microsoft.EntityFrameworkCore;


namespace BTSolution.API.Services;

public class AccessTokenService : IAccessTokenService
{
    #region Members

    private readonly DataContext _context;

    #endregion

    #region Constructors

    public AccessTokenService(DbContextOptions<DataContext> dbOptions)
    {
        _context = new DataContext(dbOptions);
    }

    #endregion

    #region Interface Members

    /// <summary>
    ///     Generate an AccessToken
    /// </summary>
    /// <param name="userId">userId to assign the token to</param>
    /// <param name="durationInSeconds">duration of the token</param>
    public async void GenerateAccessToken(int userId, int durationInSeconds)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            throw new DataException();

        var token = new AccessToken {
            CreationDate = DateTime.UtcNow,
            Token = Guid.NewGuid().ToString(),
            Duration = durationInSeconds,
            UserId = userId,
        };

        _context.AccessTokens.Add(token);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (expired included)
    /// </summary>
    public async Task<List<AccessTokenForTransfer>> GetAllAccessTokens()
    {
        var accessTokens = await _context.AccessTokens.ToListAsync();
        var validAccessTokensForTransfer = AccessTokenForTransfer.ConvertForTransfer(accessTokens);
        validAccessTokensForTransfer = await FillUserNameField(validAccessTokensForTransfer);
        return validAccessTokensForTransfer;
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (expired included) owned by the user
    /// </summary>
    /// <param name="userId">userId of the owner</param>
    public async Task<List<AccessTokenForTransfer>> GetAllUserAccessTokens(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            throw new DataException();

        var accessTokens = await _context.AccessTokens.Where(token => token.UserId == userId).ToListAsync();
        var validAccessTokensForTransfer = AccessTokenForTransfer.ConvertForTransfer(accessTokens);

        return await FillUserNameField(validAccessTokensForTransfer);
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (NOT expired)
    /// </summary>
    public async Task<List<AccessTokenForTransfer>> GetValidAccessTokens()
    {
        var validAccessTokens = await _context.AccessTokens
            .Where(token => token.CreationDate.AddSeconds(token.Duration) > DateTime.UtcNow)
            .ToListAsync();

        var validAccessTokensForTransfer = AccessTokenForTransfer.ConvertForTransfer(validAccessTokens);
        return await FillUserNameField(validAccessTokensForTransfer);
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (expired excluded) owned by the user
    /// </summary>
    /// <param name="userId">userId of the owner</param>
    public async Task<List<AccessTokenForTransfer>> GetValidUserAccessTokens(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            throw new DataException();

        var validAccessTokens = await _context.AccessTokens
            .Where(token => token.CreationDate.AddSeconds(token.Duration) > DateTime.UtcNow && token.UserId == userId).ToListAsync();

        var validAccessTokensForTransfer = AccessTokenForTransfer.ConvertForTransfer(validAccessTokens);
        return await FillUserNameField(validAccessTokensForTransfer);
    }

    #endregion

    #region Methods - Private

    /// <summary>
    ///     Fills the "UserName" field for each AccessToken
    /// </summary>
    /// <param name="accessTokensForTransfer">AccessTokens to be filled</param>
    private async Task<List<AccessTokenForTransfer>> FillUserNameField(List<AccessTokenForTransfer> accessTokensForTransfer)
    {
        foreach (var accessTokenForTransfer in accessTokensForTransfer) {
            var user = await _context.Users.FindAsync(accessTokenForTransfer.UserId);
            accessTokenForTransfer.UserName = user.UserName;
        }

        return accessTokensForTransfer;
    }

    #endregion
}