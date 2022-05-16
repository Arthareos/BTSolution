// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using BTSolution.API.Models;


namespace BTSolution.API.Interfaces;

public interface IAccessTokenService
{
    #region Methods - Public

    public void GenerateAccessToken(int userId, int durationInSeconds);

    public Task<List<AccessTokenForTransfer>> GetAllAccessTokens();

    public Task<List<AccessTokenForTransfer>> GetAllUserAccessTokens(int userId);

    public Task<List<AccessTokenForTransfer>> GetValidAccessTokens();

    public Task<List<AccessTokenForTransfer>> GetValidUserAccessTokens(int userId);

    #endregion
}