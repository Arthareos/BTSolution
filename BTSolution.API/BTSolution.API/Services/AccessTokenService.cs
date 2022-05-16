// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using System.Data;

using BTSolution.API.Models;
using BTSolution.API.Repositories.Interfaces;


namespace BTSolution.API.Services;

public class AccessTokenService
{
    #region Members

    private readonly IAccessTokenRepository _accessTokenRepository;
    private readonly IUserRepository _userRepository;

    #endregion

    #region Constructors

    public AccessTokenService(IUserRepository userRepository, IAccessTokenRepository accessTokenRepository)
    {
        _userRepository = userRepository;
        _accessTokenRepository = accessTokenRepository;
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
        var user = _userRepository.GetUser(userId);

        if (user == null)
            throw new DataException();

        var token = new AccessToken {
            CreationDate = DateTime.UtcNow,
            Token = Guid.NewGuid().ToString(),
            Duration = durationInSeconds,
            UserId = userId,
        };

        _accessTokenRepository.CreateAccessToken(token);
    }

    /// <summary>
    ///     Returns all the AccessTokens in the db (NOT expired)
    /// </summary>
    public async Task<List<AccessTokenForTransfer>> GetValidAccessTokens()
    {
        return await _accessTokenRepository.GetAccessTokens();
    }

    public void DeleteUserAccessTokens(int userId)
    {
        _accessTokenRepository.DeleteUserAccessTokens(userId);
    }

    #endregion
}