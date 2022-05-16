// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using BTSolution.API.Data;
using BTSolution.API.Models;
using BTSolution.API.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;


namespace BTSolution.API.Repositories;

public class AccessTokenRepository : IAccessTokenRepository
{
    #region Members

    private readonly DataContext _context;

    #endregion

    #region Constructors

    public AccessTokenRepository(DbContextOptions<DataContext> dbOptions)
    {
        _context = new DataContext(dbOptions);
    }

    #endregion

    #region Interface Members

    public async void CreateAccessToken(AccessToken accessToken)
    {
        _context.AccessTokens.Add(accessToken);
        await _context.SaveChangesAsync();
    }

    public async void DeleteUserAccessTokens(int userId)
    {
        var accessTokens = await _context.AccessTokens
            .Where(x => x.UserId == userId)
            .ToListAsync();

        _context.RemoveRange(accessTokens);
        await _context.SaveChangesAsync();
    }

    public async Task<List<AccessTokenForTransfer>> GetAccessTokens()
    {
        var validAccessTokens = await _context.AccessTokens.Where(token => token.CreationDate.AddSeconds(token.Duration) > DateTime.UtcNow)
            .ToListAsync();

        var validAccessTokensForTransfer = AccessTokenForTransfer.ConvertForTransfer(validAccessTokens);
        return await FillUserNameField(validAccessTokensForTransfer);
    }

    #endregion

    #region Methods - Private

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